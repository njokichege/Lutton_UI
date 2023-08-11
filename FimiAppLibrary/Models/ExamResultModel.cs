namespace FimiAppLibrary.Models
{
    public class ExamResultModel
    {
        public int Marks { get; set; }
        public int StudentNumber { get; set; }
        public int Code { get; set; }
        public StudentModel Student { get; set; }
    }
}
