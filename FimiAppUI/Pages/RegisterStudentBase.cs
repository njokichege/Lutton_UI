using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class RegisterStudentBase : ComponentBase
    {
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        public StudentModelFluentValidator StudentValidator { get; set; } = new StudentModelFluentValidator();
        public ParentModelFluentValidator ParentValidator { get; set; } = new ParentModelFluentValidator();
        public FormModel NewStudentForm { get; set; }
        public StreamModel NewStudentStream { get; set; }
        public DateTime newStudentDateOfBirth;
        public bool success;
        public string[] errors = { };
        public MudTextField<string> pwField1;
        public MudForm registerStudentForm;
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

            if (registerStudentForm.IsValid)
            {
                Snackbar.Add("Registration successful!");
            }
        }
    }
}