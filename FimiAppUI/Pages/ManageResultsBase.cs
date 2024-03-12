
using Microsoft.AspNetCore.SignalR;
using System.Net;
using static MudBlazor.CategoryTypes;

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
        [Inject] public IStudentSubjectService SubjectService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public IClassPerformanceService ClassPerformanceService { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentsSubjectPerformance { get; set; }
        public List<ExamResultModel> UpdateStudentsExamResults { get; set; } = new List<ExamResultModel>();
        public IEnumerable<StudentModel> Students { get; set; }
        public List<StudentSubjectModel> Subjects { get; set; }
        public List<StudentSubjectModel> UpdateStudentSubjects { get; set; }
        public ClassPerformanceModel SelectedItem { get; set; }
        public StudentClassModel UpdateStudentStudentClass { get; set; }
        public ClassPerformanceModel itemBeforeEdit { get; set; }
        public ClassPerformanceModel UpdateResults { get; set; }
        public TermModel SelectedTerm { get; set; }
        public ExamTypeModel SelectedExamType { get; set; }
        public FormModel SelectedForm { get; set; }
        public StreamModel SelectedStream { get; set; }
        public StudentModel UpdateStudent { get; set; }
        public int ClassId { get; set; }
        public int AdmissionNumber { get; set; }
        public double EnglishMarks { get; set; }
        public double KiswahiliMarks { get; set; }
        public double MathematicsMarks { get; set; }
        public double PhysicsMarks { get; set; }
        public double ChemistryMarks { get; set; }
        public double BiologyMarks { get; set; }
        public double HistoryMarks { get; set; }
        public double GeographyMarks { get; set; }
        public double CreMarks { get; set; }
        public double AgricultureMarks { get; set; }
        public double BusinessMarks { get; set; }
        public bool visible = false;
        public bool StudentFoundVisible = false;
        protected override async Task OnInitializedAsync()
        {
            var terms = await TermService.GetAllTerms();
            foreach(var term in terms)
            {
                if(term.TermName == "First")
                {
                    SelectedTerm = term;
                    break;
                }
            }

            var examtypes = await ExamTypeService.GetAllExamTypes();
            foreach(var examtype in examtypes)
            {
                if(examtype.ExamName == "Mid Term")
                {
                    SelectedExamType = examtype;
                    break;
                }
            }
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
            ClassModel classModel = new ClassModel();
            
            try
            {
                classModel = await ClassService.GetClassByForeignKeys(SelectedForm.FormId, SelectedStream.StreamId, SchoolYear.SessionYearId);
                UpdateStudent = await StudentService.GetStudentByStudentNumber(AdmissionNumber);
                UpdateStudentSubjects = await SubjectService.GetSubjectsByStudentNumber(UpdateStudent.StudentNumber);
                UpdateStudentStudentClass = await StudentClassService.GetStudentClass(classModel.ClassId, UpdateStudent.StudentNumber);
                StudentFoundVisible = true;
            }
            catch
            {
                Snackbar.Add($"Incorrect student details ", MudBlazor.Severity.Error);
                StudentFoundVisible = false;
            }
        }

        private void ResetProperties()
        {
            EnglishMarks = 0;
            KiswahiliMarks = 0;
            MathematicsMarks = 0;
            PhysicsMarks = 0;
            ChemistryMarks = 0;
            BiologyMarks = 0;
            HistoryMarks = 0;
            GeographyMarks = 0;
            CreMarks = 0;
            AgricultureMarks = 0;
            BusinessMarks = 0;

            UpdateStudent = new StudentModel();
            UpdateStudentSubjects = new List<StudentSubjectModel>();
            UpdateStudentStudentClass = new StudentClassModel();
            UpdateStudentsExamResults = new List<ExamResultModel>();
        }

        public async Task SubmitStudentsResults()
        {
            if(EnglishMarks > 0.0)
            {
                var EnglishResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 101,
                    GradeId = 1,
                    Marks = EnglishMarks
                };
                UpdateStudentsExamResults.Add(EnglishResult);
            }
            if (KiswahiliMarks > 0.0)
            {
                var KiswahiliResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 102,
                    GradeId = 1,
                    Marks = KiswahiliMarks
                };
                UpdateStudentsExamResults.Add(KiswahiliResult);
            }
            if (MathematicsMarks > 0.0)
            {
                var MathematicsResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 121,
                    GradeId = 1,
                    Marks = MathematicsMarks
                };
                UpdateStudentsExamResults.Add(MathematicsResult);
            }
            if (PhysicsMarks > 0.0)
            {
                var PhysicsResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 232,
                    GradeId = 1,
                    Marks = PhysicsMarks
                };
                UpdateStudentsExamResults.Add(PhysicsResult);
            }
            if (ChemistryMarks > 0.0)
            {
                var ChemistryResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 233,
                    GradeId = 1,
                    Marks = ChemistryMarks
                };
                UpdateStudentsExamResults.Add(ChemistryResult);
            }
            if (BiologyMarks > 0.0)
            {
                var BiologyResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 236,
                    GradeId = 1,
                    Marks = BiologyMarks
                };
                UpdateStudentsExamResults.Add(BiologyResult);
            }
            if (HistoryMarks > 0.0)
            {
                var HistoryResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 311,
                    GradeId = 1,
                    Marks = HistoryMarks
                };
                UpdateStudentsExamResults.Add(HistoryResult);
            }
            if (GeographyMarks > 0.0)
            {
                var GeographyResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 312,
                    GradeId = 1,
                    Marks = GeographyMarks
                };
                UpdateStudentsExamResults.Add(GeographyResult);
            }
            if (CreMarks > 0.0)
            {
                var CreResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 313,
                    GradeId = 1,
                    Marks = CreMarks
                };
                UpdateStudentsExamResults.Add(CreResult);
            }
            if (AgricultureMarks > 0.0)
            {
                var AgricultureResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 443,
                    GradeId = 1,
                    Marks = AgricultureMarks
                };
                UpdateStudentsExamResults.Add(AgricultureResult);
            }
            if (BusinessMarks > 0.0)
            {
                var BusinessResult = new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = UpdateStudentStudentClass.StudentClassId,
                    Code = 565,
                    GradeId = 1,
                    Marks = BusinessMarks
                };
                UpdateStudentsExamResults.Add(BusinessResult);
            }

            foreach (var subjectResult in UpdateStudentsExamResults)
            {
                var response = await ExamResultService.AddExamResult(subjectResult);
                var sub = UpdateStudentSubjects.First(x => x.Subject.Code == subjectResult.Code);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Snackbar.Add($"{sub.Subject.SubjectName} result submitted for {UpdateStudent.FirstName}", MudBlazor.Severity.Success);
                }
                else
                {
                    Snackbar.Add($"{sub.Subject.SubjectName} failed submission", MudBlazor.Severity.Error);
                    break;
                }
            }
            ResetProperties();
            StudentFoundVisible = false;
        }
    }
}
