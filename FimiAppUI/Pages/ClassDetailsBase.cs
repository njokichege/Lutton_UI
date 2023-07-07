using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ClassDetailsBase: ComponentBase
    {
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Parameter] public string Id { get; set; }
        public ClassModel ClassSelected { get; set; } = new ClassModel();
        public IEnumerable<StudentModel> Students { get; set; } = new List<StudentModel>();
        public bool dataIsLoaded = false;
        protected async override Task OnInitializedAsync()
        {
            ClassSelected = await ClassService.GetClassById(int.Parse(Id));
            Students = await StudentService.MapClassOnStudent(int.Parse(Id));
            dataIsLoaded = true;
        }
    }
}
