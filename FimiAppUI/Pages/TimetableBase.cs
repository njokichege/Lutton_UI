

namespace FimiAppUI.Pages
{
    public class TimetableBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ITimeSlotService TimeSlotService { get; set; }
        [Inject] public ISubjectService SubjectService { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public ITeacherSubjectService TeacherSubject { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public ITimetableService TimetableService { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public ClassModel SelectedClass { get; set; }
        public SubjectModel SelectedSubject { get; set; }
        public TimeSlotModel SelectedTimeSlot { get; set; }
        public TeacherSubjectModel TeacherAndSubject { get; set; }
        public IEnumerable<TeacherSubjectModel> TeacherSubjects { get; set; }
        public TeacherSubjectModel SelectedTeacherSubjectModel { get; set; }
        public MudDialog timetableDialog;
        public MudAutocomplete<ClassModel> classSelect;
        public MudAutocomplete<SubjectModel> subjectSelect;
        public MudAutocomplete<TimeSlotModel> timeslotSelect;
        public DialogOptions dialogOptions = new() { FullWidth = true };
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public bool isLoading = false;
        public bool visible;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
        }
        public async Task<IEnumerable<ClassModel>> SelectedClassSearch(string value)
        {
            return (await ClassService.GetMultipleMapping()).ToList();
        }
        public async Task<IEnumerable<SubjectModel>> SelectedSubjectSearch(string value)
        {
            return (await SubjectService.GetSubjects()).ToList().Where(x => 
            x.Code == 233 ||
            x.Code == 236 ||
            x.Code == 232 ||
            x.Code == 311 ||
            x.Code == 312 ||
            x.Code == 411 ||
            x.Code == 443
            );
        }
        public async Task<IEnumerable<TimeSlotModel>> SelectedTimeSlotSearch(string value)
        {
            return (await TimeSlotService.GetTimeSlots()).ToList();
        }
        public async Task FindClass()
        {
            isLoading = true;
            TeacherSubjects = await TeacherSubject.GetMultipleMappingBySubject(SelectedSubject.Code);
        }
        public void ClassRowClickEvent(TableRowClickEventArgs<TeacherSubjectModel> tableRowClickEventArgs)
        {
            visible = true;
            TeacherAndSubject = tableRowClickEventArgs.Item;
        }
        public void Cancel() => MudDialog.Cancel();
        public async Task DialogSubmit()
        {
            visible = false;
            TimetableModel timetableModel = new()
            {
                Subject = TeacherAndSubject.Subject,
                ClassModel= SelectedClass,
                TimeSlot = SelectedTimeSlot,
                Teacher = TeacherAndSubject.Teacher
            };
            var response = await TimetableService.AddTimetableEntry(timetableModel);
            
            if (response.StatusCode == HttpStatusCode.Created)
            {
                ShowSuccessAlert($"Timetable submission success!");
            }
            else
            {
                ShowFailAlert($"Timetable submission failed!");
            }
            await classSelect.ResetAsync();
            await subjectSelect.ResetAsync();
            await timeslotSelect.ResetAsync();
            TeacherSubjects = null;
            isLoading = false;
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
