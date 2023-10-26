using FimiAppLibrary.Models;
using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ClassDetailsBase: Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public ITeacherSubjectService TeacherSubjectService { get; set; }
        [Inject] public IStudentSubjectService StudentSubjectService { get; set; }
        [Inject] public ITimetableService TimetableService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Parameter] public string Id { get; set; }
        public IEnumerable<StudentModel> Students { get; set; } = new List<StudentModel>();
        public IEnumerable<TeacherSubjectModel> TeacherSubjects { get; set; } = new List<TeacherSubjectModel>();
        public IEnumerable<ClassSubjectList> ClassSubjectList { get; set; } = new List<ClassSubjectList>();
        public ClassModel ClassSelected { get; set; } = new ClassModel();
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
        public IEnumerable<TimetableModel> TimetableModels { get; set; } = new List<TimetableModel>();
        public TeacherModel SelectedTeacherOnTeacherCard { get; set; }
        public TimetableModel TM800_840_Monday { get; set; }
        public TimetableModel TM840_920_Monday { get; set; }
        public TimetableModel TM930_1010_Monday { get; set; }
        public TimetableModel TM1010_1050_Monday { get; set; }
        public TimetableModel TM1120_1200_Monday { get; set; }
        public TimetableModel TM1200_1240_Monday { get; set; }
        public TimetableModel TM1240_120_Monday { get; set; }
        public TimetableModel TM200_240_Monday { get; set; }
        public TimetableModel TM240_320_Monday { get; set; }
        public TimetableModel TM320_400_Monday { get; set; }
        public TimetableModel TM800_840_Tuesday { get; set; }
        public TimetableModel TM840_920_Tuesday { get; set; }
        public TimetableModel TM930_1010_Tuesday { get; set; }
        public TimetableModel TM1010_1050_Tuesday { get; set; }
        public TimetableModel TM1120_1200_Tuesday { get; set; }
        public TimetableModel TM1200_1240_Tuesday { get; set; }
        public TimetableModel TM1240_120_Tuesday { get; set; }
        public TimetableModel TM200_240_Tuesday { get; set; }
        public TimetableModel TM240_320_Tuesday { get; set; }
        public TimetableModel TM320_400_Tuesday { get; set; }
        public TimetableModel TM800_840_Wednesday { get; set; }
        public TimetableModel TM840_920_Wednesday { get; set; }
        public TimetableModel TM930_1010_Wednesday { get; set; }
        public TimetableModel TM1010_1050_Wednesday { get; set; }
        public TimetableModel TM1120_1200_Wednesday { get; set; }
        public TimetableModel TM1200_1240_Wednesday { get; set; }
        public TimetableModel TM1240_120_Wednesday { get; set; }
        public TimetableModel TM200_240_Wednesday { get; set; }
        public TimetableModel TM240_320_Wednesday { get; set; }
        public TimetableModel TM320_400_Wednesday { get; set; }
        public TimetableModel TM800_840_Thursday { get; set; }
        public TimetableModel TM840_920_Thursday { get; set; }
        public TimetableModel TM930_1010_Thursday { get; set; }
        public TimetableModel TM1010_1050_Thursday { get; set; }
        public TimetableModel TM1120_1200_Thursday { get; set; }
        public TimetableModel TM1200_1240_Thursday { get; set; }
        public TimetableModel TM1240_120_Thursday { get; set; }
        public TimetableModel TM200_240_Thursday { get; set; }
        public TimetableModel TM240_320_Thursday { get; set; }
        public TimetableModel TM320_400_Thursday { get; set; }
        public TimetableModel TM800_840_Friday { get; set; }
        public TimetableModel TM840_920_Friday { get; set; }
        public TimetableModel TM930_1010_Friday { get; set; }
        public TimetableModel TM1010_1050_Friday { get; set; }
        public TimetableModel TM1120_1200_Friday { get; set; }
        public TimetableModel TM1200_1240_Friday { get; set; }
        public TimetableModel TM1240_120_Friday { get; set; }
        public TimetableModel TM200_240_Friday { get; set; }
        public TimetableModel TM240_320_Friday { get; set; }
        public TimetableModel TM320_400_Friday { get; set; }
        public TeacherModel Teacher { get; set; }
        public bool showTscNumber = false;
        public bool dataIsLoaded = false;
        public string TeacherName;
        public string space = " ";
        public bool showTeacherList = false;
        public MudDialog changeTeacherDialog;
        public bool changeTeacherDialogVisible;
        public DialogOptions changeTeacherDialogOptions = new() { FullWidth = true };
        protected async override Task OnInitializedAsync()
        {
            ClassSelected = await ClassService.GetClassById(int.Parse(Id));
            TeacherSubjects = await TeacherSubjectService.GetMultipleMappingByTeacher(ClassSelected.TeacherId);

            Teacher = TeacherSubjects.First().Teacher;
            TeacherName = $"{Teacher.Staff.FirstName} {Teacher.Staff.MiddleName} {Teacher.Staff.Surname}";
            if (Teacher.TSCNumber != null)
            {
                showTscNumber = true;
            }
            foreach (var teacherSubject in TeacherSubjects)
            {
                Subjects.Add(teacherSubject.Subject);
            }
            Students = await StudentService.MapClassOnStudent(int.Parse(Id));
            dataIsLoaded = true;

            ClassSubjectList = await StudentSubjectService.MapStudentOnSubject(ClassSelected.ClassId);
            await GenerateTimetable();
        }
        public void StudentRowClickEvent(TableRowClickEventArgs<StudentModel> tableRowClickEventArgs)
        {
            Navigation.NavigateTo("/studentdetails/" + tableRowClickEventArgs.Item.StudentNumber);
        }
        public async Task<IEnumerable<TeacherModel>> TeacherSearchOnTeacherCard(string value)
        {
            return (await TeacherService.MapStaffOnTeacher()).ToList();
        }
        public async Task ChangeClassTeacher()
        {
            showTeacherList = true;
        }
        public async Task ChangeClassTeacherSubmit()
        {
            changeTeacherDialogVisible = true;
            showTeacherList = false;
        }
        public async Task ChangeTeacherDialogDialogSubmit()
        {
            changeTeacherDialogVisible = true;
            var classModel = new ClassModel
            {
                FormId = ClassSelected.FormId,
                StreamId = ClassSelected.StreamId,
                SessionYearId = ClassSelected.SessionYearId,
                TeacherId = SelectedTeacherOnTeacherCard.TeacherId
            };
            var response = await ClassService.UpdateClass(classModel).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                changeTeacherDialogVisible = false;
                ReloadPage(Navigation);
            }
            else
            {
                changeTeacherDialogVisible = false;
                Snackbar.Add("Failed to change class teacher", MudBlazor.Severity.Error);
            }
            SelectedTeacherOnTeacherCard = null;
        }

        public void Cancel()
        {
            changeTeacherDialogVisible = false;
            SelectedTeacherOnTeacherCard = null;
        }
        public void ReloadPage(NavigationManager manager)
        {
            manager.NavigateTo(manager.Uri, true);
        }
        private async Task GenerateTimetable()
        {
            TimetableModels = await TimetableService.GetTimetableModelsByClass(ClassSelected.ClassId);
            foreach (var model in TimetableModels)
            {
                //------------------------------------------ Monday ---------------------------------------------------//
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM800_840_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM840_920_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM930_1010_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1010_1050_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1120_1200_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1200_1240_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1240_120_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM200_240_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM240_320_Monday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Monday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM320_400_Monday = model;
                        continue;
                    }
                }
                //------------------------------------------ Tuesday ---------------------------------------------------//
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM800_840_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM840_920_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM930_1010_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1010_1050_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1120_1200_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1200_1240_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1240_120_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM200_240_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM240_320_Tuesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Tuesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM320_400_Tuesday = model;
                        continue;
                    }
                }
                //-------------------------------------------Wednesday ---------------------------------------------------//
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM800_840_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM840_920_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM930_1010_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1010_1050_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1120_1200_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1200_1240_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1240_120_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM200_240_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM240_320_Wednesday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Wednesday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM320_400_Wednesday = model;
                        continue;
                    }
                }
                //------------------------------------------ Thursday ---------------------------------------------------//
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM800_840_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM840_920_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM930_1010_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1010_1050_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1120_1200_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1200_1240_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1240_120_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM200_240_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM240_320_Thursday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Thursday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM320_400_Thursday = model;
                        continue;
                    }
                }
                //------------------------------------------Friday ---------------------------------------------------//
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:00"))
                    {
                        TM800_840_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("8:40"))
                    {
                        TM840_920_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("9:30"))
                    {
                        TM930_1010_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("10:10"))
                    {
                        TM1010_1050_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("11:20"))
                    {
                        TM1120_1200_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:00"))
                    {
                        TM1200_1240_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("12:40"))
                    {
                        TM1240_120_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:00"))
                    {
                        TM200_240_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("2:40"))
                    {
                        TM240_320_Friday = model;
                        continue;
                    }
                }
                if (model.DayOfTheWeek.Equals("Friday"))
                {
                    if (model.TimeSlot.StartTime.Equals("3:20"))
                    {
                        TM320_400_Friday = model;
                        continue;
                    }
                }
            }
        }
    }
}
