using Azure;
using ExcelDataReader;
using FimiAppLibrary.Models;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Data;
using System.IO;
using System.IO.Pipelines;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace FimiAppUI.Pages
{
    public class RegisterStudentBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public IParentService ParentService { get; set; }
        [Inject] public IStudentClassService StudentClassService { get; set; }
        [Inject] public ISessionYearService SessionYearService { get; set; }
        [Inject] public IParentStudentService ParentStudentService { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        public FileModelFluentValidator FileValidator { get; set; } = new FileModelFluentValidator();
        public StudentModelFluentValidator StudentValidator { get; set; } = new StudentModelFluentValidator();
        public ParentModelFluentValidator ParentValidator { get; set; } = new ParentModelFluentValidator();
        public StudentModel Student { get; set; } = new StudentModel();
        public ParentModel Parent { get; set; } = new ParentModel();
        public FormModel NewStudentForm { get; set; }
        public StreamModel NewStudentStream { get; set; }
        public string SelectedGender { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public string ContentText { get; set; }
        public string ButtonText { get; set; }
        public DialogOptions dialogOptions = new() { FullWidth = true };    
        public DateTime newStudentDateOfBirth;
        public MudForm registerStudentForm;
        public MudForm registerParentForm;
        public MudDialog registerDialog;
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public bool visible;
        public MudForm form;
        public FileModel model = new();
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        public async Task<IEnumerable<FormModel>> FormSearch(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> StreamSearch(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async Task Submit()
        {
            visible = true;
        }
        public async Task DialogSubmit()
        {
            visible = false;

            await registerStudentForm.Validate();
            await registerParentForm.Validate();
            if (registerStudentForm.IsValid && registerParentForm.IsValid)
            {
                var studentResponse = await StudentService.AddStudent(Student);
                var parentResponse = await ParentService.AddParent(Parent);
                if (studentResponse.StatusCode == HttpStatusCode.Created && parentResponse.StatusCode == HttpStatusCode.Created)
                {
                    var parentStudentResponse = await ParentStudentService.AddParentStudent(Parent);
                    if(parentStudentResponse.StatusCode == HttpStatusCode.Created)
                    {
                        ShowSuccessAlert($"\"{Student.StudentName()}\" has been added and \"{Parent.FirstName} {Parent.Surname}\" linked as the parent");
                    }
                }
                else if(parentResponse.StatusCode == HttpStatusCode.Conflict)
                {
                    var parentStudentResponse = await ParentStudentService.AddParentStudent(Parent);
                    if (parentStudentResponse.StatusCode == HttpStatusCode.Created)
                    {
                        ShowSuccessAlert($"\"{Student.StudentName()}\" has been added and \"{Parent.FirstName} {Parent.Surname}\" linked as the parent");
                    }
                }
                else
                {
                    ShowFailAlert($"Failed to add student!");
                }
            }
            await registerStudentForm.ResetAsync();
            await registerParentForm.ResetAsync();
        }
        public async void UploadFiles(InputFileChangeEventArgs e)
        {
            await form.Validate();

            if (form.IsValid)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await e.File.OpenReadStream().CopyToAsync(ms);
                    ms.Position = 0;

                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(ms))
                    {
                        var conf = new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration
                            {
                                UseHeaderRow = true
                            }
                        };
                        DataSet dataset = reader.AsDataSet(conf);
                        DataRowCollection row = dataset.Tables["Sheet1"].Rows;

                        List<object> rowDataList = null;
                        List<StudentModel> students = new List<StudentModel>();
                        List<StudentClassModel> studentClasses = new List<StudentClassModel>();
                        ClassModel classModel = new ClassModel();

                        string formStream = string.Empty;
                        string secondStream = string.Empty;
                        int year = 0;
                        string form = string.Empty;

                        foreach (DataRow item in row)
                        {
                            rowDataList = item.ItemArray.ToList();

                            int i = 0;
                            string name = rowDataList[i + 1].ToString();
                            string[] splitName = name.Split(null);
                            string currentForm = rowDataList[i + 3].ToString();
                            string currentFormStream = rowDataList[i + 4].ToString();

                            if (year == 0)
                            {
                                year = Convert.ToInt32(rowDataList[i + 2]);
                            }

                            if (formStream == string.Empty && form == string.Empty)
                            {
                                form = currentForm;
                                formStream = currentFormStream;

                                DateTime date = new DateTime(year, 1, 1);

                                var streamId = await StreamService.GetStreamByName(formStream);
                                var formId = await FormService.GetFormByName(form);
                                var sessionId = await SessionYearService.GetSessionYearByStartDate(date);

                                classModel = await ClassService.GetClassByForeignKeys(formId, streamId, sessionId);
                            }
                            else if (formStream.Equals(currentFormStream) is false)
                            {
                                secondStream = currentFormStream;
                            }

                            StudentModel student = new StudentModel();
                            student.StudentNumber = (int)rowDataList[i];
                            student.FirstName = splitName[i];
                            student.MiddleName = splitName[i + 1];
                            student.Surname = splitName[i + 2];
                            student.KCPEResult = (int)rowDataList[i + 5];
                            student.PhoneNumber = rowDataList[i + 6].ToString();
                            student.Gender = rowDataList[i + 7].ToString();

                            students.Add(student);

                            StudentClassModel studentClass = new StudentClassModel
                            {
                                ClassId = classModel.ClassId,
                                StudentNumber = student.StudentNumber
                            };

                            studentClasses.Add(studentClass);
                        }
                        foreach (var student in students)
                        {
                            var response = await StudentService.AddStudent(student);
                            if (response.StatusCode == HttpStatusCode.Created)
                            {
                                continue;
                            }
                            else if (response.StatusCode == HttpStatusCode.Conflict)
                            {
                                ShowFailAlert($"Student {student.StudentNumber} already exists!");
                            }
                            else
                            {
                                ShowFailAlert($"Failed to add student!");
                            }
                        }
                        foreach (var studentClass in studentClasses)
                        {
                            var response = await StudentClassService.AddStudentClass(studentClass);
                            if (response.StatusCode == HttpStatusCode.Created)
                            {
                                continue;
                            }
                            else if (response.StatusCode == HttpStatusCode.Conflict)
                            {
                                continue;
                            }
                            else
                            {
                                ShowFailAlert($"Failed to add {studentClass.StudentNumber} to respective class!");
                            }
                        }
                    }
                }
            }
        }
        public async Task SubmitFileUpload()
        {
            
        }
        public void Cancel() => visible = false;
        public void ShowSuccessAlert(string modelType)
        {
            ModelSuccess = modelType;
            showSuccessAlert = true;
        }
        public void ShowFailAlert(string modelType)
        {
            ModelFail = modelType;
            showFailAlert = true;
        }
        public void CloseMe(bool value)
        {
            if (value)
            {
                showSuccessAlert = false;
                showFailAlert = false;
            }
            else
            {
                showSuccessAlert = false;
                showFailAlert = false;
            }
        }
    }
}