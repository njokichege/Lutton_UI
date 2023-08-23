using static MudBlazor.Colors;
using static MudBlazor.Defaults;

namespace FimiAppUI.Pages
{
    public class ReportFormBase : ComponentBase
    {
        [Inject] IClassPerformanceService ClassPerformanceService { get; set; }
        [Inject] ISessionYearService SessionYearService { get; set; }
        [Inject] IClassService ClassService { get; set; }
        [Inject] IGradeService GradeService { get; set; }
        [Inject] ITermService TermService { get; set; }
        [Inject] IStudentService StudentService { get; set; }
        [Parameter] public string StudentNumber { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        [Parameter] public string TermId { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentPerformance { get; set; }
        public IEnumerable<ClassPerformanceModel> OtherStudentPerformance{ get; set; }
        public IEnumerable<SessionYearModel> SessionYears { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }
        public IEnumerable<TermModel> Terms { get; set; }
        public TermModel CurrentTerm { get; set; }
        public ClassModel StudentClass { get; set; }
        public SessionYearModel CurrentSchoolYear { get; set; }
        public ClassPerformanceModel MidTermPerformance { get; set; } = new ClassPerformanceModel();
        public ClassPerformanceModel EndTermPerformance { get; set; } = new ClassPerformanceModel();
        public ClassPerformanceModel CurrentStudentTotalPerformance { get; set; } = new ClassPerformanceModel();
        public GradeModel MeanGrade { get; set; }
        public bool dataIsLoaded = false;
        public double Mean;
        public int TotalPoints;
        protected override async Task OnInitializedAsync()
        {
            StudentPerformance = await ClassPerformanceService.GetStudentResults(int.Parse(StudentNumber));
            Terms = await TermService.GetAllTerms();
            foreach (var term in Terms)
            {
                if (term.TermId == int.Parse(TermId))
                {
                    CurrentTerm = term;
                    break;
                }
            }
            SessionYears = await SessionYearService.GetSessionYears();
            foreach (var sessionYear in SessionYears)
            {
                if (sessionYear.SessionYearId == int.Parse(SessionYearId))
                {
                    CurrentSchoolYear = sessionYear;
                    break;
                }
            }
            Grades = await GradeService.GetAllGrades();
            foreach (var studentPerformance in StudentPerformance)
            {
                foreach (GradeModel grade in Grades)
                {
                    if (studentPerformance.Average >= grade.EndGrade)
                    {
                        studentPerformance.TotalGrade = grade;
                        break;
                    }
                }
                if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 1 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                {
                    MidTermPerformance = studentPerformance;
                    StudentClass = await ClassService.GetClassById(studentPerformance.ClassId);
                }
                else if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 2 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                {
                    EndTermPerformance = studentPerformance;
                }
            }

            //----------------------------------------Get the current student's total performance per term--------------------------------------------------------

            CurrentStudentTotalPerformance = GetTotalPerformance(EndTermPerformance, MidTermPerformance);

            //----------------------------------------------------------------------------------------------------------------------------------------------------

            //----------------------------------------Get the current student's position relative to the class----------------------------------------------------

            Students = await StudentService.MapClassOnStudent(StudentClass.ClassId);
            foreach (var student in Students)
            {
                if (student.StudentNumber == int.Parse(StudentNumber)) { continue; }
                OtherStudentPerformance = await ClassPerformanceService.GetClassPerformancePerTerm(int.Parse(SessionYearId), CurrentTerm.TermId, StudentClass.ClassId, student.StudentNumber);
                ClassPerformanceModel midTermPerformance = new ClassPerformanceModel();
                ClassPerformanceModel endTermPerformance = new ClassPerformanceModel();
                foreach (var studentPerformance in OtherStudentPerformance)
                {
                    if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 1 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                    {
                        midTermPerformance = studentPerformance;
                    }
                    else if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 2 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                    {
                        endTermPerformance = studentPerformance;
                    }
                }
                ClassPerformanceModel totalper = GetTotalPerformance(endTermPerformance, midTermPerformance);

                CurrentStudentTotalPerformance.englishPosition = 1;
                CurrentStudentTotalPerformance.kiswhiliPosition = 1;
                CurrentStudentTotalPerformance.mathematicsPosition = 1;
                CurrentStudentTotalPerformance.physicsPosition = 1;
                CurrentStudentTotalPerformance.chemistryPosition = 1;
                CurrentStudentTotalPerformance.biologyPosition = 1;
                CurrentStudentTotalPerformance.historyPosition = 1;
                CurrentStudentTotalPerformance.geographyPosition = 1;
                CurrentStudentTotalPerformance.crePosition = 1;
                CurrentStudentTotalPerformance.homesciencePosition = 1;
                CurrentStudentTotalPerformance.agriculturePosition = 1;
                CurrentStudentTotalPerformance.businessPosition = 1;
                CurrentStudentTotalPerformance.classPosition = 1;

                if (totalper.English > CurrentStudentTotalPerformance.English)
                {
                    CurrentStudentTotalPerformance.englishPosition++;
                }
                if (totalper.Kiswahili > CurrentStudentTotalPerformance.Kiswahili)
                {
                    CurrentStudentTotalPerformance.kiswhiliPosition++;
                }
                if (totalper.Mathematics > CurrentStudentTotalPerformance.Mathematics)
                {
                    CurrentStudentTotalPerformance.mathematicsPosition++;
                }
                if (totalper.Physics > CurrentStudentTotalPerformance.Physics)
                {
                    CurrentStudentTotalPerformance.physicsPosition++;
                }
                if (totalper.Chemistry > CurrentStudentTotalPerformance.Chemistry)
                {
                    CurrentStudentTotalPerformance.chemistryPosition++;
                }
                if (totalper.Biology > CurrentStudentTotalPerformance.Biology)
                {
                    CurrentStudentTotalPerformance.biologyPosition++;
                }
                if (totalper.HistoryAndGoverment > CurrentStudentTotalPerformance.HistoryAndGoverment)
                {
                    CurrentStudentTotalPerformance.historyPosition++;
                }
                if (totalper.Geography > CurrentStudentTotalPerformance.Geography)
                {
                    CurrentStudentTotalPerformance.geographyPosition++;
                }
                if (totalper.ChristianReligion > CurrentStudentTotalPerformance.ChristianReligion)
                {
                    CurrentStudentTotalPerformance.crePosition++;
                }
                if (totalper.HomeScience > CurrentStudentTotalPerformance.HomeScience)
                {
                    CurrentStudentTotalPerformance.homesciencePosition++;
                }
                if (totalper.Agriculture > CurrentStudentTotalPerformance.Agriculture)
                {
                    CurrentStudentTotalPerformance.agriculturePosition++;
                }
                if (totalper.BusinessStudies > CurrentStudentTotalPerformance.BusinessStudies)
                {
                    CurrentStudentTotalPerformance.businessPosition++;
                }
                if(totalper.Average > CurrentStudentTotalPerformance.Average)
                {
                    CurrentStudentTotalPerformance.classPosition++;
                }
            }
            //------------------------------------------------------------------------------------------------------------
            //----------------------------------------Get Total points----------------------------------------------------
            if (CurrentStudentTotalPerformance.English != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.EnglishGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Kiswahili != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.KiswahiliGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Mathematics != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.MathematicsGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Physics != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.PhysicsGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Chemistry != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.ChemistryGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Biology != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.BiologyGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.HistoryAndGoverment != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.HistoryAndGovermentGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Geography != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.GeographyGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.ChristianReligion != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.ChristianReligionGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.HomeScience != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.HomeScienceGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Agriculture != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.AgricultureGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.BusinessStudies != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.BusinessStudiesGrade.Points + TotalPoints;
            }
            //------------------------------------------------------------------------------------------------------------

            Mean = (MidTermPerformance.Average + EndTermPerformance.Average)/ 2;
            foreach (GradeModel grade in Grades)
            {
                if (Mean >= grade.EndGrade)
                {
                   MeanGrade = grade;
                    break;
                }
            }

            //----------------------------------------Load report---------------------------------------------------------

            dataIsLoaded = true;

            //------------------------------------------------------------------------------------------------------------
        }
        private ClassPerformanceModel GetTotalPerformance(ClassPerformanceModel EndTermPerformance, ClassPerformanceModel MidTermPerformance)
        {
            ClassPerformanceModel TotalPerformance = new ClassPerformanceModel();
            TotalPerformance.Average = (MidTermPerformance.Average + EndTermPerformance.Average) / 2;
            TotalPerformance.English = (MidTermPerformance.English + EndTermPerformance.English) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.English >= grade.EndGrade)
                {
                    TotalPerformance.EnglishGrade = grade;
                    break;
                }
            }
            TotalPerformance.Kiswahili = (MidTermPerformance.Kiswahili + EndTermPerformance.Kiswahili) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Kiswahili >= grade.EndGrade)
                {
                    TotalPerformance.KiswahiliGrade = grade;
                    break;
                }
            }
            TotalPerformance.Mathematics = (MidTermPerformance.Mathematics + EndTermPerformance.Mathematics) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Mathematics >= grade.EndGrade)
                {
                    TotalPerformance.MathematicsGrade = grade;
                    break;
                }
            }
            TotalPerformance.Physics = (MidTermPerformance.Physics + EndTermPerformance.Physics) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Physics >= grade.EndGrade)
                {
                    TotalPerformance.PhysicsGrade = grade;
                    break;
                }
            }
            TotalPerformance.Chemistry = (MidTermPerformance.Chemistry + EndTermPerformance.Chemistry) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Chemistry >= grade.EndGrade)
                {
                    TotalPerformance.ChemistryGrade = grade;
                    break;
                }
            }
            TotalPerformance.Biology = (MidTermPerformance.Biology + EndTermPerformance.Biology) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Biology >= grade.EndGrade)
                {
                    TotalPerformance.BiologyGrade = grade;
                    break;
                }
            }
            TotalPerformance.HistoryAndGoverment = (MidTermPerformance.HistoryAndGoverment + EndTermPerformance.HistoryAndGoverment) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.HistoryAndGoverment >= grade.EndGrade)
                {
                    TotalPerformance.HistoryAndGovermentGrade = grade;
                    break;
                }
            }
            TotalPerformance.Geography = (MidTermPerformance.Geography + EndTermPerformance.Geography) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Geography >= grade.EndGrade)
                {
                    TotalPerformance.GeographyGrade = grade;
                    break;
                }
            }
            TotalPerformance.ChristianReligion = (MidTermPerformance.ChristianReligion + EndTermPerformance.ChristianReligion) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.ChristianReligion >= grade.EndGrade)
                {
                    TotalPerformance.ChristianReligionGrade = grade;
                    break;
                }
            }
            TotalPerformance.HomeScience = (MidTermPerformance.HomeScience + EndTermPerformance.HomeScience) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.HomeScience >= grade.EndGrade)
                {
                    TotalPerformance.HomeScienceGrade = grade;
                    break;
                }
            }
            TotalPerformance.Agriculture = (MidTermPerformance.Agriculture + EndTermPerformance.Agriculture) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Agriculture >= grade.EndGrade)
                {
                    TotalPerformance.AgricultureGrade = grade;
                    break;
                }
            }
            TotalPerformance.BusinessStudies = (MidTermPerformance.BusinessStudies + EndTermPerformance.BusinessStudies) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.BusinessStudies >= grade.EndGrade)
                {
                    TotalPerformance.BusinessStudiesGrade = grade;
                    break;
                }
            }
            return TotalPerformance;
        }
    }
}
