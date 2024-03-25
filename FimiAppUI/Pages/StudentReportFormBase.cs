namespace FimiAppUI.Pages
{
    public class StudentReportFormBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Parameter] public string StudentNumber { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string TermId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
