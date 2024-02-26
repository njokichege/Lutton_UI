using FimiAppUI.Shared;
using Microsoft.AspNetCore.Mvc;
using Radzen;
using Radzen.Blazor;
using Radzen.Blazor.Rendering;

namespace FimiAppUI.Pages
{
    public class IndexBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public IParentService ParentService { get; set; }
        [Inject] public IExamResultService ExamResultService { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IEventService EventService { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        public IEnumerable<StudentModel> AllStudents { get; set; } 
        public IEnumerable<TeacherModel> AllTeachers { get; set; }
        public IEnumerable<ParentModel> AllParents { get; set; }
        public IEnumerable<ClassModel> AllClasses { get; set; }
        public IEnumerable<ExamResultModel> ExamResults { get; set; }  
        public SessionYearModel SelectedRunningSession { get; set; }
        public IList<EventModel> EventModels { get; set; }
        public string SessionYearModelTitle { get; set; }
        public List<ChartSeries> Series = new List<ChartSeries>();
        public string[] XAxisLabels = { "Term1","Term2","Term3" };
        public RadzenScheduler<EventModel> scheduler;
        public double F1NorthT1, F1SouthT1, F2NorthT1, F2SouthT1,
               F1NorthT2, F1SouthT2, F2NorthT2, F2SouthT2,
               F1NorthT3, F1SouthT3, F2NorthT3, F2SouthT3,

               F3NorthT1, F3SouthT1, F4NorthT1, F4SouthT1,
               F3NorthT2, F3SouthT2, F4NorthT2, F4SouthT2,
               F3NorthT3, F3SouthT3, F4NorthT3, F4SouthT3;
        protected override async Task OnInitializedAsync()
        {
            EventModels = await EventService.GetAllEvents();
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
        public void OnSlotRender(SchedulerSlotRenderEventArgs args)
        {
            // Highlight today in month view
            if (args.View.Text == "Month" && args.Start.Date == DateTime.Today)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }

            // Highlight working hours (9-18)
            if ((args.View.Text == "Week" || args.View.Text == "Day") && args.Start.Hour > 8 && args.Start.Hour < 19)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }
        }
        public void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<EventModel> args)
        {
            // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

            if (args.Data.EventType.EventType.Equals("Term Dates"))
            {
                args.Attributes["style"] = "background: #DA4167";
            }
            else if (args.Data.EventType.EventType.Equals("Exam"))
            {
                args.Attributes["style"] = "background: #78CDD7";
            }
            else if (args.Data.EventType.EventType.Equals("Student Event"))
            {
                args.Attributes["style"] = "background: #D36135";
            }
            else if (args.Data.EventType.EventType.Equals("Parent Event"))
            {
                args.Attributes["style"] = "background: #006494";
            }
        }
    }
}
