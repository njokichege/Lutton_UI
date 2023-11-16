namespace FimiAppLibrary.Models
{
    public class GradeModel
    {
        public int GradeId { get; set; }
        public int Index { get; set; }
        public string Grade { get; set; }
        public int Points { get; set; }
        public string Remarks { get; set; }
        public double UpperLimit { get; set; }
        public double LowerLimit { get; set; }
    }
}
