using ExcelDataReader;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using System.Text.Json;

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
        [Inject] public IStudentSubjectService StudentSubjectService { get; set; }
        [Inject] public ISubjectService SubjectService { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public IEnumerable<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
        public FileModelFluentValidator FileValidator { get; set; } = new FileModelFluentValidator();
        public StudentModelFluentValidator StudentValidator { get; set; } = new StudentModelFluentValidator();
        public ParentModelFluentValidator ParentValidator { get; set; } = new ParentModelFluentValidator();
        public StudentModel Student { get; set; } = new StudentModel();
        public ParentModel Parent { get; set; } = new ParentModel();
        public ParentModel ParentExists { get; set; }
        public FormModel NewStudentForm { get; set; }
        public StreamModel NewStudentStream { get; set; }
        public StudentModel InsertedStudent { get; set; }
        public string SelectedGender { get; set; }
        public string ContentText { get; set; }
        public string ButtonText { get; set; }
        public DialogOptions dialogOptions = new() { FullWidth = true };    
        public DateTime newStudentDateOfBirth;
        public MudForm registerStudentForm;
        public MudForm registerParentForm;
        public MudDialog registerDialog;
        public MudDialog parentExistsDialog;
        public bool visible;
        public bool parentExistsDialogVisible;
        public MudForm form;
        public FileModel model = new();
        public bool loadFile = false;
        protected override async Task OnInitializedAsync()
        {
            Subjects = await SubjectService.GetSubjects();
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
        public async Task AssignCompulsorySubjects(FormModel formModel, StudentModel studentModel)
        {
            List<StudentSubjectModel> studentSubjects = new List<StudentSubjectModel>();

            foreach (var subject in Subjects)
            {
                if (formModel.Form.Equals("1") || (formModel.Form.Equals("2")))
                {
                    var model = new StudentSubjectModel { Code = subject.Code, StudentNumber = studentModel.StudentNumber };
                    studentSubjects.Add(model);
                }
                else if (formModel.Form.Equals("3") || formModel.Form.Equals("4"))
                {
                    if (subject.Code == 1 || subject.Code == 2 || subject.Code == 101 || subject.Code == 102 || subject.Code == 121 || subject.Code == 233 || subject.Code == 313)
                    {
                        var model = new StudentSubjectModel { Code = subject.Code, StudentNumber = studentModel.StudentNumber };
                        studentSubjects.Add(model);
                    }
                }
            }
            foreach(var studentSubject in studentSubjects)
            {
                var response = await StudentSubjectService.AddStudentSubject(studentSubject);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    continue;
                }
                else
                {
                    Snackbar.Add("Failed to assign subjects to student", MudBlazor.Severity.Error);
                    break;
                }
            }
            await registerStudentForm.ResetAsync();
            await registerParentForm.ResetAsync();
            NewStudentForm = new FormModel();
            NewStudentStream = new StreamModel();
            Student = new StudentModel();
            Parent = new ParentModel();
        }
        public async Task DialogSubmit()
        {
            visible = false;

            await registerStudentForm.Validate();
            await registerParentForm.Validate();
            if (registerStudentForm.IsValid && registerParentForm.IsValid)
            {
                var studentResponse = await StudentService.AddStudent(Student);
                if (studentResponse.StatusCode == HttpStatusCode.Created)
                {
                    var stream = await studentResponse.Content.ReadAsStreamAsync();
                    InsertedStudent = await JsonSerializer.DeserializeAsync<StudentModel>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    var parentResponse = await ParentService.AddParent(Parent);
                    if (parentResponse.StatusCode == HttpStatusCode.Created)
                    {
                        var stream1 = await parentResponse.Content.ReadAsStreamAsync();
                        var parent = await JsonSerializer.DeserializeAsync<ParentModel>(stream1, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        var parentStudent = new ParentStudentModel
                        {
                            ParentId = parent.ParentId,
                            StudentNumber = InsertedStudent.StudentNumber
                        };

                        var parentStudentResponse = await ParentStudentService.AddParentStudent(parentStudent);
                        if (parentStudentResponse.StatusCode == HttpStatusCode.Created)
                        {
                            var classModel = await ClassService.GetClassByForeignKeys(NewStudentForm.FormId, NewStudentStream.StreamId, SchoolYear.SessionYearId);
                            var studentClass = new StudentClassModel
                            {
                                ClassId = classModel.ClassId,
                                StudentNumber = InsertedStudent.StudentNumber
                            };
                            var classResponse = await StudentClassService.AddStudentClass(studentClass);
                            if (classResponse.StatusCode == HttpStatusCode.Created)
                            {
                                Snackbar.Add($"Successfully added {Student.StudentName()}", MudBlazor.Severity.Success);
                                await AssignCompulsorySubjects(NewStudentForm,InsertedStudent);
                            }
                            else
                            {
                                Snackbar.Add("Failed to add student to class!", MudBlazor.Severity.Error);
                                await registerStudentForm.ResetAsync();
                                await registerParentForm.ResetAsync();
                                NewStudentForm = new FormModel();
                                NewStudentStream = new StreamModel();
                                Student = new StudentModel();
                                Parent = new ParentModel();
                            }
                        }
                        else
                        {
                            Snackbar.Add("Failed to link student to parent!", MudBlazor.Severity.Error);
                            await registerStudentForm.ResetAsync();
                            await registerParentForm.ResetAsync();
                            NewStudentForm = new FormModel();
                            NewStudentStream = new StreamModel();
                            Student = new StudentModel();
                            Parent = new ParentModel();
                        }
                    }
                    else if(parentResponse.StatusCode == HttpStatusCode.Conflict)
                    {
                        ParentExists = await ParentService.GetParentById(Parent.NationalId);

                        parentExistsDialogVisible = true;
                    }
                    else
                    {
                        Snackbar.Add("Failed to add parent!", MudBlazor.Severity.Error);
                        await registerStudentForm.ResetAsync();
                        await registerParentForm.ResetAsync();
                        NewStudentForm = new FormModel();
                        NewStudentStream = new StreamModel();
                        Student = new StudentModel();
                        Parent = new ParentModel();
                    }
                }
                else
                {
                    Snackbar.Add("Failed to add student!", MudBlazor.Severity.Error);
                    await registerStudentForm.ResetAsync();
                    await registerParentForm.ResetAsync();
                    NewStudentForm = new FormModel();
                    NewStudentStream = new StreamModel();
                    Student = new StudentModel();
                    Parent = new ParentModel();
                }
            }
        }
        public async Task RegisterWithExistingParent()
        {
            parentExistsDialogVisible = false;
            var parentStudent = new ParentStudentModel
            {
                ParentId = ParentExists.ParentId,
                StudentNumber = InsertedStudent.StudentNumber
            };
            var parentStudentResponse = await ParentStudentService.AddParentStudent(parentStudent);
            if (parentStudentResponse.StatusCode == HttpStatusCode.Created)
            {
                var classModel = await ClassService.GetClassByForeignKeys(NewStudentForm.FormId, NewStudentStream.StreamId, SchoolYear.SessionYearId);
                var studentClass = new StudentClassModel
                {
                    ClassId = classModel.ClassId,
                    StudentNumber = InsertedStudent.StudentNumber
                };
                var classResponse = await StudentClassService.AddStudentClass(studentClass);
                if (classResponse.StatusCode == HttpStatusCode.Created)
                {
                    Snackbar.Add($"Successfully added {Student.StudentName()}", MudBlazor.Severity.Success);
                    await AssignCompulsorySubjects(NewStudentForm, InsertedStudent);
                }
                else
                {
                    Snackbar.Add("Failed to add student to class!", MudBlazor.Severity.Error);
                    await registerStudentForm.ResetAsync();
                    await registerParentForm.ResetAsync();
                    NewStudentForm = new FormModel();
                    NewStudentStream = new StreamModel();
                    Student = new StudentModel();
                    Parent = new ParentModel();
                }
            }
            else
            {
                Snackbar.Add("Failed to link student to parent!", MudBlazor.Severity.Error);
                await registerStudentForm.ResetAsync();
                await registerParentForm.ResetAsync();
                NewStudentForm = new FormModel();
                NewStudentStream = new StreamModel();
                Student = new StudentModel();
                Parent = new ParentModel();
            }
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
                                UseHeaderRow = false
                            }
                        };
                        DataSet dataset = reader.AsDataSet(conf);
                        DataRowCollection row = dataset.Tables["Sheet1"].Rows;

                        ClassModel classModel = new ClassModel();

                        string formStream = string.Empty;
                        string form = string.Empty;

                        for(int j = 0 ; j < row.Count; j++)
                        {
                            List<object>  rowDataList = row[j].ItemArray.ToList();

                            int i = 0;
                            string name = rowDataList[i + 1].ToString();
                            string[] splitName = name.Split(null);
                            string currentForm = rowDataList[i + 2].ToString();
                            string currentFormStream = rowDataList[i + 3].ToString();


                            form = currentForm;
                            formStream = currentFormStream;

                            DateTime date = new DateTime(SchoolYear.StartDate.Year, 1, 1);

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
                            if (rowDataList[i + 4].ToString().Equals(string.Empty))
                            {
                                student.KCPEResult = 0;
                            }
                            else
                            {
                                student.KCPEResult = Convert.ToInt32(rowDataList[i + 4]);
                            }
                            if (rowDataList[i + 5].ToString().Equals(string.Empty))
                            {
                                student.Gender = string.Empty;
                            }
                            else
                            {
                                student.Gender = rowDataList[i + 5].ToString();
                            }

                            StudentClassModel studentClass = new StudentClassModel
                            {
                                ClassId = classModel.ClassId,
                                StudentNumber = student.StudentNumber
                            };

                            var response = await StudentService.AddExistingStudent(student);
                            if (response.StatusCode != HttpStatusCode.Created)
                            {
                                Snackbar.Add($"Failed to add {student.StudentNumber}!", MudBlazor.Severity.Error);
                                break;
                            }

                            var classResponse = await StudentClassService.AddStudentClass(studentClass);
                            if (classResponse.StatusCode != HttpStatusCode.Created)
                            {
                                Snackbar.Add($"Failed to add {student.StudentNumber}!", MudBlazor.Severity.Error);
                                break;
                            }
                            var formModel = new FormModel { Form = form };
                            await AssignCompulsorySubjects(formModel, student);

                            if ( j == row.Count - 1)
                            {
                                loadFile = false;
                                Snackbar.Add($"Successfully added students", MudBlazor.Severity.Success);
                            }
                        }
                    }
                }
            }
        }
        public void Cancel()
        {
            visible = false;
            parentExistsDialogVisible = false;
        }
    }
}