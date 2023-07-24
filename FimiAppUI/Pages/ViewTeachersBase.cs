namespace FimiAppUI.Pages
{
    public class ViewTeachersBase : ComponentBase
    {
        [Inject] public ITeacherService TeacherService { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; } = new List<TeacherModel>();
        public TeacherModel SelectedTeacher { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Teachers = await TeacherService.MapStaffOnTeacher();                 
        }
    }
}
