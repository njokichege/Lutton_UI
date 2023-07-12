using Azure;
using System.Net;

namespace FimiAppUI.Pages
{
    public class RegisterStudentBase : ComponentBase
    {
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        public StudentModelFluentValidator StudentValidator { get; set; } = new StudentModelFluentValidator();
        public ParentModelFluentValidator ParentValidator { get; set; } = new ParentModelFluentValidator();
        public StudentModel Student { get; set; } = new StudentModel();
        public ParentModel Parent { get; set; } = new ParentModel();
        public FormModel NewStudentForm { get; set; }
        public StreamModel NewStudentStream { get; set; }
        public string SelectedGender { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        public DateTime newStudentDateOfBirth;
        public MudForm registerStudentForm;
        public MudForm registerParentForm;
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
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
            await registerStudentForm.Validate();
            //await registerParentForm.Validate();
            if (registerStudentForm.IsValid)
            {
                var studentResponse = await StudentService.AddStudent(Student);
                if (studentResponse.StatusCode == HttpStatusCode.Created)
                {
                    ShowSuccessAlert($"Student {Student.StudentName()} added!");
                }
                else
                {
                    ShowFailAlert($"Failed to add student!");
                }
            }
        }
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