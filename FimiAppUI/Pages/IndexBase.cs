using FimiAppUI.Shared;
using Microsoft.AspNetCore.Mvc;


namespace FimiAppUI.Pages
{
    public class IndexBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ISessionYearService SessionYearService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public IParentService ParentService { get; set; }
        [Inject] public IExamResultService ExamResultService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        public IEnumerable<StudentModel> AllStudents { get; set; } 
        public IEnumerable<TeacherModel> AllTeachers { get; set; }
        public IEnumerable<ParentModel> AllParents { get; set; }
        public IEnumerable<ClassModel> AllClasses { get; set; }
        public IEnumerable<ExamResultModel> ExamResults { get; set; }  
        public SessionYearModel SelectedRunningSession { get; set; }
        public string SessionYearModelTitle { get; set; }
        public List<ChartSeries> Series = new List<ChartSeries>();
        public string[] XAxisLabels = { "Term1","Term2","Term3" };
        public double F1NorthT1, F1SouthT1, F2NorthT1, F2SouthT1,
               F1NorthT2, F1SouthT2, F2NorthT2, F2SouthT2,
               F1NorthT3, F1SouthT3, F2NorthT3, F2SouthT3,

               F3NorthT1, F3SouthT1, F4NorthT1, F4SouthT1,
               F3NorthT2, F3SouthT2, F4NorthT2, F4SouthT2,
               F3NorthT3, F3SouthT3, F4NorthT3, F4SouthT3;
        protected override async Task OnInitializedAsync()
        {
            AllStudents = (await StudentService.GetStudents()).ToList();
            AllTeachers = (await TeacherService.GetTeachers()).ToList();
            AllParents = (await ParentService.GetParents()).ToList();
            AllClasses = (await ClassService.GetClasses()).ToList();
            
            SessionYearModelTitle = SchoolYear.SessionString();

            ExamResults = await ExamResultService.GetYearlySchoolResults(SchoolYear.SessionYearId);

            foreach (var  examResult in ExamResults)
            {
                if (examResult.TermName.Equals("First") && examResult.Form.Equals("1") && examResult.Stream.Equals("North"))
                {
                    F1NorthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("First") && examResult.Form.Equals("1") && examResult.Stream.Equals("South"))
                {
                    F1SouthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("First") && examResult.Form.Equals("2") && examResult.Stream.Equals("North"))
                {
                    F2NorthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("First") && examResult.Form.Equals("2") && examResult.Stream.Equals("South"))
                {
                    F2SouthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second") && examResult.Form.Equals("1") && examResult.Stream.Equals("North"))
                {
                    F1NorthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second") && examResult.Form.Equals("1") && examResult.Stream.Equals("South"))
                {
                    F1SouthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second") && examResult.Form.Equals("2") && examResult.Stream.Equals("North"))
                {
                    F2NorthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second") && examResult.Form.Equals("2") && examResult.Stream.Equals("South"))
                {
                    F2SouthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("1") && examResult.Stream.Equals("North"))
                {
                    F1NorthT3 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("1") && examResult.Stream.Equals("South"))
                {
                    F1SouthT3 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("2") && examResult.Stream.Equals("North"))
                {
                    F2NorthT3 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("2") && examResult.Stream.Equals("South"))
                {
                    F2SouthT3 = examResult.Total;
                }
                else if (examResult.TermName.Equals("First")&& examResult.Form.Equals("3") && examResult.Stream.Equals("North"))
                {
                    F3NorthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("First") && examResult.Form.Equals("3") && examResult.Stream.Equals("South"))
                {
                    F3SouthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("First") && examResult.Form.Equals("4") && examResult.Stream.Equals("North"))
                {
                    F4NorthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("First") && examResult.Form.Equals("4") && examResult.Stream.Equals("South"))
                {
                    F4SouthT1 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second") && examResult.Form.Equals("3") && examResult.Stream.Equals("North"))
                {
                    F3NorthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second")  && examResult.Form.Equals("3") && examResult.Stream.Equals("South"))
                {
                    F3SouthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second") && examResult.Form.Equals("4") && examResult.Stream.Equals("North"))
                {
                    F4NorthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Second") && examResult.Form.Equals("4") && examResult.Stream.Equals("South"))
                {
                    F4SouthT2 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("3") && examResult.Stream.Equals("North"))
                {
                    F3NorthT3 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("3") && examResult.Stream.Equals("South"))
                {
                    F3SouthT3 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("4") && examResult.Stream.Equals("North"))
                {
                    F4NorthT3 = examResult.Total;
                }
                else if (examResult.TermName.Equals("Third") && examResult.Form.Equals("4") && examResult.Stream.Equals("South"))
                {
                    F4SouthT3 = examResult.Total;
                }


            }
            Series.Add(new ChartSeries()
            {
                Name = "F1N",
                Data = new double[] { F1NorthT1 , F1NorthT2 , F1NorthT3  }
            });
            Series.Add(new ChartSeries()
            {
                Name = "F1S",
                Data = new double[] { F1SouthT1, F1SouthT2, F1SouthT3 }
            });
            Series.Add(new ChartSeries()
            {
                Name = "F2N",
                Data = new double[] { F2NorthT1 , F2NorthT2 , F2NorthT3 }
            });
            Series.Add(new ChartSeries()
            {
                Name = "F2S",
                Data = new double[] { F2SouthT1, F2SouthT2, F2SouthT3 }
            });
            Series.Add(new ChartSeries()
            {
                Name = "F3N",
                Data = new double[] { F3NorthT1, F3NorthT2, F3NorthT3 }
            });
            Series.Add(new ChartSeries()
            {
                Name = "F3S",
                Data = new double[] { F3SouthT1, F3SouthT2, F3SouthT3 }
            });
            Series.Add(new ChartSeries()
            {
                Name = "F4N",
                Data = new double[] { F4NorthT1, F4NorthT2, F4NorthT3 }
            });
            Series.Add(new ChartSeries()
            {
                Name = "F4S",
                Data = new double[] { F4SouthT1, F4SouthT2, F4SouthT3 }
            });

        }
    }
}
