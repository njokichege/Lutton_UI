using Microsoft.AspNetCore.Mvc;

namespace FimiAppUI.Pages
{
    public class IndexBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ISessionYearService SessionYearService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public IParentService ParentService { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        public IEnumerable<StudentModel> AllStudents { get; set; }
        public IEnumerable<TeacherModel> AllTeachers { get; set; }
        public IEnumerable<ParentModel> AllParents { get; set; }
        public SessionYearModel SelectedRunningSession { get; set; }
        public string SessionYearModelTitle { get; set; }
        protected override async Task OnInitializedAsync()
        {
            AllStudents = (await StudentService.GetStudents()).ToList();
            AllTeachers = (await TeacherService.GetTeachers()).ToList();
            AllParents = (await ParentService.GetParents()).ToList();
            
            SessionYearModelTitle = SchoolYear.SessionString();
        }
        public async Task<IEnumerable<SessionYearModel>> SessionYearSearchOnRunningSession(string value)
        {
            return (await SessionYearService.GetSessionYears()).ToList();
        }
    }
}
