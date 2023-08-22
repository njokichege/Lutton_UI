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
        [Parameter] public string StudentNumber { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        [Parameter] public string TermId { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentPerformance { get; set; }
        public IEnumerable<SessionYearModel> SessionYears { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }
        public IEnumerable<TermModel> Terms { get; set; }
        public TermModel CurrentTerm { get; set; }
        public ClassModel StudentClass { get; set; }
        public SessionYearModel CurrentSchoolYear { get; set; }
        public ClassPerformanceModel MidTermPerformance { get; set; } = new ClassPerformanceModel();
        public ClassPerformanceModel EndTermPerformance { get; set; } = new ClassPerformanceModel();
        public ClassPerformanceModel TotalPerformance { get; set; } = new ClassPerformanceModel();
        public bool dataIsLoaded = false;
        protected override async Task OnInitializedAsync()
        {
            StudentPerformance = await ClassPerformanceService.GetStudentResults(int.Parse(StudentNumber));
            Terms = await TermService.GetAllTerms();
            foreach(var term in Terms)
            {
                if(term.TermId == int.Parse(TermId))
                {
                    CurrentTerm = term;
                    break;
                }
            }
            SessionYears = await SessionYearService.GetSessionYears();
            foreach(var sessionYear in SessionYears)
            {
                if(sessionYear.SessionYearId == int.Parse(SessionYearId))
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
                else if(studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 2 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                {
                    EndTermPerformance = studentPerformance;
                }
            }

            TotalPerformance.English = (MidTermPerformance.English + EndTermPerformance.English)/2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.English >= grade.EndGrade)
                {
                    TotalPerformance.EnglishGrade = grade;
                    break;
                }
            }
            TotalPerformance.Kiswahili = (MidTermPerformance.Kiswahili + EndTermPerformance.Kiswahili)/2;
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

            dataIsLoaded = true;
        }
    }
}
