namespace FimiAppUI.Pages
{
    public class StudentDetailsBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IStudentService StudentService { get; set; }
        [Parameter] public string Id { get; set; }
        public StudentModel Student { get; set; }
        public bool dataIsLoaded = false;
        protected override async Task OnInitializedAsync()
        {
            Student = await StudentService.GetStudentByStudentNumber(int.Parse(Id));
            dataIsLoaded = true;
        }
    }
}
