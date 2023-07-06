using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ViewStudentsBase : ComponentBase
    {
        [Inject] public ISessionYearService SessionYearService { get; set; }
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public ClassModel SelectedClass { get; set; }
        public SessionYearModel SelectedStudentSchoolYear { get; set; }
        public FormModel SelectedStudentForm { get; set; }
        public StreamModel SelectedStudentStream { get; set; }
        public MudTable<StudentModel> mudTable;
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        public async Task<IEnumerable<SessionYearModel>> SelectedSessionYearSearch(string value)
        {
            return (await SessionYearService.GetSessionYears()).ToList();
        }
        public async Task<IEnumerable<FormModel>> SelectedFormSearch(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> SelectedStreamSearch(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async void FindClass()
        {
            SelectedClass = await ClassService.GetClassByForeignKeys(SelectedStudentForm.FormId, SelectedStudentStream.StreamId, SelectedStudentSchoolYear.SessionYearId);
            Students = (await StudentService.MapClassOnStudent(SelectedClass.ClassId));
            this.StateHasChanged();
        }
        public void RowClickEvent(TableRowClickEventArgs<StudentModel> tableRowClickEventArgs)
        {
            Navigation.NavigateTo($"/classdetails/{tableRowClickEventArgs.Item.StudentNumber}");
        }
    }
}
