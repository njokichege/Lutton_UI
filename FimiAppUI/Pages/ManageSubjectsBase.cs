using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ManageSubjectsBase : ComponentBase
    {
        [Inject] public ISubjectService SubjectService { get; set; }
        [Inject] public ITeacherSubjectService TeacherSubjectService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        public IEnumerable<TeacherSubjectModel> TeacherSubjectModel { get; set; }
        public IEnumerable<TeacherSubjectModel> TeacherSubjects { get; set; } = new List<TeacherSubjectModel>();
        public TeacherSubjectModel SelectedTeacherSubjectModel { get; set; }
        public TeacherModel SelectedTeacherOnAssignTeacherTab { get; set; }
        public SubjectModel SelectedSubjectOnAssignTeacherTab { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        public string ModelWarning { get; set; }
        public bool fixed_header = true;
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public bool showWarningAlert = false;
        public bool showTeachersSubjects = false;
        private TeacherModel _selectedTeacherOnAssignTeacherTab;
        protected override async Task OnInitializedAsync()
        {
            TeacherSubjectModel = (await TeacherSubjectService.GetMultipleMapping()).ToList();
        }
        public async Task<IEnumerable<TeacherModel>> TeacherSearchOnAssignTeacherTab(string value)
        {
            return (await TeacherService.MapStaffOnTeacher()).ToList();
        }
        public async Task<IEnumerable<SubjectModel>> SubjectSearchOnAssignTeacherTab(string value)
        {
            return (await SubjectService.GetSubjects()).ToList();
        }
        public async Task AssignClassTeacher()
        {
            var teacherSubjectModel = new TeacherSubjectModel
            {
                TeacherId = SelectedTeacherOnAssignTeacherTab.TeacherId,
                Code = SelectedSubjectOnAssignTeacherTab.Code
            };
            var response = await TeacherSubjectService.CreateTeacherSubject(teacherSubjectModel);
            TeacherSubjects = (await TeacherSubjectService.GetMultipleMappingByTeacher(SelectedTeacherOnAssignTeacherTab.TeacherId)).ToList();
            showTeachersSubjects = true;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ShowSuccessAlert($"{SelectedTeacherOnAssignTeacherTab.Staff.FullName} has been set to teach {SelectedSubjectOnAssignTeacherTab.SubjectName}");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {

                ShowWarningAlert($"{SelectedTeacherOnAssignTeacherTab.Staff.FullName} is already set to teach {SelectedSubjectOnAssignTeacherTab.SubjectName}");
            }
            else
            {
                ShowFailAlert($"System failed to set {SelectedTeacherOnAssignTeacherTab.Staff.FullName} to teach {SelectedSubjectOnAssignTeacherTab.SubjectName}");
            }
        }
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
        public void ShowWarningAlert(string modelType)
        {
            ModelWarning = modelType;
            showWarningAlert = true;
        }
        public void CloseMe(bool value)
        {
            if (value)
            {
                showSuccessAlert = false;
                showFailAlert = false;
                showWarningAlert = false;
            }
            else
            {
                showSuccessAlert = false;
                showFailAlert = false;
                showWarningAlert = false;
            }
        }
    }
}
