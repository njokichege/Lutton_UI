namespace FimiAppUI.Pages
{
    public class ManageResultsBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ITermService TermService { get; set; }
        [Inject] public IExamTypeService ExamTypeService { get; set; }
        [Inject] public IExamResultService ExamResultService { get; set; }
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public IStudentClassService StudentClassService { get; set; }
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public ISubjectService SubjectService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public IExamService ExamService { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public List<StudentModel> StudentsToUpdate { get; set; } = new List<StudentModel>();
        public ClassModel SelectedClass { get; set; }
        public TermModel SelectedTerm { get; set; }
        public ExamTypeModel SelectedExamType { get; set; }
        public FormModel SelectedForm { get; set; }
        public StreamModel SelectedStream { get; set; }
        public SubjectModel SelectedSubject { get; set; }
        public StudentModel StudentBeforeEdit { get; set; }
        public bool visible = false;
        public bool StudentFoundVisible = false;
        public StudentModel selectedItem1 = null;
        public TableEditTrigger editTrigger = TableEditTrigger.RowClick;
        public TableApplyButtonPosition applyButtonPosition = TableApplyButtonPosition.End;
        public TableEditButtonPosition editButtonPosition = TableEditButtonPosition.End;
        protected override async Task OnInitializedAsync()
        {
            var terms = await TermService.GetAllTerms();
            var examtypes = await ExamTypeService.GetAllExamTypes();
        }
        public async Task<IEnumerable<SubjectModel>> SubjectSearch(string value)
        {
            var subjects = (await SubjectService.GetAcademicSubjects()).ToList();
            return subjects;
        }
        public async Task<IEnumerable<TermModel>> SelectedTermSearch(string value)
        {
            return (await TermService.GetAllTerms()).ToList();
        }
        public async Task<IEnumerable<ExamTypeModel>> SelectedExamTypeSearch(string value)
        {
            return (await ExamTypeService.GetAllExamTypes()).ToList();
        }
        public async Task<IEnumerable<FormModel>> SelectedFormSearch(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> SelectedStreamSearch(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async Task FindStudent()
        {
            try
            {
                SelectedClass = await ClassService.GetClassByForeignKeys(SelectedForm.FormId, SelectedStream.StreamId, SchoolYear.SessionYearId);
                Students = await StudentService.MapClassOnStudent(SelectedClass.ClassId);
                StudentFoundVisible = true;
            }
            catch
            {
                Snackbar.Add($"Check class details", MudBlazor.Severity.Error);
                StudentFoundVisible = false;
            }
        }
        public void ItemHasBeenCommitted(object element)
        {
            StudentsToUpdate.Add((StudentModel)element);
        }
        public void BackupItem(object element)
        {
            StudentBeforeEdit = new()
            {
                StudentNumber = ((StudentModel)element).StudentNumber,
                FirstName = ((StudentModel)element).FirstName,
                MiddleName = ((StudentModel)element).MiddleName,
                SubjectResult = ((StudentModel)element).SubjectResult
            };
        }
        public void ResetItemToOriginalValues(object element)
        {
            ((StudentModel)element).StudentNumber = StudentBeforeEdit.StudentNumber;
            ((StudentModel)element).FirstName = StudentBeforeEdit.FirstName;
            ((StudentModel)element).MiddleName = StudentBeforeEdit.MiddleName;
            ((StudentModel)element).SubjectResult = StudentBeforeEdit.SubjectResult;
        }
        public async Task SubmitResults()
        {
            var term = await TermService.GetTermIdByName(SelectedTerm.TermName);
            var examType = await ExamTypeService.GetExamTypeIdByName(SelectedExamType.ExamName);
            var exam = await ExamService.GetExamByTermAndExamType(term.TermId, examType.ExamTypeId, SchoolYear.StartDate.Year);

            foreach (var student in StudentsToUpdate)
            {
                var studentClass = await StudentClassService.GetStudentClass(SelectedClass.ClassId, student.StudentNumber);
                var subjectResult = new ExamResultModel
                {
                    ExamId = exam.ExamId,
                    StudentClassId = studentClass.StudentClassId,
                    Code = SelectedSubject.Code,
                    GradeId = 1,
                    Marks = student.SubjectResult
                };
                var existsResponse = await ExamResultService.UpdateExamResult(subjectResult);
                if(!existsResponse.IsSuccessStatusCode)
                {
                    var response = await ExamResultService.AddExamResult(subjectResult);
                    if (response.StatusCode != HttpStatusCode.Created)
                    {
                        Snackbar.Add($"{SelectedSubject.SubjectName} failed submission", MudBlazor.Severity.Error);
                        ResetProperties();
                        StudentFoundVisible = false;
                        break;
                    }
                }
            }
            Snackbar.Add("Submission successful", MudBlazor.Severity.Success);
            ResetProperties();
            StudentFoundVisible = false;
        }
        private void ResetProperties()
        {
            StudentsToUpdate = new List<StudentModel>();
            Students = new List<StudentModel>();
        }
    }
}
