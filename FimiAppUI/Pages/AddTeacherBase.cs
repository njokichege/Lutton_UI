
namespace FimiAppUI.Pages
{
    public class AddTeacherBase : ComponentBase
    {
        public TeacherModelFluentValidator TeacherValidator { get; set; } = new TeacherModelFluentValidator();
        public StaffModelFluentValidator StaffValidator { get; set; } = new StaffModelFluentValidator();
        public TeacherModel Teacher { get; set; }
        public StaffModel Staff { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public MudForm registerTeacherForm;
        public MudForm registerStaffForm;
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        public void ShowSuccessAlert(string modelType)
        {
            ModelSuccess = modelType;
            showSuccessAlert = true;
        }
        public async Task Submit()
        {
            
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
