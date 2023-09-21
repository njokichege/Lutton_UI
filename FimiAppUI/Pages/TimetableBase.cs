

using FimiAppLibrary.Models;
using Grpc.Core;

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
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public ITeacherSubjectService TeacherSubjectService { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public IEnumerable<TeacherSubjectModel> TeacherSubjects { get; set; }
        public IEnumerable<TimetableModel> TimetableModels { get; set; }
        public ClassModel SelectedClass { get; set; }
        public SubjectModel SelectedSubject { get; set; }
        public TimeSlotModel SelectedTimeSlot { get; set; }
        public TeacherSubjectModel TeacherAndSubject { get; set; }
        public TeacherSubjectModel SelectedTeacherSubjectModel { get; set; }
        public MudDialog timetableDialog;
        public MudAutocomplete<ClassModel> classSelect;
        public MudAutocomplete<SubjectModel> subjectSelect;
        public MudAutocomplete<TimeSlotModel> timeslotSelect;
        public MudAutocomplete<string> daySelect;
        public DialogOptions dialogOptions = new() { FullWidth = true };
        private string[] daysOfTheWeek = {"Monday","Tuesday","Wednesday","Thursday","Friday"};
        public string ModelFail { get; set; }
        public string SelectedDay { get; set; }
        public string ModelSuccess { get; set; }
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public bool isLoading = false;
        public bool visible;
        public TimetableModel TM1K800_840_Monday { get; set; } 
        public TimetableModel TM1K840_920_Monday { get; set; }
        public TimetableModel TM1K930_1010_Monday { get; set; }
        public TimetableModel TM1K1010_1050_Monday { get; set; }
        public TimetableModel TM1K1120_1200_Monday { get; set; }
        public TimetableModel TM1K1200_1240_Monday { get; set; }
        public TimetableModel TM1K1240_120_Monday { get; set; }
        public TimetableModel TM1K200_240_Monday { get; set; }
        public TimetableModel TM1K240_320_Monday { get; set; }
        public TimetableModel TM1K320_400_Monday { get; set; }
        public TimetableModel TM1K800_840_Tuesday { get; set; }
        public TimetableModel TM1K840_920_Tuesday { get; set; }
        public TimetableModel TM1K930_1010_Tuesday { get; set; }
        public TimetableModel TM1K1010_1050_Tuesday { get; set; }
        public TimetableModel TM1K1120_1200_Tuesday { get; set; }
        public TimetableModel TM1K1200_1240_Tuesday { get; set; }
        public TimetableModel TM1K1240_120_Tuesday { get; set; }
        public TimetableModel TM1K200_240_Tuesday { get; set; }
        public TimetableModel TM1K240_320_Tuesday { get; set; }
        public TimetableModel TM1K320_400_Tuesday { get; set; }
        public TimetableModel TM1K800_840_Wednesday { get; set; }
        public TimetableModel TM1K840_920_Wednesday { get; set; }
        public TimetableModel TM1K930_1010_Wednesday { get; set; }
        public TimetableModel TM1K1010_1050_Wednesday { get; set; }
        public TimetableModel TM1K1120_1200_Wednesday { get; set; }
        public TimetableModel TM1K1200_1240_Wednesday { get; set; }
        public TimetableModel TM1K1240_120_Wednesday { get; set; }
        public TimetableModel TM1K200_240_Wednesday { get; set; }
        public TimetableModel TM1K240_320_Wednesday { get; set; }
        public TimetableModel TM1K320_400_Wednesday { get; set; }
        public TimetableModel TM1K800_840_Thursday { get; set; }
        public TimetableModel TM1K840_920_Thursday { get; set; }
        public TimetableModel TM1K930_1010_Thursday { get; set; }
        public TimetableModel TM1K1010_1050_Thursday { get; set; }
        public TimetableModel TM1K1120_1200_Thursday { get; set; }
        public TimetableModel TM1K1200_1240_Thursday { get; set; }
        public TimetableModel TM1K1240_120_Thursday { get; set; }
        public TimetableModel TM1K200_240_Thursday { get; set; }
        public TimetableModel TM1K240_320_Thursday { get; set; }
        public TimetableModel TM1K320_400_Thursday { get; set; }
        public TimetableModel TM1K800_840_Friday { get; set; }
        public TimetableModel TM1K840_920_Friday { get; set; }
        public TimetableModel TM1K930_1010_Friday { get; set; }
        public TimetableModel TM1K1010_1050_Friday { get; set; }
        public TimetableModel TM1K1120_1200_Friday { get; set; }
        public TimetableModel TM1K1200_1240_Friday { get; set; }
        public TimetableModel TM1K1240_120_Friday { get; set; }
        public TimetableModel TM1K200_240_Friday { get; set; }
        public TimetableModel TM1K240_320_Friday { get; set; }
        public TimetableModel TM1K320_400_Friday { get; set; }
        public TimetableModel TM1W800_840_Monday { get; set; }
        public TimetableModel TM1W840_920_Monday { get; set; }
        public TimetableModel TM1W930_1010_Monday { get; set; }
        public TimetableModel TM1W1010_1050_Monday { get; set; }
        public TimetableModel TM1W1120_1200_Monday { get; set; }
        public TimetableModel TM1W1200_1240_Monday { get; set; }
        public TimetableModel TM1W1240_120_Monday { get; set; }
        public TimetableModel TM1W200_240_Monday { get; set; }
        public TimetableModel TM1W240_320_Monday { get; set; }
        public TimetableModel TM1W320_400_Monday { get; set; }
        public TimetableModel TM1W800_840_Tuesday { get; set; }
        public TimetableModel TM1W840_920_Tuesday { get; set; }
        public TimetableModel TM1W930_1010_Tuesday { get; set; }
        public TimetableModel TM1W1010_1050_Tuesday { get; set; }
        public TimetableModel TM1W1120_1200_Tuesday { get; set; }
        public TimetableModel TM1W1200_1240_Tuesday { get; set; }
        public TimetableModel TM1W1240_120_Tuesday { get; set; }
        public TimetableModel TM1W200_240_Tuesday { get; set; }
        public TimetableModel TM1W240_320_Tuesday { get; set; }
        public TimetableModel TM1W320_400_Tuesday { get; set; }
        public TimetableModel TM1W800_840_Wednesday { get; set; }
        public TimetableModel TM1W840_920_Wednesday { get; set; }
        public TimetableModel TM1W930_1010_Wednesday { get; set; }
        public TimetableModel TM1W1010_1050_Wednesday { get; set; }
        public TimetableModel TM1W1120_1200_Wednesday { get; set; }
        public TimetableModel TM1W1200_1240_Wednesday { get; set; }
        public TimetableModel TM1W1240_120_Wednesday { get; set; }
        public TimetableModel TM1W200_240_Wednesday { get; set; }
        public TimetableModel TM1W240_320_Wednesday { get; set; }
        public TimetableModel TM1W320_400_Wednesday { get; set; }
        public TimetableModel TM1W800_840_Thursday { get; set; }
        public TimetableModel TM1W840_920_Thursday { get; set; }
        public TimetableModel TM1W930_1010_Thursday { get; set; }
        public TimetableModel TM1W1010_1050_Thursday { get; set; }
        public TimetableModel TM1W1120_1200_Thursday { get; set; }
        public TimetableModel TM1W1200_1240_Thursday { get; set; }
        public TimetableModel TM1W1240_120_Thursday { get; set; }
        public TimetableModel TM1W200_240_Thursday { get; set; }
        public TimetableModel TM1W240_320_Thursday { get; set; }
        public TimetableModel TM1W320_400_Thursday { get; set; }
        public TimetableModel TM1W800_840_Friday { get; set; }
        public TimetableModel TM1W840_920_Friday { get; set; }
        public TimetableModel TM1W930_1010_Friday { get; set; }
        public TimetableModel TM1W1010_1050_Friday { get; set; }
        public TimetableModel TM1W1120_1200_Friday { get; set; }
        public TimetableModel TM1W1200_1240_Friday { get; set; }
        public TimetableModel TM1W1240_120_Friday { get; set; }
        public TimetableModel TM1W200_240_Friday { get; set; }
        public TimetableModel TM1W240_320_Friday { get; set; }
        public TimetableModel TM1W320_400_Friday { get; set; }
        public TimetableModel TM2K800_840_Monday { get; set; }
        public TimetableModel TM2K840_920_Monday { get; set; }
        public TimetableModel TM2K930_1010_Monday { get; set; }
        public TimetableModel TM2K1010_1050_Monday { get; set; }
        public TimetableModel TM2K1120_1200_Monday { get; set; }
        public TimetableModel TM2K1200_1240_Monday { get; set; }
        public TimetableModel TM2K1240_120_Monday { get; set; }
        public TimetableModel TM2K200_240_Monday { get; set; }
        public TimetableModel TM2K240_320_Monday { get; set; }
        public TimetableModel TM2K320_400_Monday { get; set; }
        public TimetableModel TM2K800_840_Tuesday { get; set; }
        public TimetableModel TM2K840_920_Tuesday { get; set; }
        public TimetableModel TM2K930_1010_Tuesday { get; set; }
        public TimetableModel TM2K1010_1050_Tuesday { get; set; }
        public TimetableModel TM2K1120_1200_Tuesday { get; set; }
        public TimetableModel TM2K1200_1240_Tuesday { get; set; }
        public TimetableModel TM2K1240_120_Tuesday { get; set; }
        public TimetableModel TM2K200_240_Tuesday { get; set; }
        public TimetableModel TM2K240_320_Tuesday { get; set; }
        public TimetableModel TM2K320_400_Tuesday { get; set; }
        public TimetableModel TM2K800_840_Wednesday { get; set; }
        public TimetableModel TM2K840_920_Wednesday { get; set; }
        public TimetableModel TM2K930_1010_Wednesday { get; set; }
        public TimetableModel TM2K1010_1050_Wednesday { get; set; }
        public TimetableModel TM2K1120_1200_Wednesday { get; set; }
        public TimetableModel TM2K1200_1240_Wednesday { get; set; }
        public TimetableModel TM2K1240_120_Wednesday { get; set; }
        public TimetableModel TM2K200_240_Wednesday { get; set; }
        public TimetableModel TM2K240_320_Wednesday { get; set; }
        public TimetableModel TM2K320_400_Wednesday { get; set; }
        public TimetableModel TM2K800_840_Thursday { get; set; }
        public TimetableModel TM2K840_920_Thursday { get; set; }
        public TimetableModel TM2K930_1010_Thursday { get; set; }
        public TimetableModel TM2K1010_1050_Thursday { get; set; }
        public TimetableModel TM2K1120_1200_Thursday { get; set; }
        public TimetableModel TM2K1200_1240_Thursday { get; set; }
        public TimetableModel TM2K1240_120_Thursday { get; set; }
        public TimetableModel TM2K200_240_Thursday { get; set; }
        public TimetableModel TM2K240_320_Thursday { get; set; }
        public TimetableModel TM2K320_400_Thursday { get; set; }
        public TimetableModel TM2K800_840_Friday { get; set; }
        public TimetableModel TM2K840_920_Friday { get; set; }
        public TimetableModel TM2K930_1010_Friday { get; set; }
        public TimetableModel TM2K1010_1050_Friday { get; set; }
        public TimetableModel TM2K1120_1200_Friday { get; set; }
        public TimetableModel TM2K1200_1240_Friday { get; set; }
        public TimetableModel TM2K1240_120_Friday { get; set; }
        public TimetableModel TM2K200_240_Friday { get; set; }
        public TimetableModel TM2K240_320_Friday { get; set; }
        public TimetableModel TM2K320_400_Friday { get; set; }
        public TimetableModel TM2W800_840_Monday { get; set; }
        public TimetableModel TM2W840_920_Monday { get; set; }
        public TimetableModel TM2W930_1010_Monday { get; set; }
        public TimetableModel TM2W1010_1050_Monday { get; set; }
        public TimetableModel TM2W1120_1200_Monday { get; set; }
        public TimetableModel TM2W1200_1240_Monday { get; set; }
        public TimetableModel TM2W1240_120_Monday { get; set; }
        public TimetableModel TM2W200_240_Monday { get; set; }
        public TimetableModel TM2W240_320_Monday { get; set; }
        public TimetableModel TM2W320_400_Monday { get; set; }
        public TimetableModel TM2W800_840_Tuesday { get; set; }
        public TimetableModel TM2W840_920_Tuesday { get; set; }
        public TimetableModel TM2W930_1010_Tuesday { get; set; }
        public TimetableModel TM2W1010_1050_Tuesday { get; set; }
        public TimetableModel TM2W1120_1200_Tuesday { get; set; }
        public TimetableModel TM2W1200_1240_Tuesday { get; set; }
        public TimetableModel TM2W1240_120_Tuesday { get; set; }
        public TimetableModel TM2W200_240_Tuesday { get; set; }
        public TimetableModel TM2W240_320_Tuesday { get; set; }
        public TimetableModel TM2W320_400_Tuesday { get; set; }
        public TimetableModel TM2W800_840_Wednesday { get; set; }
        public TimetableModel TM2W840_920_Wednesday { get; set; }
        public TimetableModel TM2W930_1010_Wednesday { get; set; }
        public TimetableModel TM2W1010_1050_Wednesday { get; set; }
        public TimetableModel TM2W1120_1200_Wednesday { get; set; }
        public TimetableModel TM2W1200_1240_Wednesday { get; set; }
        public TimetableModel TM2W1240_120_Wednesday { get; set; }
        public TimetableModel TM2W200_240_Wednesday { get; set; }
        public TimetableModel TM2W240_320_Wednesday { get; set; }
        public TimetableModel TM2W320_400_Wednesday { get; set; }
        public TimetableModel TM2W800_840_Thursday { get; set; }
        public TimetableModel TM2W840_920_Thursday { get; set; }
        public TimetableModel TM2W930_1010_Thursday { get; set; }
        public TimetableModel TM2W1010_1050_Thursday { get; set; }
        public TimetableModel TM2W1120_1200_Thursday { get; set; }
        public TimetableModel TM2W1200_1240_Thursday { get; set; }
        public TimetableModel TM2W1240_120_Thursday { get; set; }
        public TimetableModel TM2W200_240_Thursday { get; set; }
        public TimetableModel TM2W240_320_Thursday { get; set; }
        public TimetableModel TM2W320_400_Thursday { get; set; }
        public TimetableModel TM2W800_840_Friday { get; set; }
        public TimetableModel TM2W840_920_Friday { get; set; }
        public TimetableModel TM2W930_1010_Friday { get; set; }
        public TimetableModel TM2W1010_1050_Friday { get; set; }
        public TimetableModel TM2W1120_1200_Friday { get; set; }
        public TimetableModel TM2W1200_1240_Friday { get; set; }
        public TimetableModel TM2W1240_120_Friday { get; set; }
        public TimetableModel TM2W200_240_Friday { get; set; }
        public TimetableModel TM2W240_320_Friday { get; set; }
        public TimetableModel TM2W320_400_Friday { get; set; }
        public TimetableModel TM3K800_840_Monday { get; set; }
        public TimetableModel TM3K840_920_Monday { get; set; }
        public TimetableModel TM3K930_1010_Monday { get; set; }
        public TimetableModel TM3K1010_1050_Monday { get; set; }
        public TimetableModel TM3K1120_1200_Monday { get; set; }
        public TimetableModel TM3K1200_1240_Monday { get; set; }
        public TimetableModel TM3K1240_120_Monday { get; set; }
        public TimetableModel TM3K200_240_Monday { get; set; }
        public TimetableModel TM3K240_320_Monday { get; set; }
        public TimetableModel TM3K320_400_Monday { get; set; }
        public TimetableModel TM3K800_840_Tuesday { get; set; }
        public TimetableModel TM3K840_920_Tuesday { get; set; }
        public TimetableModel TM3K930_1010_Tuesday { get; set; }
        public TimetableModel TM3K1010_1050_Tuesday { get; set; }
        public TimetableModel TM3K1120_1200_Tuesday { get; set; }
        public TimetableModel TM3K1200_1240_Tuesday { get; set; }
        public TimetableModel TM3K1240_120_Tuesday { get; set; }
        public TimetableModel TM3K200_240_Tuesday { get; set; }
        public TimetableModel TM3K240_320_Tuesday { get; set; }
        public TimetableModel TM3K320_400_Tuesday { get; set; }
        public TimetableModel TM3K800_840_Wednesday { get; set; }
        public TimetableModel TM3K840_920_Wednesday { get; set; }
        public TimetableModel TM3K930_1010_Wednesday { get; set; }
        public TimetableModel TM3K1010_1050_Wednesday { get; set; }
        public TimetableModel TM3K1120_1200_Wednesday { get; set; }
        public TimetableModel TM3K1200_1240_Wednesday { get; set; }
        public TimetableModel TM3K1240_120_Wednesday { get; set; }
        public TimetableModel TM3K200_240_Wednesday { get; set; }
        public TimetableModel TM3K240_320_Wednesday { get; set; }
        public TimetableModel TM3K320_400_Wednesday { get; set; }
        public TimetableModel TM3K800_840_Thursday { get; set; }
        public TimetableModel TM3K840_920_Thursday { get; set; }
        public TimetableModel TM3K930_1010_Thursday { get; set; }
        public TimetableModel TM3K1010_1050_Thursday { get; set; }
        public TimetableModel TM3K1120_1200_Thursday { get; set; }
        public TimetableModel TM3K1200_1240_Thursday { get; set; }
        public TimetableModel TM3K1240_120_Thursday { get; set; }
        public TimetableModel TM3K200_240_Thursday { get; set; }
        public TimetableModel TM3K240_320_Thursday { get; set; }
        public TimetableModel TM3K320_400_Thursday { get; set; }
        public TimetableModel TM3K800_840_Friday { get; set; }
        public TimetableModel TM3K840_920_Friday { get; set; }
        public TimetableModel TM3K930_1010_Friday { get; set; }
        public TimetableModel TM3K1010_1050_Friday { get; set; }
        public TimetableModel TM3K1120_1200_Friday { get; set; }
        public TimetableModel TM3K1200_1240_Friday { get; set; }
        public TimetableModel TM3K1240_120_Friday { get; set; }
        public TimetableModel TM3K200_240_Friday { get; set; }
        public TimetableModel TM3K240_320_Friday { get; set; }
        public TimetableModel TM3K320_400_Friday { get; set; }
        public TimetableModel TM3W800_840_Monday { get; set; }
        public TimetableModel TM3W840_920_Monday { get; set; }
        public TimetableModel TM3W930_1010_Monday { get; set; }
        public TimetableModel TM3W1010_1050_Monday { get; set; }
        public TimetableModel TM3W1120_1200_Monday { get; set; }
        public TimetableModel TM3W1200_1240_Monday { get; set; }
        public TimetableModel TM3W1240_120_Monday { get; set; }
        public TimetableModel TM3W200_240_Monday { get; set; }
        public TimetableModel TM3W240_320_Monday { get; set; }
        public TimetableModel TM3W320_400_Monday { get; set; }
        public TimetableModel TM3W800_840_Tuesday { get; set; }
        public TimetableModel TM3W840_920_Tuesday { get; set; }
        public TimetableModel TM3W930_1010_Tuesday { get; set; }
        public TimetableModel TM3W1010_1050_Tuesday { get; set; }
        public TimetableModel TM3W1120_1200_Tuesday { get; set; }
        public TimetableModel TM3W1200_1240_Tuesday { get; set; }
        public TimetableModel TM3W1240_120_Tuesday { get; set; }
        public TimetableModel TM3W200_240_Tuesday { get; set; }
        public TimetableModel TM3W240_320_Tuesday { get; set; }
        public TimetableModel TM3W320_400_Tuesday { get; set; }
        public TimetableModel TM3W800_840_Wednesday { get; set; }
        public TimetableModel TM3W840_920_Wednesday { get; set; }
        public TimetableModel TM3W930_1010_Wednesday { get; set; }
        public TimetableModel TM3W1010_1050_Wednesday { get; set; }
        public TimetableModel TM3W1120_1200_Wednesday { get; set; }
        public TimetableModel TM3W1200_1240_Wednesday { get; set; }
        public TimetableModel TM3W1240_120_Wednesday { get; set; }
        public TimetableModel TM3W200_240_Wednesday { get; set; }
        public TimetableModel TM3W240_320_Wednesday { get; set; }
        public TimetableModel TM3W320_400_Wednesday { get; set; }
        public TimetableModel TM3W800_840_Thursday { get; set; }
        public TimetableModel TM3W840_920_Thursday { get; set; }
        public TimetableModel TM3W930_1010_Thursday { get; set; }
        public TimetableModel TM3W1010_1050_Thursday { get; set; }
        public TimetableModel TM3W1120_1200_Thursday { get; set; }
        public TimetableModel TM3W1200_1240_Thursday { get; set; }
        public TimetableModel TM3W1240_120_Thursday { get; set; }
        public TimetableModel TM3W200_240_Thursday { get; set; }
        public TimetableModel TM3W240_320_Thursday { get; set; }
        public TimetableModel TM3W320_400_Thursday { get; set; }
        public TimetableModel TM3W800_840_Friday { get; set; }
        public TimetableModel TM3W840_920_Friday { get; set; }
        public TimetableModel TM3W930_1010_Friday { get; set; }
        public TimetableModel TM3W1010_1050_Friday { get; set; }
        public TimetableModel TM3W1120_1200_Friday { get; set; }
        public TimetableModel TM3W1200_1240_Friday { get; set; }
        public TimetableModel TM3W1240_120_Friday { get; set; }
        public TimetableModel TM3W200_240_Friday { get; set; }
        public TimetableModel TM3W240_320_Friday { get; set; }
        public TimetableModel TM3W320_400_Friday { get; set; }
        public TimetableModel TM4K800_840_Monday { get; set; }
        public TimetableModel TM4K840_920_Monday { get; set; }
        public TimetableModel TM4K930_1010_Monday { get; set; }
        public TimetableModel TM4K1010_1050_Monday { get; set; }
        public TimetableModel TM4K1120_1200_Monday { get; set; }
        public TimetableModel TM4K1200_1240_Monday { get; set; }
        public TimetableModel TM4K1240_120_Monday { get; set; }
        public TimetableModel TM4K200_240_Monday { get; set; }
        public TimetableModel TM4K240_320_Monday { get; set; }
        public TimetableModel TM4K320_400_Monday { get; set; }
        public TimetableModel TM4K800_840_Tuesday { get; set; }
        public TimetableModel TM4K840_920_Tuesday { get; set; }
        public TimetableModel TM4K930_1010_Tuesday { get; set; }
        public TimetableModel TM4K1010_1050_Tuesday { get; set; }
        public TimetableModel TM4K1120_1200_Tuesday { get; set; }
        public TimetableModel TM4K1200_1240_Tuesday { get; set; }
        public TimetableModel TM4K1240_120_Tuesday { get; set; }
        public TimetableModel TM4K200_240_Tuesday { get; set; }
        public TimetableModel TM4K240_320_Tuesday { get; set; }
        public TimetableModel TM4K320_400_Tuesday { get; set; }
        public TimetableModel TM4K800_840_Wednesday { get; set; }
        public TimetableModel TM4K840_920_Wednesday { get; set; }
        public TimetableModel TM4K930_1010_Wednesday { get; set; }
        public TimetableModel TM4K1010_1050_Wednesday { get; set; }
        public TimetableModel TM4K1120_1200_Wednesday { get; set; }
        public TimetableModel TM4K1200_1240_Wednesday { get; set; }
        public TimetableModel TM4K1240_120_Wednesday { get; set; }
        public TimetableModel TM4K200_240_Wednesday { get; set; }
        public TimetableModel TM4K240_320_Wednesday { get; set; }
        public TimetableModel TM4K320_400_Wednesday { get; set; }
        public TimetableModel TM4K800_840_Thursday { get; set; }
        public TimetableModel TM4K840_920_Thursday { get; set; }
        public TimetableModel TM4K930_1010_Thursday { get; set; }
        public TimetableModel TM4K1010_1050_Thursday { get; set; }
        public TimetableModel TM4K1120_1200_Thursday { get; set; }
        public TimetableModel TM4K1200_1240_Thursday { get; set; }
        public TimetableModel TM4K1240_120_Thursday { get; set; }
        public TimetableModel TM4K200_240_Thursday { get; set; }
        public TimetableModel TM4K240_320_Thursday { get; set; }
        public TimetableModel TM4K320_400_Thursday { get; set; }
        public TimetableModel TM4K800_840_Friday { get; set; }
        public TimetableModel TM4K840_920_Friday { get; set; }
        public TimetableModel TM4K930_1010_Friday { get; set; }
        public TimetableModel TM4K1010_1050_Friday { get; set; }
        public TimetableModel TM4K1120_1200_Friday { get; set; }
        public TimetableModel TM4K1200_1240_Friday { get; set; }
        public TimetableModel TM4K1240_120_Friday { get; set; }
        public TimetableModel TM4K200_240_Friday { get; set; }
        public TimetableModel TM4K240_320_Friday { get; set; }
        public TimetableModel TM4K320_400_Friday { get; set; }
        public TimetableModel TM4W800_840_Monday { get; set; }
        public TimetableModel TM4W840_920_Monday { get; set; }
        public TimetableModel TM4W930_1010_Monday { get; set; }
        public TimetableModel TM4W1010_1050_Monday { get; set; }
        public TimetableModel TM4W1120_1200_Monday { get; set; }
        public TimetableModel TM4W1200_1240_Monday { get; set; }
        public TimetableModel TM4W1240_120_Monday { get; set; }
        public TimetableModel TM4W200_240_Monday { get; set; }
        public TimetableModel TM4W240_320_Monday { get; set; }
        public TimetableModel TM4W320_400_Monday { get; set; }
        public TimetableModel TM4W800_840_Tuesday { get; set; }
        public TimetableModel TM4W840_920_Tuesday { get; set; }
        public TimetableModel TM4W930_1010_Tuesday { get; set; }
        public TimetableModel TM4W1010_1050_Tuesday { get; set; }
        public TimetableModel TM4W1120_1200_Tuesday { get; set; }
        public TimetableModel TM4W1200_1240_Tuesday { get; set; }
        public TimetableModel TM4W1240_120_Tuesday { get; set; }
        public TimetableModel TM4W200_240_Tuesday { get; set; }
        public TimetableModel TM4W240_320_Tuesday { get; set; }
        public TimetableModel TM4W320_400_Tuesday { get; set; }
        public TimetableModel TM4W800_840_Wednesday { get; set; }
        public TimetableModel TM4W840_920_Wednesday { get; set; }
        public TimetableModel TM4W930_1010_Wednesday { get; set; }
        public TimetableModel TM4W1010_1050_Wednesday { get; set; }
        public TimetableModel TM4W1120_1200_Wednesday { get; set; }
        public TimetableModel TM4W1200_1240_Wednesday { get; set; }
        public TimetableModel TM4W1240_120_Wednesday { get; set; }
        public TimetableModel TM4W200_240_Wednesday { get; set; }
        public TimetableModel TM4W240_320_Wednesday { get; set; }
        public TimetableModel TM4W320_400_Wednesday { get; set; }
        public TimetableModel TM4W800_840_Thursday { get; set; }
        public TimetableModel TM4W840_920_Thursday { get; set; }
        public TimetableModel TM4W930_1010_Thursday { get; set; }
        public TimetableModel TM4W1010_1050_Thursday { get; set; }
        public TimetableModel TM4W1120_1200_Thursday { get; set; }
        public TimetableModel TM4W1200_1240_Thursday { get; set; }
        public TimetableModel TM4W1240_120_Thursday { get; set; }
        public TimetableModel TM4W200_240_Thursday { get; set; }
        public TimetableModel TM4W240_320_Thursday { get; set; }
        public TimetableModel TM4W320_400_Thursday { get; set; }
        public TimetableModel TM4W800_840_Friday { get; set; }
        public TimetableModel TM4W840_920_Friday { get; set; }
        public TimetableModel TM4W930_1010_Friday { get; set; }
        public TimetableModel TM4W1010_1050_Friday { get; set; }
        public TimetableModel TM4W1120_1200_Friday { get; set; }
        public TimetableModel TM4W1200_1240_Friday { get; set; }
        public TimetableModel TM4W1240_120_Friday { get; set; }
        public TimetableModel TM4W200_240_Friday { get; set; }
        public TimetableModel TM4W240_320_Friday { get; set; }
        public TimetableModel TM4W320_400_Friday { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetTimetableData();
        }
        public async Task<IEnumerable<string>> DaySearch(string value)
        {
            return daysOfTheWeek;
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
        public void Cancel() => visible = false;
        public async Task DialogSubmit()
        {
            visible = false;
            TimetableModel timetableModel = new()
            {
                Subject = TeacherAndSubject.Subject,
                ClassModel= SelectedClass,
                TimeSlot = SelectedTimeSlot,
                Teacher = TeacherAndSubject.Teacher,
                DayOfTheWeek = SelectedDay
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
            await daySelect.ResetAsync();

            TeacherSubjects = null;
            isLoading = false;
            SelectedClass = null;
            SelectedSubject = null;
            SelectedTimeSlot = null;
            SelectedDay = null;

            await GetTimetableData();
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
        public async Task GenerateTimetable()
        {
            var classes = await ClassService.GetMultipleMapping();
            var subjects = await SubjectService.GetSubjects();
            var teacherSubjects = await TeacherSubjectService.GetMultipleMapping();
            
            List<SubjectModel> doublesLessons = new List<SubjectModel> 
            { 
                subjects.First(x => x.Code == 236),
                subjects.First(x => x.Code == 233),
                subjects.First(x => x.Code == 312),
                subjects.First(x => x.Code == 311),
                subjects.First(x => x.Code == 443),
                subjects.First(x => x.Code == 565),
                subjects.First(x => x.Code == 411),
                subjects.First(x => x.Code == 232)
            };
            foreach(var cl in classes)
            {
                if(cl.Form.Form.Equals("4") || cl.Form.Form.Equals("3"))
                {
                    GenerateDoubleLesson(doublesLessons, cl, teacherSubjects);
                }
            }
        }
        public async Task GenerateDoubleLesson(List<SubjectModel> subjects, ClassModel classModel,IEnumerable<TeacherSubjectModel> teacherSubjects)
        {
            var timeslots = await TimeSlotService.GetTimeSlots();
            List<string> days = new List<string>{ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            TimetableModel firstDoubleLesson = new() { ClassModel = classModel,};
            TimetableModel secondDoubleLesson = new() { ClassModel = classModel};
            var teachers = await TeacherService.GetTeachers();

            var doubleLessons = new List<DoubleLessonModel>
            {
                new DoubleLessonModel {DoubleLessonId = 1, FirstSlot = timeslots.First(x => x.StartTime == "8:00"), SecondSlot = timeslots.First(x => x.StartTime == "8:40")},
                new DoubleLessonModel {DoubleLessonId = 2, FirstSlot = timeslots.First(x => x.StartTime == "9:30"), SecondSlot = timeslots.First(x => x.StartTime == "10:10")},
                new DoubleLessonModel {DoubleLessonId = 3, FirstSlot = timeslots.First(x => x.StartTime == "11:20"), SecondSlot = timeslots.First(x => x.StartTime == "12:00")},
                new DoubleLessonModel {DoubleLessonId = 4, FirstSlot = timeslots.First(x => x.StartTime == "12:00"), SecondSlot = timeslots.First(x => x.StartTime == "12:40")},
                new DoubleLessonModel {DoubleLessonId = 5, FirstSlot = timeslots.First(x => x.StartTime == "2:00"), SecondSlot = timeslots.First(x => x.StartTime == "2:40")},
                new DoubleLessonModel {DoubleLessonId = 6, FirstSlot = timeslots.First(x => x.StartTime == "2:40"), SecondSlot = timeslots.First(x => x.StartTime == "3:20")}
            };

            foreach(var subject in subjects)
            {
                var teachersub = teacherSubjects.First(x => x.Code == subject.Code);
                var teacher = teachers.First(x => x.TeacherId == teachersub.TeacherId);

                var ranDay = new Random();
                var listIndex = ranDay.Next(days.Count + 1);
                for (int j = 0; j <= days.Count; j++)
                {
                    if (j == listIndex)
                    {
                        firstDoubleLesson.DayOfTheWeek = days[j];
                        secondDoubleLesson.DayOfTheWeek = days[j];
                        days.RemoveAt(j);
                        break;
                    }
                }

                var ran = new Random();
                var listIndex2 = ran.Next(1, 7);
                for (int i = 0; i <= doubleLessons.Count; i++)
                {
                    if (i == listIndex2)
                    {
                        firstDoubleLesson.TimeSlot = doubleLessons[i].FirstSlot;
                        secondDoubleLesson.TimeSlot = doubleLessons[i].SecondSlot;
                        doubleLessons.RemoveAt(i);
                        break;
                    }
                }
                firstDoubleLesson.Subject = subject;
                secondDoubleLesson.Subject = subject;
                firstDoubleLesson.Teacher = teacher;
                secondDoubleLesson.Teacher = teacher;

                var firstDoubleLessonResponse = await TimetableService.AddTimetableEntry(firstDoubleLesson);
                var secondDoubleLessonResponse = await TimetableService.AddTimetableEntry(secondDoubleLesson);

                if (firstDoubleLessonResponse.StatusCode == HttpStatusCode.Created && secondDoubleLessonResponse.StatusCode == HttpStatusCode.Created)
                {
                    continue;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        private async Task GetTimetableData()
        {
            TimetableModels = await TimetableService.GetTimetableModels();
            foreach (var model in TimetableModels)
            {
                //------------------------------------------ Monday ---------------------------------------------------//
                //---------1K-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1K800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1K840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1K930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1K1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1K1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1K1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1K1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1K200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1K240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1K320_400_Monday = model;
                        continue;
                    }
                }
                //---------1W-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1W800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1W840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1W930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1W1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1W1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1W1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1W1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1W200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1W240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1W320_400_Monday = model;
                        continue;
                    }
                }
                //---------2K-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2K800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2K840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2K930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2K1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2K1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2K1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2K1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2K200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2K240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2K320_400_Monday = model;
                        continue;
                    }
                }
                //---------2W-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2W800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2W840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2W930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2W1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2W1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2W1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2W1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2W200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2W240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2W320_400_Monday = model;
                        continue;
                    }
                }
                //---------3K-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3K800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3K840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3K930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3K1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3K1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3K1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3K1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3K200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3K240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3K320_400_Monday = model;
                        continue;
                    }
                }
                //---------3W-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3W800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3W840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3W930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3W1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3W1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3W1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3W1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3W200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3W240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3W320_400_Monday = model;
                        continue;
                    }
                }
                //---------4K-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4K800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4K840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4K930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4K1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4K1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4K1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4K1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4K200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4K240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4K320_400_Monday = model;
                        continue;
                    }
                }
                //---------4W-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4W800_840_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4W840_920_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4W930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4W1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4W1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4W1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4W1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4W200_240_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4W240_320_Monday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4W320_400_Monday = model;
                        continue;
                    }
                }
                //------------------------------------------ Tuesday ---------------------------------------------------//
                //---------1K-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1K800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1K840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1K930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1K1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1K1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1K1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1K1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1K200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1K240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1K320_400_Tuesday = model;
                        continue;
                    }
                }
                //---------1W-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1W800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1W840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1W930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1W1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1W1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1W1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1W1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1W200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1W240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1W320_400_Tuesday = model;
                        continue;
                    }
                }
                //---------2K-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2K800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2K840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2K930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2K1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2K1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2K1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2K1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2K200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2K240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2K320_400_Tuesday = model;
                        continue;
                    }
                }
                //---------2W-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2W800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2W840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2W930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2W1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2W1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2W1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2W1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2W200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2W240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2W320_400_Tuesday = model;
                        continue;
                    }
                }
                //---------3K-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3K800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3K840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3K930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3K1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3K1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3K1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3K1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3K200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3K240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3K320_400_Tuesday = model;
                        continue;
                    }
                }
                //---------3W-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3W800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3W840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3W930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3W1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3W1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3W1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3W1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3W200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3W240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3W320_400_Tuesday = model;
                        continue;
                    }
                }
                //---------4K-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4K800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4K840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4K930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4K1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4K1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4K1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4K1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4K200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4K240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4K320_400_Tuesday = model;
                        continue;
                    }
                }
                //---------4W-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4W800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4W840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4W930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4W1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4W1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4W1200_1240_Tuesday = model; 
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4W1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4W200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4W240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4W320_400_Tuesday = model;
                        continue;
                    }
                }
                //-------------------------------------------Wednesday ---------------------------------------------------//
                //---------1K-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1K800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1K840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1K930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1K1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1K1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1K1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1K1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1K200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1K240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1K320_400_Wednesday = model;
                        continue;
                    }
                }
                //---------1W-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1W800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1W840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1W930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1W1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1W1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1W1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1W1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1W200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1W240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1W320_400_Wednesday = model;
                        continue;
                    }
                }
                //---------2K-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2K800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2K840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2K930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2K1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2K1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2K1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2K1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2K200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2K240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2K320_400_Wednesday = model;
                        continue;
                    }
                }
                //---------2W-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2W800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2W840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2W930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2W1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2W1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2W1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2W1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2W200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2W240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2W320_400_Wednesday = model;
                        continue;
                    }
                }
                //---------3K-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3K800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3K840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3K930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3K1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3K1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3K1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3K1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3K200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3K240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3K320_400_Wednesday = model;
                        continue;
                    }
                }
                //---------3W-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3W800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3W840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3W930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3W1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3W1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3W1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3W1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3W200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3W240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3W320_400_Wednesday = model;
                        continue;
                    }
                }
                //---------4K-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4K800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4K840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4K930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4K1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4K1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4K1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4K1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4K200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4K240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4K320_400_Wednesday = model;
                        continue;
                    }
                }
                //---------4W-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4W800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4W840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4W930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4W1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4W1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4W1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4W1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4W200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4W240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4W320_400_Wednesday = model;
                        continue;
                    }
                }
                //------------------------------------------ Thursday ---------------------------------------------------//
                //---------1K-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1K800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1K840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1K930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1K1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1K1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1K1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1K1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1K200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1K240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1K320_400_Thursday = model;
                        continue;
                    }
                }
                //---------1W-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1W800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1W840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1W930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1W1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1W1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1W1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1W1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1W200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1W240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1W320_400_Thursday = model;
                        continue;
                    }
                }
                //---------2K-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2K800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2K840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2K930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2K1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2K1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2K1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2K1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2K200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2K240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2K320_400_Thursday = model;
                        continue;
                    }
                }
                //---------2W-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2W800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2W840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2W930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2W1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2W1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2W1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2W1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2W200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2W240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2W320_400_Thursday = model;
                        continue;
                    }
                }
                //---------3K-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3K800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3K840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3K930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3K1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3K1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3K1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3K1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3K200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3K240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3K320_400_Thursday = model;
                        continue;
                    }
                }
                //---------3W-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3W800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3W840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3W930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3W1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3W1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3W1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3W1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3W200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3W240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3W320_400_Thursday = model;
                        continue;
                    }
                }
                //---------4K-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4K800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4K840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4K930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4K1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4K1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4K1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4K1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4K200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4K240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4K320_400_Thursday = model;
                        continue;
                    }
                }
                //---------4W-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4W800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4W840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4W930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4W1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4W1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4W1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4W1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4W200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4W240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4W320_400_Thursday = model;
                        continue;
                    }
                }
                //------------------------------------------Friday ---------------------------------------------------//
                //---------1K-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1K800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1K840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1K930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1K1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1K1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1K1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1K1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1K200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1K240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1K320_400_Friday = model;
                        continue;
                    }
                }
                //---------1W-----------//
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM1W800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM1W840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM1W930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1W1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1W1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1W1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1W1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM1W200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM1W240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("1") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM1W320_400_Friday = model;
                        continue;
                    }
                }
                //---------2K-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2K800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2K840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2K930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2K1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2K1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2K1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2K1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2K200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2K240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2K320_400_Friday = model;
                        continue;
                    }
                }
                //---------2W-----------//
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM2W800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM2W840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM2W930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM2W1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM2W1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM2W1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM2W1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM2W200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM2W240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("2") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM2W320_400_Friday = model;
                        continue;
                    }
                }
                //---------3K-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3K800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3K840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3K930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3K1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3K1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3K1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3K1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3K200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3K240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3K320_400_Friday = model;
                        continue;
                    }
                }
                //---------3W-----------//
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM3W800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM3W840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3W930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3W1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3W1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3W1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3W1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3W200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3W240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM3W320_400_Friday = model;
                        continue;
                    }
                }
                //---------4K-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4K800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4K840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4K930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4K1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4K1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4K1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4K1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4K200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4K240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("K") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4K320_400_Friday = model;
                        continue;
                    }
                }
                //---------4W-----------//
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM4W800_840_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM4W840_920_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM4W930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM4W1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM4W1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM4W1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM4W1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM4W200_240_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM4W240_320_Friday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("4") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM4W320_400_Friday = model;
                        continue;
                    }
                }
            }
        }
    }
}
