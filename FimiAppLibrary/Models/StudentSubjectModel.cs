namespace FimiAppLibrary.Models
{
    public class StudentSubjectModel
    {
        public int StudentSubjectId { get; set; }
        public int StudentNumber { get; set; }
        public int Code { get; set; }
        public StudentModel Student { get; set; }
        public SubjectModel Subject { get; set; }
    }
}
