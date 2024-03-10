namespace FimiAppUI.Pages
{
    public class ViewStudentsBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ISessionYearService SessionYearService { get; set; }
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public IEnumerable<StudentModel> AllStudents { get; set; } 
        public ClassModel SelectedClass { get; set; }
        public SessionYearModel SelectedStudentSchoolYear { get; set; }
        public FormModel SelectedStudentForm { get; set; }
        public StreamModel SelectedStudentStream { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        public StudentModel selectedStudent = null;
        public MudTable<StudentModel> mudTable;
        public bool visible = false;
        public bool visibleAllStudents = true;
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        protected override async Task OnInitializedAsync()
        {
            var date = DateTime.Now.Year;
            var currdate = new DateTime(date, 1, 1);

            try
            {
                var sessionId = await SessionYearService.GetSessionYearByStartDate(currdate.ToString("s"));
                AllStudents = (await StudentService.GetAllStudentsBySessionYear(sessionId)).ToList();
            }
            catch (Exception ex)
            {
                if (AllStudents is null)
                    ShowFailAlert("No student records found");
            }
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
            visibleAllStudents = false;
            visible = true;

            if (SelectedStudentForm is null || SelectedStudentStream is null || SelectedStudentSchoolYear is null)
                throw new ArgumentException("A stream, form and school year must be supplied");
            
            try
            {
                SelectedClass = await ClassService.GetClassByForeignKeys(SelectedStudentForm.FormId, SelectedStudentStream.StreamId, SelectedStudentSchoolYear.SessionYearId);
                Students = (await StudentService.MapClassOnStudent(SelectedClass.ClassId));
            }
            catch (Exception ex)
            {
                if (Students is null || SelectedClass is null)
                    ShowFailAlert("No student records found");
            }
            this.StateHasChanged();
        }
        public void StudentRowClickEvent(TableRowClickEventArgs<StudentModel> tableRowClickEventArgs)
        {
            Navigation.NavigateTo("/studentdetails/" + tableRowClickEventArgs.Item.StudentNumber);
        }
        public void Cancel() => visible = false;
        public void ShowSuccessAlert(string modelType)
        {
            ModelSuccess = modelType;
            showSuccessAlert = true;
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
