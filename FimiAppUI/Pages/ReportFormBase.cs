using static MudBlazor.Defaults;

namespace FimiAppUI.Pages
{
    public class ReportFormBase : ComponentBase
    {
        [Inject] IClassPerformanceService ClassPerformanceService { get; set; }
        [Parameter] public string StudentNumber { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        [Parameter] public string TermId { get; set; }
        public ClassPerformanceModel StudentPerformance { get; set; }
        public bool dataIsLoaded = false;
        protected override async Task OnInitializedAsync()
        {
            StudentPerformance = await ClassPerformanceService.GetStudentResults(int.Parse(StudentNumber), int.Parse(SessionYearId), int.Parse(TermId), int.Parse(ExamTypeId));
            dataIsLoaded = true;
        }
    }
}
