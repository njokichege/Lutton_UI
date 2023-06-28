using System.Text;

namespace FimiAppLibrary.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public int FormId { get; set; }
        public int StreamId { get; set; }
        public int SessionYearId { get; set; }
        public int TeacherId { get; set; }
        public FormModel Form { get; set; }
        public StreamModel Stream { get; set; }
        public SessionYearModel SessionYear { get; set; }
        public TeacherModel Teacher { get; set; }
        public GradeModel Grade { get; set; }
        public string FullClass()
        {
            return $"{Form.Form}{Stream.Stream}";
        }
        public string ClassTeacherName() 
        { 
            return $"{Teacher.Staff.FirstName} {Teacher.Staff.MiddleName} {Teacher.Staff.Surname}";
        }
    }
}
