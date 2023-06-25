namespace FimiAppLibrary.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string TeacherType { get; set; }
        public string TSCNumber { get; set; }
        public StaffModel Staff { get; set; }
        public int SubjectSpecializationOne { get; set; }
        public int SubjectSpecializationTwo { get; set; }
        public string ClassTeacherName
        {
            get
            {
                return this.classTeacherName;
            }
            set
            {
                classTeacherName = $"{Staff.FirstName} {Staff.MiddleName} {Staff.Surname}";
            }
        }
        private string classTeacherName;
    }
}
