using FimiAppLibrary.Models;
using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ClassDetailsBase: ComponentBase
    {
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public ITeacherSubjectService TeacherSubjectService { get; set; }
        [Inject] public IStudentSubjectService StudentSubjectService { get; set; }
        [Parameter] public string Id { get; set; }
        public IEnumerable<StudentModel> Students { get; set; } = new List<StudentModel>();
        public IEnumerable<TeacherSubjectModel> TeacherSubjects { get; set; } = new List<TeacherSubjectModel>();
        public IEnumerable<StudentSubjectModel> StudentSubjects { get; set; } = new List<StudentSubjectModel>();
        public ClassModel ClassSelected { get; set; } = new ClassModel();
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
        public List<SubjectModel> ClassSubjects { get; set; } = new List<SubjectModel>();
        public TeacherModel Teacher { get; set; }
        public bool showTscNumber = false;
        public bool dataIsLoaded = false;
        protected async override Task OnInitializedAsync()
        {
            ClassSelected = await ClassService.GetClassById(int.Parse(Id));
            TeacherSubjects = await TeacherSubjectService.GetMultipleMappingByTeacher(ClassSelected.TeacherId);
            Teacher = TeacherSubjects.First().Teacher;
            if(Teacher.TSCNumber != null)
            {
                showTscNumber = true;
            }
            foreach(var teacherSubject in TeacherSubjects)
            {
                Subjects.Add(teacherSubject.Subject);
            }
            Students = await StudentService.MapClassOnStudent(int.Parse(Id));
            dataIsLoaded = true;
            StudentSubjects = await StudentSubjectService.MapStudentOnSubject(ClassSelected.ClassId);

            int countCode = StudentSubjects.First().Subject.Code;
            foreach(var studentSubject in StudentSubjects)
            {
                if(countCode == studentSubject.Subject.Code)
                {
                    studentSubject.Subject.StudentCount++;
                }
                else
                {
                    countCode = studentSubject.Subject.Code;
                    studentSubject.Subject.StudentCount++;
                }
            }
        }
    }
}
