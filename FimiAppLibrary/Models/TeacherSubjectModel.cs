namespace FimiAppLibrary.Models
{
    public class TeacherSubjectModel
    {
        public int TeacherSubjectId { get; set; }
        public int TeacherId { get; set; }
        public int Code { get; set; }
        public TeacherModel Teacher { get; set; }
        public SubjectModel Subject { get; set; }
    }
}
