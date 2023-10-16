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
        public bool loadFile = false;
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
        public async Task UploadFiles(InputFileChangeEventArgs e)
        {
            loadFile = true;
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

                        ClassModel classModel = new ClassModel();

                        string formStream = string.Empty;
                        int year = 0;
                        string form = string.Empty;

                        for(int j = 0 ; j < row.Count; j++)
                        {
                            List<object>  rowDataList = row[j].ItemArray.ToList();

                            int i = 0;
                            string name = rowDataList[i + 1].ToString();
                            string[] splitName = name.Split(null);
                            string currentForm = rowDataList[i + 3].ToString();
                            string currentFormStream = rowDataList[i + 4].ToString();

                            if (year == 0)
                            {
                                year = Convert.ToInt32(rowDataList[i + 2]);
                            }

                            form = currentForm;
                            formStream = currentFormStream;

                            DateTime date = new DateTime(year, 1, 1);

                            var streamId = await StreamService.GetStreamByName(formStream);
                            var formId = await FormService.GetFormByName(form);
                            var sessionId = await SessionYearService.GetSessionYearByStartDate(date.ToString("s"));

                            classModel = await ClassService.GetClassByForeignKeys(formId, streamId, sessionId);

                            StudentModel student = new StudentModel();
                            student.StudentNumber = Convert.ToInt32(rowDataList[i]);
                            student.FirstName = splitName[i];
                            student.MiddleName = splitName[i + 1];
                            if(splitName.Length > 2)
                            {
                                student.Surname = splitName[i + 2];
                            }

                            if (rowDataList[i + 5].ToString().Equals(string.Empty))
                            {
                                student.KCPEResult = 0;
                            }
                            else
                            {
                                student.KCPEResult = Convert.ToInt32(rowDataList[i + 5]);
                            }

                            if (rowDataList[i + 6].ToString().Equals(string.Empty))
                            {
                                student.PhoneNumber = string.Empty;
                            }
                            else
                            {
                                student.PhoneNumber = rowDataList[i + 6].ToString();
                            }

                            if (rowDataList[i + 7].ToString().Equals(string.Empty))
                            {
                                student.Gender = string.Empty;
                            }
                            else
                            {
                                student.Gender = rowDataList[i + 7].ToString();
                            }

                            StudentClassModel studentClass = new StudentClassModel
                            {
                                ClassId = classModel.ClassId,
                                StudentNumber = student.StudentNumber
                            };

                            var response = await StudentService.AddExistingStudent(student);
                            if (response.StatusCode != HttpStatusCode.Created)
                            {
                                ShowFailAlert($"Failed to add student - {student.StudentNumber}!");
                                break;
                            }

                            var classResponse = await StudentClassService.AddStudentClass(studentClass);
                            if (classResponse.StatusCode != HttpStatusCode.Created)
                            {
                                ShowFailAlert($"Failed to add {student.StudentNumber}!");
                                break;
                            }
                            if( j == row.Count - 1)
                            {
                                loadFile = false;
                                ShowSuccessAlert($"Successfully added students");
                            }
                        }
                    }
                }
            }
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