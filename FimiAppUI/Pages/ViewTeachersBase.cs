namespace FimiAppUI.Pages
{
    public class ViewTeachersBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; } = new List<TeacherModel>();
        public TeacherModel SelectedTeacher { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Teachers = await TeacherService.MapStaffOnTeacher();                 
        }
        public void TeacherRowClickEvent(TableRowClickEventArgs<TeacherModel> tableRowClickEventArgs)
        {
            Navigation.NavigateTo("/teacherdetails/" + tableRowClickEventArgs.Item.TeacherId);
        }
    }
}
