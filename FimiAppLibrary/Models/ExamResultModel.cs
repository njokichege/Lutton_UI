namespace FimiAppLibrary.Models
{
    public class ExamResultModel
    {
        public int ExamResultId { get; set; }
        public int ExamId { get; set; }
        public int StudentClassId { get; set; }
        public int Code { get; set; }
        public int GradeId { get; set; }
        public double Marks { get; set; }
        public string Form { get; set; }
        public string Stream { get; set; }
        public string TermName { get; set; }
        public double Total { get; set; }
    }
}
