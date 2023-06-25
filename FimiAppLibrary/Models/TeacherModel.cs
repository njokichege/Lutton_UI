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
    }
}
