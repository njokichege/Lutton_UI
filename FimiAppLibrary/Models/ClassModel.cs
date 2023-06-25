using System.Text;

namespace FimiAppLibrary.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public FormModel Form { get; set; }
        public StreamModel Stream { get; set; }
        public TeacherModel Teacher { get; set; }
        public string FullClass
        {
            get
            {
                return this.fullClass;
            }
            set
            {
                fullClass = $"{Form.Form}{Stream.Stream}";
            }
        }
        public string ClassTeacherName 
        { 
            get 
            {
                return this.classTeacherName;
            }
            set
            {
                classTeacherName = $"{Teacher.Staff.FirstName} {Teacher.Staff.MiddleName} {Teacher.Staff.Surname}";
            }
        }
        private string classTeacherName;
        private string fullClass;
    }
}
