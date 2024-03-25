using MudBlazor;
using Newtonsoft.Json;
using PSC.Blazor.Components.Chartjs.Models.Common;
using System.Text;

namespace FimiAppUI.Pages
{
    public class ClassPerformanceBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IClassPerformanceService SubjectPerformanceService { get; set; }
        [Inject] public IGradeService GradeService { get; set;}
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public IWebHostEnvironment WebHostEnvironment { get; set; }
        [Inject] public IReportService ReportService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Parameter] public string ClassId { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string TermId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentsSubjectPerformance { get; set; }
        public IEnumerable<StudentResultsModel> ClassStudentResults { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }
        public MudTable<ClassPerformanceModel> mudTable;
        public bool dataIsLoaded = false;
        private int selectedRowNumber = -1;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SubjectPerformanceService.InitializeStudentResults();
                StudentsSubjectPerformance = await SubjectPerformanceService.GetStudentResultsByClass(int.Parse(ClassId), int.Parse(SessionYearId), int.Parse(TermId), int.Parse(ExamTypeId));
                Grades = await GradeService.GetAllGrades();
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
            
            foreach (var studentPerformance in StudentsSubjectPerformance)
            {
                foreach (GradeModel grade in Grades)
                {
                    if (studentPerformance.Average >= grade.LowerLimit)
                    {
                        studentPerformance.TotalGrade = grade;
                        break;
                    }
                }
            }
            dataIsLoaded = true;
        }
        public async Task GenerateAllReportForms()
        {
            var studentList = new List<int>();

            foreach (var student in StudentsSubjectPerformance)
            {
                studentList.Add(student.StudentNumber);
            }

            var response = await ReportService.AllStudentReportCards( studentList, SessionYearId, TermId, ExamTypeId);

            if (response.IsSuccessStatusCode)
            {
                // Get the download link from the response
                var downloadLink = await response.Content.ReadAsStringAsync();

                // Trigger the download
                await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", "ReportForms.zip", "application/zip", downloadLink);
            }
            //Navigation.NavigateTo($"https://localhost:5124/api/report/allstudentsreportform/{SessionYearId}/{TermId}/{ExamTypeId}");

            /*var queryJson = JsonConvert.SerializeObject(studentList);
            var apiEndpoint = $"https://localhost:5124/api/report/allstudentsreportform/{SessionYearId}/{TermId}/{ExamTypeId}/";
            var fullUrl = $"{apiEndpoint}?students={queryJson}";

            Navigation.NavigateTo(fullUrl);*/
        }
        public async Task StudentRowClickEventAsync(TableRowClickEventArgs<ClassPerformanceModel> tableRowClickEventArgs)
        {
            //Navigation.NavigateTo($"https://localhost:5124/api/report/studentreportform/{tableRowClickEventArgs.Item.StudentNumber}/{SessionYearId}/{TermId}/{ExamTypeId}");

byte[] reportData = await ReportService.StudentReportCardBytes(tableRowClickEventArgs.Item.StudentNumber,SessionYearId,TermId,ExamTypeId);
string mimeType = "application/pdf";
string fileName = $"ReportForm_{tableRowClickEventArgs.Item.StudentNumber}";
if (reportData == null)
{
    Snackbar.Add("Failed to load report form", MudBlazor.Severity.Error);
}
else
{
    JSRuntime.InvokeVoidAsync("saveFile", Convert.ToBase64String(reportData), mimeType, fileName);
}
        }
        public string SelectedRowClassFunc(ClassPerformanceModel element, int rowNumber)
        {
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                return string.Empty;
            }
            else if (mudTable.SelectedItem != null && mudTable.SelectedItem.Equals(element))
            {
                selectedRowNumber = rowNumber;
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
