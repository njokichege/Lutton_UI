using static MudBlazor.Colors;
using static Slapper.AutoMapper;

namespace FimiAppUI.Pages
{
    public class ClassPerformanceBase : ComponentBase
    {
        [Inject] public IClassPerformanceService SubjectPerformanceService { get; set; }
        [Inject] public IGradeService GradeService { get; set;}
        [Parameter] public string ClassId { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string TermId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentsSubjectPerformance { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }
        public bool dataIsLoaded = false;
        protected override async Task OnInitializedAsync()
        {
            StudentsSubjectPerformance = await SubjectPerformanceService.GetStudentResultsByClass(int.Parse(ClassId), int.Parse(SessionYearId), int.Parse(TermId), int.Parse(ExamTypeId));
            Grades = await GradeService.GetAllGrades();
            foreach (var studentPerformance in StudentsSubjectPerformance)
            {
                foreach (GradeModel grade in Grades)
                {
                    if (studentPerformance.Total >= grade.EndGrade)
                    {
                        studentPerformance.Grade = grade;
                        break;
                    }
                }
            }
            dataIsLoaded = true;
        }
    }
}
