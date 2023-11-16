namespace FimiAppLibrary.Models
{
    public class SchoolPerformanceModel
    {
        public int ClassId { get; set; }
        public int Index { get; set; }
        public int TermId { get; set; }
        public int ExamTypeId { get; set; }
        public double ClassAverage { get; set; }
        public GradeModel Grade { get; set; }
        public ClassModel Class { get; set; }
    }
}
