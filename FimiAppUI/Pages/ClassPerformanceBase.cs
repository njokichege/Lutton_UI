using Microsoft.JSInterop;
using MudBlazor;
using Radzen.Blazor;
using System.IO.Compression;
using System.IO;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using PSC.Blazor.Components.Chartjs.Models.Common;

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
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Parameter] public string ClassId { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string TermId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentsSubjectPerformance { get; set; }
        public List<ClassPerformanceModel> StudentsSubjectPerformanceList { get; set; } 
        public IEnumerable<StudentResultsModel> ClassStudentResults { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }
        public ClassModel ClassDetails { get; set; }
        public MudTable<ClassPerformanceModel> mudTable;
        public bool dataIsLoaded = false;
        private int selectedRowNumber = -1;
        public bool showDownloadProgress = false;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SubjectPerformanceService.InitializeStudentResults();
                StudentsSubjectPerformance = await SubjectPerformanceService.GetStudentResultsByClass(int.Parse(ClassId), int.Parse(SessionYearId), int.Parse(TermId), int.Parse(ExamTypeId));
                Grades = await GradeService.GetAllGrades();
                ClassDetails = await ClassService.GetClassById(int.Parse(ClassId));
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
            StudentsSubjectPerformanceList = StudentsSubjectPerformance.ToList();
            var removeZeroResults = new List<int>();
            foreach (var studentPerformance in StudentsSubjectPerformanceList)
            {
                foreach (GradeModel grade in Grades)
                {
                    if (studentPerformance.Average >= grade.LowerLimit)
                    {
                        studentPerformance.TotalGrade = grade;
                        break;
                    }
                }
                if(studentPerformance.Average == 0.00)
                {
                    removeZeroResults.Add(studentPerformance.StudentNumber);
                }
            }
            foreach(int studentNumber in removeZeroResults)
            {
                StudentsSubjectPerformanceList.RemoveAll(x => x.StudentNumber == studentNumber);
            }
            
            dataIsLoaded = true;
        }
        public async Task GenerateAllReportForms()
        {
            showDownloadProgress = true;

            Dictionary<byte[],int> studentReportBytes = new Dictionary<byte[],int>();
            foreach (var student in StudentsSubjectPerformanceList)
            {
                byte[] reportData = await ReportService.StudentReportCardBytes(student.StudentNumber, SessionYearId, TermId, ExamTypeId);
                studentReportBytes.Add(reportData, student.StudentNumber);
            }

            byte[] zippedFiles;
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var fileBytes in studentReportBytes)
                    {
                        var entry = archive.CreateEntry($"ReportForm_{ClassDetails.Form.Form}{ClassDetails.Stream.Stream}_{fileBytes.Value}" + ".pdf");
                        using (var entryStream = entry.Open())
                        {
                            await entryStream.WriteAsync(fileBytes.Key);
                        }
                    }
                }
                zippedFiles = memoryStream.ToArray();
            }

            if (zippedFiles == null)
            {
                Snackbar.Add("Failed to load report form", MudBlazor.Severity.Error);
            }
            else
            {
                FileUtil.SaveAs(JSRuntime, $"{ClassDetails.Form.Form}{ClassDetails.Stream.Stream}.zip", zippedFiles);
            }
            showDownloadProgress = false;
        }
        public static class FileUtil
        {
            public async static Task SaveAs(IJSRuntime js, string filename, byte[] data)
            {
                await js.InvokeAsync<object>(
                    "saveAsFile",
                    filename,
                    Convert.ToBase64String(data));
            }
        }
        public async Task StudentRowClickEventAsync(TableRowClickEventArgs<ClassPerformanceModel> tableRowClickEventArgs)
        {
            //Navigation.NavigateTo($"https://localhost:5124/api/report/studentreportform/{tableRowClickEventArgs.Item.StudentNumber}/{SessionYearId}/{TermId}/{ExamTypeId}");

            byte[] reportData = await ReportService.StudentReportCardBytes(tableRowClickEventArgs.Item.StudentNumber,SessionYearId,TermId,ExamTypeId);
            string mimeType = "application/pdf";
            string fileName = $"ReportForm_{ClassDetails.Form.Form}{ClassDetails.Stream.Stream}_{tableRowClickEventArgs.Item.StudentNumber}";
            if (reportData == null)
            {
                Snackbar.Add("Failed to load report form", MudBlazor.Severity.Error);
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("saveFile", Convert.ToBase64String(reportData), mimeType, fileName);
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
