
using System.Net;

namespace FimiAppUI.Pages
{
    public class RegisterTeacherBase : ComponentBase
    {
        [Inject] public ISubjectService SubjectService { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public IStaffService StaffService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public ITeacherSubjectService TeacherSubjectService { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public TeacherModelFluentValidator TeacherValidator { get; set; } = new TeacherModelFluentValidator();
        public StaffModelFluentValidator StaffValidator { get; set; } = new StaffModelFluentValidator();
        public TeacherModel Teacher { get; set; } = new TeacherModel();
        public StaffModel Staff { get; set; } = new StaffModel();
        public SubjectModel Subject { get; set; } = new SubjectModel();
        public SubjectModel FirstSubjectSpecialization { get; set; }
        public SubjectModel SecondSubjectSpecialization { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        public string ModelWarning { get; set; }
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public bool showWarningAlert = false;
        public MudForm registerTeacherForm;
        public MudForm registerStaffForm;
        public MudForm registerTeacherSubjectsForm;
        public MudDialog registerDialog;
        public DialogOptions dialogOptions = new() { FullWidth = true };  
        public bool visible;
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        public async Task<IEnumerable<SubjectModel>> SubjectSearch(string value)
        {
            return (await SubjectService.GetSubjects()).ToList();
        }
        public async Task Submit()
        {
            visible = true;
        }
        public async Task DialogSubmit()
        {
            visible = false;

            await registerStaffForm.Validate();
            await registerTeacherForm.Validate();
            if (registerStaffForm.IsValid && registerTeacherForm.IsValid)
            {
                var staffResponse = await StaffService.AddStaff(Staff);
                Teacher.Staff = Staff;
                var teacherResponse = await TeacherService.AddTeacher(Teacher);
                var firstTeacherSubject = new TeacherSubjectModel
                {
                    Code = FirstSubjectSpecialization.Code
                };
                var secondTeacherSubject = new TeacherSubjectModel
                {
                    Code = SecondSubjectSpecialization.Code
                };
                var firstSubjectResponse = await TeacherSubjectService.CreateTeacherSubject(firstTeacherSubject);
                var secondSubjectResponse = await TeacherSubjectService.CreateTeacherSubject(secondTeacherSubject);

                if (staffResponse.StatusCode == HttpStatusCode.OK && teacherResponse.StatusCode == HttpStatusCode.OK && firstSubjectResponse.StatusCode == HttpStatusCode.OK && secondSubjectResponse.StatusCode == HttpStatusCode.OK)
                {
                    ShowSuccessAlert($"{Teacher.Staff.FirstName} {Teacher.Staff.MiddleName} {Teacher.Staff.Surname} has been added");
                }
                else if (staffResponse.StatusCode == HttpStatusCode.Conflict || teacherResponse.StatusCode == HttpStatusCode.Conflict)
                {
                    ShowWarningAlert($"{Teacher.Staff.FirstName} {Teacher.Staff.MiddleName} {Teacher.Staff.Surname} already exists");
                }
                else
                {
                    ShowFailAlert($"Failed to add {Teacher.Staff.FirstName} {Teacher.Staff.MiddleName} {Teacher.Staff.Surname} as a teacher");
                }
            }
            registerStaffForm.ResetAsync();
            registerTeacherForm.ResetAsync();
            registerTeacherSubjectsForm.ResetAsync();
        }
        public void Cancel() => MudDialog.Cancel();
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
            }
            else
            {
                showSuccessAlert = false;
                showFailAlert = false;
            }
        }
    }
}
