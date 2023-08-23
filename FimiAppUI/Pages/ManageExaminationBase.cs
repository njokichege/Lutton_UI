﻿namespace FimiAppUI.Pages
{
    public class ManageExaminationBase : ComponentBase
    {
        [Inject] public ISchoolPerformanceService SchoolPerformanceService { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IGradeService GradeService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        public IEnumerable<SchoolPerformanceModel> TermOneMidTerm { get; set; }
        public IEnumerable<SchoolPerformanceModel> TermOneEndTerm { get; set; }
        public IEnumerable<SchoolPerformanceModel> TermTwoMidTerm { get; set; }
        public IEnumerable<SchoolPerformanceModel> TermTwoEndTerm { get; set; }
        public IEnumerable<SchoolPerformanceModel> TermThreeMidTerm { get; set; }
        public IEnumerable<SchoolPerformanceModel> TermThreeEndTerm { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }
        public bool showTermOneMidTerm = false;
        public bool showTermOneEndTerm = false;
        public bool showTermTwoMidTerm = false;
        public bool showTermTwoEndTerm = false;
        public bool showTermThreeMidTerm = false;
        public bool showTermThreeEndTerm = false;
        protected override async Task OnInitializedAsync()
        {
            TermOneMidTerm = await GetTermResultsAsync(SchoolYear.SessionYearId,1,1);
            showTermOneMidTerm = true;
            TermOneEndTerm = await GetTermResultsAsync(SchoolYear.SessionYearId, 1, 2);
            showTermOneEndTerm = true;
            TermTwoMidTerm = await GetTermResultsAsync(SchoolYear.SessionYearId, 2, 1);
            showTermTwoMidTerm = true;
            TermTwoEndTerm = await GetTermResultsAsync(SchoolYear.SessionYearId, 2, 2);
            showTermTwoEndTerm = true;
            TermThreeMidTerm = await GetTermResultsAsync(SchoolYear.SessionYearId, 3, 1);
            showTermThreeMidTerm = true;
            TermThreeEndTerm = await GetTermResultsAsync(SchoolYear.SessionYearId, 3, 2);
            showTermThreeEndTerm = true;
        }
        public async Task<IEnumerable<SchoolPerformanceModel>> GetTermResultsAsync(int sessionYearId, int termId, int examTypeId)
        {
            IEnumerable<SchoolPerformanceModel>  SchoolPerformance = await SchoolPerformanceService.GetSchoolPerformances(sessionYearId,termId,examTypeId);
            foreach (var schoolPerformance in SchoolPerformance)
            {
                schoolPerformance.Class = await ClassService.GetClassById(schoolPerformance.ClassId);
                Grades = await GradeService.GetAllGrades();
                foreach (GradeModel grade in Grades)
                {
                    if (schoolPerformance.ClassAverage >= grade.EndGrade)
                    {
                        schoolPerformance.Grade = grade;
                        break;
                    }
                }
            }
            return SchoolPerformance;
        }
        public void ClassRowClickEvent(TableRowClickEventArgs<SchoolPerformanceModel> tableRowClickEventArgs)
        {
            Navigation.NavigateTo($"/classperformance/{tableRowClickEventArgs.Item.ClassId}/{SchoolYear.SessionYearId}/{tableRowClickEventArgs.Item.TermId}/{tableRowClickEventArgs.Item.ExamTypeId}");
        }
    }
}