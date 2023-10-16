namespace FimiAppUI.Pages
{
    public class StudentDetailsBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public IStudentSubjectService SubjectService { get; set; }
        [Parameter] public string Id { get; set; }
        public List<StudentSubjectModel> Subjects { get; set; }
        public StudentModel Student { get; set; }
        public bool dataIsLoaded = false;
        protected override async Task OnInitializedAsync()
        {
            Student = await StudentService.GetStudentByStudentNumber(int.Parse(Id));
            dataIsLoaded = true;
            Subjects = await SubjectService.GetSubjectsByStudentNumber(int.Parse(Id));
        }
    }
}
