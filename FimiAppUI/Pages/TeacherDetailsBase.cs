namespace FimiAppUI.Pages
{
    public class TeacherDetailsBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ITeacherService TeacherService { get; set; }
        [Parameter] public string Id { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public TeacherModel Teacher { get; set; }
        public bool dataIsLoaded = false;
        public bool showTscNumber = false;
        protected override async Task OnInitializedAsync()
        {
            Teachers = await TeacherService.MapStaffOnTeacherById(int.Parse(Id));
            Teacher = Teachers.FirstOrDefault();
            if (Teacher.TSCNumber != null)
            {
                showTscNumber = true;
            }
            dataIsLoaded = true;
        }
    }
}
