
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
            classModel = await ClassService.GetClassByForeignKeys(SelectedForm.FormId, SelectedStream.StreamId, SchoolYear.SessionYearId);

            UpdateStudent = await StudentService.GetStudentByStudentNumber(AdmissionNumber);
            UpdateStudentSubjects = await SubjectService.GetSubjectsByStudentNumber(UpdateStudent.StudentNumber);
            UpdateStudentStudentClass = await StudentClassService.GetStudentClass(classModel.ClassId, UpdateStudent.StudentNumber);

            StudentFoundVisible = true;
        }
        public async Task SubmitStudentsResults()
        {
            var EnglishResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = EnglishMarks
            };
            var KiswahiliResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = KiswahiliMarks
            };
            var MathematicsResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = MathematicsMarks
            };
            var PhysicsResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = PhysicsMarks
            };
            var ChemistryResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = ChemistryMarks
            };
            var BiologyResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = BiologyMarks
            };
            var HistoryResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = HistoryMarks
            };
            var GeographyResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = GeographyMarks
            };
            var CreResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = CreMarks
            };
            var AgricultureResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = AgricultureMarks
            };
            var BusinessResult = new ExamResultModel
            {
                ExamId = 1,
                StudentClassId = UpdateStudentStudentClass.StudentClassId,
                Code = 101,
                GradeId = 1,
                Marks = BusinessMarks
            };

            UpdateStudentsExamResults.Add(EnglishResult);
            UpdateStudentsExamResults.Add(KiswahiliResult);
            UpdateStudentsExamResults.Add(MathematicsResult);
            UpdateStudentsExamResults.Add(PhysicsResult);
            UpdateStudentsExamResults.Add(ChemistryResult);
            UpdateStudentsExamResults.Add(BiologyResult);
            UpdateStudentsExamResults.Add(HistoryResult);
            UpdateStudentsExamResults.Add(GeographyResult);
            UpdateStudentsExamResults.Add(CreResult);
            UpdateStudentsExamResults.Add(AgricultureResult);
            UpdateStudentsExamResults.Add(BusinessResult);

            foreach (var subjectResult in UpdateStudentsExamResults)
            {
                var response = await ExamResultService.AddExamResult(subjectResult);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    continue;
                }
                else
                {
                    Snackbar.Add("Failed submission", MudBlazor.Severity.Warning);
                    break;
                }
            }
        }
        public async Task FindClass()
        {
            visible = true;
            ClassModel classModel = new ClassModel();
            classModel = await ClassService.GetClassByForeignKeys(SelectedForm.FormId, SelectedStream.StreamId, SchoolYear.SessionYearId);

            UpdateStudent = await StudentService.GetStudentByStudentNumber(AdmissionNumber);
            UpdateStudentSubjects = await SubjectService.GetSubjectsByStudentNumber(UpdateStudent.StudentNumber);
            var studentClass = await StudentClassService.GetStudentClass(classModel.ClassId, UpdateStudent.StudentNumber);

            UpdateStudentsExamResults.Add(
                new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = studentClass.StudentClassId,
                    Code = 101,
                    GradeId = 1,
                    Marks = EnglishMarks
                });
            UpdateStudentsExamResults.Add(
                new ExamResultModel
                {
                    ExamId = 1,
                    StudentClassId = studentClass.StudentClassId,
                    Code = 101,
                    GradeId = 1,
                    Marks = EnglishMarks
                });

            StudentsSubjectPerformance = await ClassPerformanceService.GetStudentResultsByClass(classModel.ClassId, SchoolYear.SessionYearId, SelectedTerm.TermId, SelectedExamType.ExamTypeId);

            if (StudentsSubjectPerformance.ToList().Count == 0)
            {
                Students = (await StudentService.MapClassOnStudent(classModel.ClassId));
                foreach(var student in Students)
                {
                    Subjects = await SubjectService.GetSubjectsByStudentNumber(student.StudentNumber);
                    //var studentClass = await StudentClassService.GetStudentClass(classModel.ClassId,student.StudentNumber);
                    foreach (var subject in Subjects)
                    {
                        var result = await ExamResultService.AddExamResult(
                            new ExamResultModel()
                            {
                                ExamId = 1,
                                //StudentClassId = studentClass.StudentClassId,
                                Code = subject.Code,
                                GradeId = 1,
                                Marks = 0
                            });
                    }
                }
                var response = await ClassPerformanceService.InitializeStudentResults();
                StudentsSubjectPerformance = await ClassPerformanceService.GetStudentResultsByClass(classModel.ClassId, SchoolYear.SessionYearId, SelectedTerm.TermId, SelectedExamType.ExamTypeId);
            }
        }
        public async void ItemHasBeenCommitted()
        {
            var response = await ClassPerformanceService.UpdateStudentResults(SelectedItem);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Snackbar.Add("Results Submitted", MudBlazor.Severity.Success);
            }
            else if(response.StatusCode == HttpStatusCode.InternalServerError)
            {
                Snackbar.Add("Failed submission", MudBlazor.Severity.Warning);
            }
        }
        public void BackupItem(object model)
        {
            itemBeforeEdit = new()
            {
                StudentNumber = ((ClassPerformanceModel)model).StudentNumber,
                FirstName = ((ClassPerformanceModel)model).FirstName,
                MiddleName = ((ClassPerformanceModel)model).MiddleName,
                Surname = ((ClassPerformanceModel)model).Surname,
                English = ((ClassPerformanceModel)model).English,
                Kiswahili = ((ClassPerformanceModel)model).Kiswahili,
                Agriculture = ((ClassPerformanceModel)model).Agriculture,
                Geography = ((ClassPerformanceModel)model).Geography,
                HistoryAndGoverment = ((ClassPerformanceModel)model).HistoryAndGoverment,
                Biology = ((ClassPerformanceModel)model).Biology,
                Mathematics = ((ClassPerformanceModel)model).Mathematics,
                Physics = ((ClassPerformanceModel)model).Physics,
                Chemistry = ((ClassPerformanceModel)model).Chemistry,
                ChristianReligion = ((ClassPerformanceModel)model).ChristianReligion,
                HomeScience = ((ClassPerformanceModel)model).HomeScience,
                BusinessStudies = ((ClassPerformanceModel)model).BusinessStudies
            };
        }
        public void ResetItemToOriginalValues(object model)
        {
            ((ClassPerformanceModel)model).StudentNumber = itemBeforeEdit.StudentNumber;
            ((ClassPerformanceModel)model).FirstName = itemBeforeEdit.FirstName;
            ((ClassPerformanceModel)model).MiddleName = itemBeforeEdit.MiddleName;
            ((ClassPerformanceModel)model).Surname = itemBeforeEdit.Surname;
            ((ClassPerformanceModel)model).English = itemBeforeEdit.English;
            ((ClassPerformanceModel)model).Kiswahili = itemBeforeEdit.Kiswahili;
            ((ClassPerformanceModel)model).Agriculture = itemBeforeEdit.Agriculture;
            ((ClassPerformanceModel)model).Geography = itemBeforeEdit.Geography;
            ((ClassPerformanceModel)model).HistoryAndGoverment = itemBeforeEdit.HistoryAndGoverment;
            ((ClassPerformanceModel)model).Biology = itemBeforeEdit.Biology;
            ((ClassPerformanceModel)model).Mathematics = itemBeforeEdit.Mathematics;
            ((ClassPerformanceModel)model).Physics = itemBeforeEdit.Physics;
            ((ClassPerformanceModel)model).Chemistry = itemBeforeEdit.Chemistry;
            ((ClassPerformanceModel)model).ChristianReligion = itemBeforeEdit.ChristianReligion;
            ((ClassPerformanceModel)model).HomeScience = itemBeforeEdit.HomeScience;
            ((ClassPerformanceModel)model).BusinessStudies = itemBeforeEdit.BusinessStudies;
        }
    }
}
