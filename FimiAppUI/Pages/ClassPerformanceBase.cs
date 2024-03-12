namespace FimiAppUI.Pages
{
    public class ClassPerformanceBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IClassPerformanceService SubjectPerformanceService { get; set; }
        [Inject] public IStudentResultsService StudentResultsService { get; set; }
        [Inject] public IGradeService GradeService { get; set;}
        [Inject] public NavigationManager Navigation { get; set; }
        [Inject] public IWebHostEnvironment WebHostEnvironment { get; set; }
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
            ClassStudentResults = await StudentResultsService.GetStudentResultsByClass(int.Parse(ClassId));

            StudentsSubjectPerformance = await SubjectPerformanceService.GetStudentResultsByClass(int.Parse(ClassId), int.Parse(SessionYearId), int.Parse(TermId), int.Parse(ExamTypeId));
            Grades = await GradeService.GetAllGrades();
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
        public async Task StudentRowClickEventAsync(TableRowClickEventArgs<ClassPerformanceModel> tableRowClickEventArgs)
        {
            Navigation.NavigateTo($"https://luttonapp.azurewebsites.net/api/report/studentreportform/{tableRowClickEventArgs.Item.StudentNumber}/{SessionYearId}/{TermId}/{ExamTypeId}");
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
