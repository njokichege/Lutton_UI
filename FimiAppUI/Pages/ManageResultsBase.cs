
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
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IStudentSubjectService SubjectService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        [Inject] public IClassPerformanceService ClassPerformanceService { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public SessionYearModel SchoolYear { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentsSubjectPerformance { get; set; }
        public IEnumerable<StudentModel> Students { get; set; }
        public List<StudentSubjectModel> Subjects { get; set; }
        public ClassPerformanceModel SelectedItem { get; set; }
        public ClassPerformanceModel itemBeforeEdit { get; set; }
        public ClassPerformanceModel UpdateResults { get; set; }
        public TermModel SelectedTerm { get; set; }
        public ExamTypeModel SelectedExamType { get; set; }
        public FormModel SelectedForm { get; set; }
        public StreamModel SelectedStream { get; set; }
        public StudentModel UpdateStudent { get; set; }
        public int ClassId { get; set; }
        public bool visible = false;
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
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
            //var studentToUpdate = await StudentService.GetStudentByStudentNumber(UpdateStudent.StudentNumber);

        }
        public async Task FindClass()
        {
            visible = true;
            ClassModel classModel = new ClassModel();
            classModel = await ClassService.GetClassByForeignKeys(SelectedForm.FormId, SelectedStream.StreamId, SchoolYear.SessionYearId);
            StudentsSubjectPerformance = await ClassPerformanceService.GetStudentResultsByClass(classModel.ClassId, SchoolYear.SessionYearId, SelectedTerm.TermId, SelectedExamType.ExamTypeId);
            
            /*if(StudentsSubjectPerformance.ToList().Count == 0)
            {
                Students = (await StudentService.MapClassOnStudent(classModel.ClassId));
                foreach(var student in Students)
                {
                    Subjects = await SubjectService.GetSubjectsByStudentNumber(student.StudentNumber);
                    foreach(var subject in Subjects)
                    {
                        var result = await ExamResultService.AddExamResult(
                            new ExamResultModel()
                            {
                                ExamId = 1,
                                StudentClassId = student.StudentClass.ClassId,
                                Code = subject.Code,
                                GradeId = 1,
                                Marks = 0
                            });
                    }
                }
            }*/
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
