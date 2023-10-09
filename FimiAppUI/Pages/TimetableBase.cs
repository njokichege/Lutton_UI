

using FimiAppLibrary.Models;
using Grpc.Core;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using static MudBlazor.CategoryTypes;

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
        [Inject] public ITimetableTeacherSubjectService TimetableTeacherSubjectService { get; set; }
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
        public string space = " ";
        public bool loadTimetable = false;
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

            List<TeacherSubjectModel> teacherSubjects = new();
            teacherSubjects.Add(TeacherAndSubject);

            TimetableModel timetableModel = new()
            {
                ClassModel= SelectedClass,
                TimeSlot = SelectedTimeSlot,
                DayOfTheWeek = SelectedDay,
                TeacherSubjects = teacherSubjects
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
            loadTimetable = true;

            var classes = await ClassService.GetMultipleMapping();
            var subjects = await SubjectService.GetSubjects();
            var teacherSubjects = await TeacherSubjectService.GetMultipleMapping();
            var timeslots = await TimeSlotService.GetTimeSlots();
            var teachers = await TeacherService.GetTeachers();

            List<SubjectModel> singleLessons = new List<SubjectModel>
            {
                subjects.First(x => x.Code == 233),
                subjects.First(x => x.Code == 101),
                subjects.First(x => x.Code == 102),
                subjects.First(x => x.Code == 313),
                subjects.First(x => x.Code == 121)
            };
            List<SubjectModel> singleDoubleLessons = new List<SubjectModel>
            {
                subjects.First(x => x.Code == 233)
            };

            List<SubjectModel> singleLessons2 = new List<SubjectModel>
            {
                subjects.First(x => x.Code == 1),
                subjects.First(x => x.Code == 2)
            };

            List<SubjectModel> groupedSubjects1 = new List<SubjectModel>
            {
                subjects.First(x => x.Code == 236),
                subjects.First(x => x.Code == 232)
            };

            List<SubjectModel> groupedSubjects2 = new List<SubjectModel>
            {
                subjects.First(x => x.Code == 311),
                subjects.First(x => x.Code == 312)
            };
            List<SubjectModel> groupedSubjects3 = new List<SubjectModel>
            {
                subjects.First(x => x.Code == 443),
                subjects.First(x => x.Code == 565)
            };

            foreach (var cl in classes)
            {
                if(cl.Form.Form.Equals("4") || cl.Form.Form.Equals("3"))
                {
                    Dictionary<string, List<DoubleLessonModel>> daysAndTimesRemaining1 = await GenerateSingleDoubleLesson(singleDoubleLessons, cl, teacherSubjects, timeslots, GetDoubleLessonTimeSlots(timeslots));
                    await GenerateGroupedDoubleLessons(groupedSubjects1, cl, teacherSubjects, timeslots, daysAndTimesRemaining1);
                    Dictionary<string, List<TimeSlotModel>> daysAndTimesRemainingSingleSubjects1 = await GenerateSingleLessons(singleLessons, cl, teacherSubjects, timeslots);
                    Dictionary<string, List<TimeSlotModel>> daysAndTimesRemaining = await GeneratePEandLifeSkillLessons(singleLessons2, cl, teacherSubjects, timeslots, daysAndTimesRemainingSingleSubjects1);
                    Dictionary<string, List<TimeSlotModel>> daysAndTimesRemainingSingleSubjects2 = await GenerateGroupedSingleLessons(groupedSubjects1, cl, teacherSubjects, timeslots, daysAndTimesRemaining);
                    Dictionary<string, List<TimeSlotModel>> daysAndTimesRemainingSingleSubjects3 = await GenerateGroupedSingleLessons(groupedSubjects2, cl, teacherSubjects, timeslots, daysAndTimesRemainingSingleSubjects2);
                    await GenerateGroupedSingleLessons(groupedSubjects3, cl, teacherSubjects, timeslots, daysAndTimesRemainingSingleSubjects3);
                }
            }
            loadTimetable = false;
            await GetTimetableData();
        }

        public async Task<Dictionary<string, List<TimeSlotModel>>> GenerateSingleLessons(List<SubjectModel> subjects, ClassModel classModel, 
            IEnumerable<TeacherSubjectModel> teacherSubjects,IEnumerable<TimeSlotModel> timeslots)
        {
            List<TimeSlotModel> allTimeslots = await TimeSlotService.GetTimeSlots();
            List<TimetableModel> currentEntries = await TimetableService.GetTimetableModelsByClass(classModel.ClassId);

            Dictionary<string, List<TimeSlotModel>> availableTimeslots = GetSingleTimeSlots(allTimeslots);

            foreach(var availableTimeslot in availableTimeslots)
            {
                foreach (var currentEntry in currentEntries)
                {
                    if (availableTimeslot.Key.Equals(currentEntry.DayOfTheWeek))
                    {
                        for (int i = 0; i < availableTimeslot.Value.Count; i++)
                        {
                            if (availableTimeslot.Value[i].StartTime == currentEntry.TimeSlot.StartTime)
                            {
                                availableTimeslot.Value.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            foreach (var subject in subjects)
            {
                int lessonCount = 0;
                if (classModel.Form.Form.Equals("4") || classModel.Form.Form.Equals("3"))
                {
                    if (subject.Code == 233)
                    {
                        lessonCount = 3;
                    }
                    if (subject.Code == 102)
                    {
                        lessonCount = 6;
                    }
                    if (subject.Code == 101 || subject.Code == 121)
                    {
                        lessonCount = 8;
                    }
                    if (subject.Code == 313)
                    {
                        lessonCount = 5;
                    }
                }

                int day = 0;
                for (int x = 0; x < lessonCount; x++)
                {
                    int timeslotBefore = 0;
                    int timeslotAfter = 0;

                    if (day >= 5 || day >= availableTimeslots.Count) 
                    {
                        var rand = new Random();
                        day = rand.Next(availableTimeslots.Count);
                    }
                    var dayandtime = availableTimeslots.ElementAt(day);
                    var ran = new Random();
                    var listIndex = ran.Next(dayandtime.Value.Count);

                    for (int i = 0; i < dayandtime.Value.Count; i++)
                    {
                        if (i == listIndex)
                        {
                            TimetableModel singleLesson = new()
                            {
                                ClassModel = classModel,
                                DayOfTheWeek = dayandtime.Key
                            };

                            int beforeIsFound = 0;
                            int afterIsFound = 0;

                            if (i == 0)
                            {
                                singleLesson.TimeSlot = dayandtime.Value[i];
                            }
                            else if (i > 0 && i < dayandtime.Value.Count - 1)
                            {
                                timeslotBefore = dayandtime.Value[i - 1].TimeslotId;
                                timeslotAfter = dayandtime.Value[i + 1].TimeslotId;
                                beforeIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotBefore,dayandtime.Key);
                                afterIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotAfter, dayandtime.Key);
                            }
                            else if(i < 0)
                            {
                                timeslotAfter = dayandtime.Value[i + 1].TimeslotId;
                                afterIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotAfter, dayandtime.Key);
                            }
                            else if (i >= dayandtime.Value.Count - 1)
                            {
                                timeslotBefore = dayandtime.Value[i - 1].TimeslotId;
                                beforeIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotBefore, dayandtime.Key);
                            }

                            if ( beforeIsFound > 0 || afterIsFound > 0)
                            {
                                listIndex = ran.Next(dayandtime.Value.Count);
                                i = -1;
                                continue;
                            }
                            else
                            {
                                singleLesson.TimeSlot = dayandtime.Value[i];

                                await TimetableService.AddTimetableEntry(singleLesson);
                                TimetableModel entry = await TimetableService.GetLastEntry();

                                var teachersub = teacherSubjects.First(x => x.Code == subject.Code);

                                TimetableTeacherSubjectModel timetableTeacherSubjectModel = new TimetableTeacherSubjectModel
                                {
                                    TimeTableId = entry.TimetableId,
                                    TeacherSubjectId = teachersub.TeacherSubjectId
                                };
                                await TimetableTeacherSubjectService.AddTimetableEntry(timetableTeacherSubjectModel);

                                dayandtime.Value.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    day++;
                }
                foreach (var item in availableTimeslots)
                {
                    if (item.Value.Count == 0)
                    {
                        availableTimeslots.Remove(item.Key);
                    }
                }
            }
                
            return availableTimeslots;
        }
        
        public async Task<Dictionary<string, List<TimeSlotModel>>> GeneratePEandLifeSkillLessons(List<SubjectModel> subjects, ClassModel classModel,
            IEnumerable<TeacherSubjectModel> teacherSubjects, IEnumerable<TimeSlotModel> timeslots, Dictionary<string, List<TimeSlotModel>> daysAndTimes)
        {
            foreach (var subject in subjects)
            {
                int lessonCount = 0;
                if (classModel.Form.Form.Equals("4") || classModel.Form.Form.Equals("3"))
                {
                    if (subject.Code == 1)
                    {
                        lessonCount = 2;
                    }
                    if (subject.Code == 2)
                    {
                        lessonCount = 1;
                    }
                }

                for (int x = 0; x < lessonCount; x++)
                {
                    int timeslotBefore = 0;
                    int timeslotAfter = 0;

                    var rand = new Random();
                    var dayandtime = daysAndTimes.ElementAt(rand.Next(daysAndTimes.Count));

                    var ran = new Random();
                    var listIndex = ran.Next(dayandtime.Value.Count);

                    for (int i = 0; i < dayandtime.Value.Count; i++)
                    {
                        if (i == listIndex)
                        {
                            TimetableModel singleLesson = new()
                            {
                                ClassModel = classModel,
                                DayOfTheWeek = dayandtime.Key
                            };

                            int beforeIsFound = 0;
                            int afterIsFound = 0;

                            if (dayandtime.Value[i].IsBeforeBreak.Equals("no"))
                            {
                                if(listIndex < dayandtime.Value.Count - 1)
                                {
                                    listIndex++;
                                }
                                else
                                {
                                    listIndex = 0;
                                }
                                continue;
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    singleLesson.TimeSlot = dayandtime.Value[i];
                                }
                                else if (i > 0 && i < dayandtime.Value.Count - 1)
                                {
                                    timeslotBefore = dayandtime.Value[i - 1].TimeslotId;
                                    timeslotAfter = dayandtime.Value[i + 1].TimeslotId;
                                    beforeIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotBefore, dayandtime.Key);
                                    afterIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotAfter, dayandtime.Key);
                                }
                                else if (i < 0)
                                {
                                    timeslotAfter = dayandtime.Value[i + 1].TimeslotId;
                                    afterIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotAfter, dayandtime.Key);
                                }
                                else if (i >= dayandtime.Value.Count - 1)
                                {
                                    timeslotBefore = dayandtime.Value[i - 1].TimeslotId;
                                    beforeIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subject.Code, timeslotBefore, dayandtime.Key);
                                }
                                

                                if (beforeIsFound > 0 || afterIsFound > 0)
                                {
                                    listIndex = ran.Next(dayandtime.Value.Count);
                                    i = -1;
                                    continue;
                                }
                                else
                                {
                                    singleLesson.TimeSlot = dayandtime.Value[i];

                                    await TimetableService.AddTimetableEntry(singleLesson);
                                    TimetableModel entry = await TimetableService.GetLastEntry();

                                    var teachersub = teacherSubjects.First(x => x.Code == subject.Code);

                                    TimetableTeacherSubjectModel timetableTeacherSubjectModel = new TimetableTeacherSubjectModel
                                    {
                                        TimeTableId = entry.TimetableId,
                                        TeacherSubjectId = teachersub.TeacherSubjectId
                                    };
                                    await TimetableTeacherSubjectService.AddTimetableEntry(timetableTeacherSubjectModel);

                                    dayandtime.Value.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                    }
                }
                foreach (var item in daysAndTimes)
                {
                    if (item.Value.Count == 0)
                    {
                        daysAndTimes.Remove(item.Key);
                    }
                }
            }
            return daysAndTimes;
        }

        public async Task<Dictionary<string, List<TimeSlotModel>>> GenerateGroupedSingleLessons(List<SubjectModel> subjects, ClassModel classModel, IEnumerable<TeacherSubjectModel> teacherSubjects,
            IEnumerable<TimeSlotModel> timeslots, Dictionary<string, List<TimeSlotModel>> daysAndTimes)
        {
            int lessonCount = 0;
            foreach (var sub in subjects)
            {
                if(classModel.Form.Form.Equals("4") || classModel.Form.Form.Equals("3"))
                {
                    if (sub.Code == 236 || sub.Code == 232)
                    {
                        lessonCount = 3;
                        break;
                    }
                    if (sub.Code == 311 || sub.Code == 312 || sub.Code == 565 || sub.Code == 443)
                    {
                        lessonCount = 5;
                        break;
                    }
                }
            }

            int day = 0;
            for (int x = 0; x < lessonCount; x++)
            {
                int timeslotBefore = 0;
                int timeslotAfter = 0;

                if (day >= 5 || day >= daysAndTimes.Count)
                {
                    var rand = new Random();
                    day = rand.Next(daysAndTimes.Count);
                }
                var dayandtime = daysAndTimes.ElementAt(day);

                TimetableModel singleLesson = new() { ClassModel = classModel, };
                singleLesson.DayOfTheWeek = dayandtime.Key;

                var ran = new Random();
                var listIndex = ran.Next(dayandtime.Value.Count);

                for (int i = 0; i < dayandtime.Value.Count; i++)
                {
                    if (i == listIndex)
                    {
                        int beforeIsFound = 0;
                        int afterIsFound = 0;

                        if (i == 0)
                        {
                            singleLesson.TimeSlot = dayandtime.Value[i];
                        }
                        else if (i > 0 && i < dayandtime.Value.Count - 1)
                        {
                            timeslotBefore = dayandtime.Value[i - 1].TimeslotId;
                            timeslotAfter = dayandtime.Value[i + 1].TimeslotId;
                            beforeIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subjects.First().Code, timeslotBefore, dayandtime.Key);
                            afterIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subjects.First().Code, timeslotAfter, dayandtime.Key);
                        }
                        else if (i < 0)
                        {
                            timeslotAfter = dayandtime.Value[i + 1].TimeslotId;
                            afterIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subjects.First().Code, timeslotAfter, dayandtime.Key);
                        }
                        else if (i >= dayandtime.Value.Count - 1)
                        {
                            timeslotBefore = dayandtime.Value[i - 1].TimeslotId;
                            beforeIsFound = await TimetableService.GetTimetableEntryByTimeslot(classModel.ClassId, subjects.First().Code, timeslotBefore, dayandtime.Key);
                        }

                        if (beforeIsFound > 0 || afterIsFound > 0)
                        {
                            listIndex = ran.Next(dayandtime.Value.Count);
                            i = -1;
                            break;
                        }
                        else
                        {
                            singleLesson.TimeSlot = dayandtime.Value[i];
                        }

                        foreach (var subject in subjects)
                        {
                            await TimetableService.AddTimetableEntry(singleLesson);
                            TimetableModel entry = await TimetableService.GetLastEntry();

                            var teachersub = teacherSubjects.First(x => x.Code == subject.Code);

                            TimetableTeacherSubjectModel timetableTeacherSubjectModel = new TimetableTeacherSubjectModel
                            {
                                TimeTableId = entry.TimetableId,
                                TeacherSubjectId = teachersub.TeacherSubjectId
                            };
                            await TimetableTeacherSubjectService.AddTimetableEntry(timetableTeacherSubjectModel);
                        }
                        dayandtime.Value.RemoveAt(i);
                        break;
                    }
                }
                foreach (var item in daysAndTimes)
                {
                    if (item.Value.Count == 0)
                    {
                        daysAndTimes.Remove(item.Key);
                    }
                }
                day++;
            }
            return daysAndTimes;
        }

        public async Task GenerateGroupedDoubleLessons(List<SubjectModel> subjects, ClassModel classModel, IEnumerable<TeacherSubjectModel> teacherSubjects,
            IEnumerable<TimeSlotModel> timeslots,Dictionary<string, List<DoubleLessonModel>> daysAndTimes)
        {
            int lessonCount = 0;
            foreach(var sub in subjects)
            {
                if (classModel.Form.Form.Equals("4") || classModel.Form.Form.Equals("3"))
                {
                    if (sub.Code == 236 || sub.Code == 232)
                    {
                        lessonCount = 1;
                    }
                }
            }
            
            for (int x = 0; x < lessonCount; x++)
            {
                TimetableModel firstDoubleLesson = new() { ClassModel = classModel, };
                TimetableModel secondDoubleLesson = new() { ClassModel = classModel };

                var rand = new Random();
                var listIndex1 = rand.Next(daysAndTimes.Keys.Count);
                var dayandtime = daysAndTimes.ElementAt(listIndex1);

                firstDoubleLesson.DayOfTheWeek = dayandtime.Key;
                secondDoubleLesson.DayOfTheWeek = dayandtime.Key;

                var ran = new Random();
                var listIndex2 = ran.Next(dayandtime.Value.Count);
                for (int i = 0; i < dayandtime.Value.Count; i++)
                {
                    if (i == listIndex2)
                    {
                        foreach (var item in daysAndTimes)
                        {
                            if (item.Key == dayandtime.Key)
                            {
                                firstDoubleLesson.TimeSlot = item.Value[i].FirstSlot;
                                secondDoubleLesson.TimeSlot = item.Value[i].SecondSlot;

                                await TimetableService.AddTimetableEntry(firstDoubleLesson);
                                TimetableModel firstEntry = await TimetableService.GetLastEntry();
                                await TimetableService.AddTimetableEntry(secondDoubleLesson);
                                TimetableModel secondEntry = await TimetableService.GetLastEntry();

                                foreach (var subject in subjects)
                                {
                                    var teachersub = teacherSubjects.First(x => x.Code == subject.Code);

                                    TimetableTeacherSubjectModel timetableTeacherSubjectModel = new TimetableTeacherSubjectModel
                                    {
                                        TimeTableId = firstEntry.TimetableId,
                                        TeacherSubjectId = teachersub.TeacherSubjectId
                                    };
                                    await TimetableTeacherSubjectService.AddTimetableEntry(timetableTeacherSubjectModel);

                                    TimetableTeacherSubjectModel timetableTeacherSubjectModel2 = new TimetableTeacherSubjectModel
                                    {
                                        TimeTableId = secondEntry.TimetableId,
                                        TeacherSubjectId = teachersub.TeacherSubjectId
                                    };
                                    await TimetableTeacherSubjectService.AddTimetableEntry(timetableTeacherSubjectModel2);
                                }

                                if (item.Value[i].FirstSlot.StartTime.Equals("11:20"))
                                {
                                    item.Value.RemoveAt(i);
                                    item.Value.RemoveAt(i);
                                }
                                else if (item.Value[i].FirstSlot.StartTime.Equals("12:00"))
                                {
                                    item.Value.RemoveAt(i);
                                    item.Value.RemoveAt(i - 1);
                                }
                                else if (item.Value[i].FirstSlot.StartTime.Equals("2:00"))
                                {
                                    item.Value.RemoveAt(i);
                                    item.Value.RemoveAt(i);
                                }
                                else if (item.Value[i].FirstSlot.StartTime.Equals("2:40"))
                                {
                                    item.Value.RemoveAt(i);
                                    item.Value.RemoveAt(i - 1);
                                }
                                else
                                {
                                    item.Value.RemoveAt(i);
                                }
                                break;
                            }
                        }
                    }
                }
                foreach (var item in daysAndTimes)
                {
                    if (item.Value.Count == 0)
                    {
                        daysAndTimes.Remove(item.Key);
                    }
                }
            }
        }

        public async Task<Dictionary<string, List<DoubleLessonModel>>> GenerateSingleDoubleLesson(List<SubjectModel> subjects, ClassModel classModel,IEnumerable<TeacherSubjectModel> teacherSubjects,
            IEnumerable<TimeSlotModel> timeslots,Dictionary<string, List<DoubleLessonModel>> daysAndTimes)
        {
            TimetableModel firstDoubleLesson = new() { ClassModel = classModel,};
            TimetableModel secondDoubleLesson = new() { ClassModel = classModel};

            foreach (var subject in subjects)
            {
                int lessonCount = 0;
                if (classModel.Form.Form.Equals("4") || classModel.Form.Form.Equals("3"))
                {
                    if (subject.Code == 233)
                    {
                        lessonCount = 1;
                    }
                }
                for (int x = 0; x < lessonCount; x++)
                {
                    var rand = new Random();
                    var listIndex1 = rand.Next(daysAndTimes.Keys.Count);

                    var dayandtime = daysAndTimes.ElementAt(listIndex1);
                    if (dayandtime.Value.Count == 0)
                    {
                        daysAndTimes.Remove(dayandtime.Key);
                        continue;
                    }
                    var teachersub = teacherSubjects.First(x => x.Code == subject.Code);
                    
                    firstDoubleLesson.DayOfTheWeek = dayandtime.Key;
                    secondDoubleLesson.DayOfTheWeek = dayandtime.Key;

                    var ran = new Random();
                    var listIndex2 = ran.Next(dayandtime.Value.Count);
                    for (int i = 0; i < dayandtime.Value.Count; i++)
                    {
                        if (i == listIndex2)
                        {
                            foreach (var item in daysAndTimes)
                            {
                                if (item.Key == dayandtime.Key)
                                {
                                    firstDoubleLesson.TimeSlot = item.Value[i].FirstSlot;
                                    secondDoubleLesson.TimeSlot = item.Value[i].SecondSlot;

                                    firstDoubleLesson.TeacherSubjects.Add(teachersub);
                                    secondDoubleLesson.TeacherSubjects.Add(teachersub);

                                    try
                                    {
                                        await TimetableService.AddTimetableEntry(firstDoubleLesson);
                                        TimetableModel model = await TimetableService.GetLastEntry();
                                        TimetableTeacherSubjectModel timetableTeacherSubjectModel = new TimetableTeacherSubjectModel
                                        {
                                            TimeTableId = model.TimetableId,
                                            TeacherSubjectId = teachersub.TeacherSubjectId
                                        };
                                        await TimetableTeacherSubjectService.AddTimetableEntry(timetableTeacherSubjectModel);
                                        await TimetableService.AddTimetableEntry(secondDoubleLesson);
                                        TimetableModel model2 = await TimetableService.GetLastEntry();
                                        TimetableTeacherSubjectModel timetableTeacherSubjectModel2 = new TimetableTeacherSubjectModel
                                        {
                                            TimeTableId = model2.TimetableId,
                                            TeacherSubjectId = teachersub.TeacherSubjectId
                                        };
                                        await TimetableTeacherSubjectService.AddTimetableEntry(timetableTeacherSubjectModel2);
                                    }
                                    catch
                                    {
                                        throw new Exception($"Failed to add {classModel.Form.Form}{classModel.Stream.Stream} {subject.SubjectName} to the timetable");
                                    }

                                    if (item.Value[i].FirstSlot.StartTime.Equals("11:20"))
                                    {
                                        item.Value.RemoveAt(i);
                                        item.Value.RemoveAt(i);
                                    }
                                    else if (item.Value[i].FirstSlot.StartTime.Equals("12:00"))
                                    {
                                        item.Value.RemoveAt(i);
                                        item.Value.RemoveAt(i - 1);
                                    }
                                    else if (item.Value[i].FirstSlot.StartTime.Equals("2:00"))
                                    {
                                        item.Value.RemoveAt(i);
                                        item.Value.RemoveAt(i);
                                    }
                                    else if (item.Value[i].FirstSlot.StartTime.Equals("2:40"))
                                    {
                                        item.Value.RemoveAt(i);
                                        item.Value.RemoveAt(i - 1);
                                    }
                                    else
                                    {
                                        item.Value.RemoveAt(i);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    foreach (var item in daysAndTimes)
                    {
                        if (item.Value.Count == 0)
                        {
                            daysAndTimes.Remove(item.Key);
                        }
                    }
                }
            }
                
            return daysAndTimes;
        }

        private static Dictionary<string, List<DoubleLessonModel>> GetDoubleLessonTimeSlots(IEnumerable<TimeSlotModel> timeslots)
        {
            Dictionary<string, List<DoubleLessonModel>> daysAndTimes = new Dictionary<string, List<DoubleLessonModel>>();
            daysAndTimes.Add("Monday",
                new List<DoubleLessonModel>
                {
                    new DoubleLessonModel {DoubleLessonId = 1, FirstSlot = timeslots.First(x => x.StartTime == "8:00"), SecondSlot = timeslots.First(x => x.StartTime == "8:40")},
                    new DoubleLessonModel {DoubleLessonId = 2, FirstSlot = timeslots.First(x => x.StartTime == "9:30"), SecondSlot = timeslots.First(x => x.StartTime == "10:10")},
                    new DoubleLessonModel {DoubleLessonId = 3, FirstSlot = timeslots.First(x => x.StartTime == "11:20"), SecondSlot = timeslots.First(x => x.StartTime == "12:00")},
                    new DoubleLessonModel {DoubleLessonId = 4, FirstSlot = timeslots.First(x => x.StartTime == "12:00"), SecondSlot = timeslots.First(x => x.StartTime == "12:40")},
                    new DoubleLessonModel {DoubleLessonId = 5, FirstSlot = timeslots.First(x => x.StartTime == "2:00"), SecondSlot = timeslots.First(x => x.StartTime == "2:40")},
                    new DoubleLessonModel {DoubleLessonId = 6, FirstSlot = timeslots.First(x => x.StartTime == "2:40"), SecondSlot = timeslots.First(x => x.StartTime == "3:20")}
                });
            daysAndTimes.Add("Tuesday",
                new List<DoubleLessonModel>
                {
                    new DoubleLessonModel {DoubleLessonId = 1, FirstSlot = timeslots.First(x => x.StartTime == "8:00"), SecondSlot = timeslots.First(x => x.StartTime == "8:40")},
                    new DoubleLessonModel {DoubleLessonId = 2, FirstSlot = timeslots.First(x => x.StartTime == "9:30"), SecondSlot = timeslots.First(x => x.StartTime == "10:10")},
                    new DoubleLessonModel {DoubleLessonId = 3, FirstSlot = timeslots.First(x => x.StartTime == "11:20"), SecondSlot = timeslots.First(x => x.StartTime == "12:00")},
                    new DoubleLessonModel {DoubleLessonId = 4, FirstSlot = timeslots.First(x => x.StartTime == "12:00"), SecondSlot = timeslots.First(x => x.StartTime == "12:40")},
                    new DoubleLessonModel {DoubleLessonId = 5, FirstSlot = timeslots.First(x => x.StartTime == "2:00"), SecondSlot = timeslots.First(x => x.StartTime == "2:40")},
                    new DoubleLessonModel {DoubleLessonId = 6, FirstSlot = timeslots.First(x => x.StartTime == "2:40"), SecondSlot = timeslots.First(x => x.StartTime == "3:20")}
                });
            daysAndTimes.Add("Wednesday",
                new List<DoubleLessonModel>
                {
                    new DoubleLessonModel {DoubleLessonId = 1, FirstSlot = timeslots.First(x => x.StartTime == "8:00"), SecondSlot = timeslots.First(x => x.StartTime == "8:40")},
                    new DoubleLessonModel {DoubleLessonId = 2, FirstSlot = timeslots.First(x => x.StartTime == "9:30"), SecondSlot = timeslots.First(x => x.StartTime == "10:10")},
                    new DoubleLessonModel {DoubleLessonId = 3, FirstSlot = timeslots.First(x => x.StartTime == "11:20"), SecondSlot = timeslots.First(x => x.StartTime == "12:00")},
                    new DoubleLessonModel {DoubleLessonId = 4, FirstSlot = timeslots.First(x => x.StartTime == "12:00"), SecondSlot = timeslots.First(x => x.StartTime == "12:40")},
                    new DoubleLessonModel {DoubleLessonId = 5, FirstSlot = timeslots.First(x => x.StartTime == "2:00"), SecondSlot = timeslots.First(x => x.StartTime == "2:40")},
                    new DoubleLessonModel {DoubleLessonId = 6, FirstSlot = timeslots.First(x => x.StartTime == "2:40"), SecondSlot = timeslots.First(x => x.StartTime == "3:20")}
                });
            daysAndTimes.Add("Thursday",
                new List<DoubleLessonModel>
                {
                    new DoubleLessonModel {DoubleLessonId = 1, FirstSlot = timeslots.First(x => x.StartTime == "8:00"), SecondSlot = timeslots.First(x => x.StartTime == "8:40")},
                    new DoubleLessonModel {DoubleLessonId = 2, FirstSlot = timeslots.First(x => x.StartTime == "9:30"), SecondSlot = timeslots.First(x => x.StartTime == "10:10")},
                    new DoubleLessonModel {DoubleLessonId = 3, FirstSlot = timeslots.First(x => x.StartTime == "11:20"), SecondSlot = timeslots.First(x => x.StartTime == "12:00")},
                    new DoubleLessonModel {DoubleLessonId = 4, FirstSlot = timeslots.First(x => x.StartTime == "12:00"), SecondSlot = timeslots.First(x => x.StartTime == "12:40")},
                    new DoubleLessonModel {DoubleLessonId = 5, FirstSlot = timeslots.First(x => x.StartTime == "2:00"), SecondSlot = timeslots.First(x => x.StartTime == "2:40")},
                    new DoubleLessonModel {DoubleLessonId = 6, FirstSlot = timeslots.First(x => x.StartTime == "2:40"), SecondSlot = timeslots.First(x => x.StartTime == "3:20")}
                });
            daysAndTimes.Add("Friday",
                new List<DoubleLessonModel>
                {
                    new DoubleLessonModel {DoubleLessonId = 1, FirstSlot = timeslots.First(x => x.StartTime == "8:00"), SecondSlot = timeslots.First(x => x.StartTime == "8:40")},
                    new DoubleLessonModel {DoubleLessonId = 2, FirstSlot = timeslots.First(x => x.StartTime == "9:30"), SecondSlot = timeslots.First(x => x.StartTime == "10:10")},
                    new DoubleLessonModel {DoubleLessonId = 3, FirstSlot = timeslots.First(x => x.StartTime == "11:20"), SecondSlot = timeslots.First(x => x.StartTime == "12:00")},
                    new DoubleLessonModel {DoubleLessonId = 4, FirstSlot = timeslots.First(x => x.StartTime == "12:00"), SecondSlot = timeslots.First(x => x.StartTime == "12:40")},
                    new DoubleLessonModel {DoubleLessonId = 5, FirstSlot = timeslots.First(x => x.StartTime == "2:00"), SecondSlot = timeslots.First(x => x.StartTime == "2:40")},
                    new DoubleLessonModel {DoubleLessonId = 6, FirstSlot = timeslots.First(x => x.StartTime == "2:40"), SecondSlot = timeslots.First(x => x.StartTime == "3:20")}
                });
            return daysAndTimes;
        }

        private static Dictionary<string, List<TimeSlotModel>> GetSingleTimeSlots(List<TimeSlotModel> allTimeslots)
        {
            Dictionary<string, List<TimeSlotModel>> availableTimeslots = new Dictionary<string, List<TimeSlotModel>>();
            availableTimeslots.Add("Monday", new List<TimeSlotModel>
            {
                allTimeslots.First(x => x.StartTime == "8:00"),
                allTimeslots.First(x => x.StartTime == "8:40"),
                allTimeslots.First(x => x.StartTime == "9:30"),
                allTimeslots.First(x => x.StartTime == "10:10"),
                allTimeslots.First(x => x.StartTime == "11:20"),
                allTimeslots.First(x => x.StartTime == "12:00"),
                allTimeslots.First(x => x.StartTime == "12:40"),
                allTimeslots.First(x => x.StartTime == "2:00"),
                allTimeslots.First(x => x.StartTime == "2:40"),
                allTimeslots.First(x => x.StartTime == "3:20")
            });
            availableTimeslots.Add("Tuesday", new List<TimeSlotModel>
            {
                allTimeslots.First(x => x.StartTime == "8:00"),
                allTimeslots.First(x => x.StartTime == "8:40"),
                allTimeslots.First(x => x.StartTime == "9:30"),
                allTimeslots.First(x => x.StartTime == "10:10"),
                allTimeslots.First(x => x.StartTime == "11:20"),
                allTimeslots.First(x => x.StartTime == "12:00"),
                allTimeslots.First(x => x.StartTime == "12:40"),
                allTimeslots.First(x => x.StartTime == "2:00"),
                allTimeslots.First(x => x.StartTime == "2:40"),
                allTimeslots.First(x => x.StartTime == "3:20")
            });
            availableTimeslots.Add("Wednesday", new List<TimeSlotModel>
            {
                allTimeslots.First(x => x.StartTime == "8:00"),
                allTimeslots.First(x => x.StartTime == "8:40"),
                allTimeslots.First(x => x.StartTime == "9:30"),
                allTimeslots.First(x => x.StartTime == "10:10"),
                allTimeslots.First(x => x.StartTime == "11:20"),
                allTimeslots.First(x => x.StartTime == "12:00"),
                allTimeslots.First(x => x.StartTime == "12:40"),
                allTimeslots.First(x => x.StartTime == "2:00"),
                allTimeslots.First(x => x.StartTime == "2:40"),
                allTimeslots.First(x => x.StartTime == "3:20")
            });
            availableTimeslots.Add("Thursday", new List<TimeSlotModel>
            {
                allTimeslots.First(x => x.StartTime == "8:00"),
                allTimeslots.First(x => x.StartTime == "8:40"),
                allTimeslots.First(x => x.StartTime == "9:30"),
                allTimeslots.First(x => x.StartTime == "10:10"),
                allTimeslots.First(x => x.StartTime == "11:20"),
                allTimeslots.First(x => x.StartTime == "12:00"),
                allTimeslots.First(x => x.StartTime == "12:40"),
                allTimeslots.First(x => x.StartTime == "2:00"),
                allTimeslots.First(x => x.StartTime == "2:40"),
                allTimeslots.First(x => x.StartTime == "3:20")
            });
            availableTimeslots.Add("Friday", new List<TimeSlotModel>
            {
                allTimeslots.First(x => x.StartTime == "8:00"),
                allTimeslots.First(x => x.StartTime == "8:40"),
                allTimeslots.First(x => x.StartTime == "9:30"),
                allTimeslots.First(x => x.StartTime == "10:10"),
                allTimeslots.First(x => x.StartTime == "11:20"),
                allTimeslots.First(x => x.StartTime == "12:00"),
                allTimeslots.First(x => x.StartTime == "12:40"),
                allTimeslots.First(x => x.StartTime == "2:00"),
                allTimeslots.First(x => x.StartTime == "2:40"),
                allTimeslots.First(x => x.StartTime == "3:20")
            });
            return availableTimeslots;
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
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM3W930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM3W1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM3W1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM3W1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM3W1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM3W200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM3W240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.ClassModel.Form.Form.Equals("3") && model.ClassModel.Stream.Stream.Equals("W") && model.DayOfTheWeek.Equals("Wednesday"))
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
