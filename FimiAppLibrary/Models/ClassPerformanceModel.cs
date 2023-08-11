namespace FimiAppLibrary.Models
{
    public class ClassPerformanceModel
    {
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public double English { get; set; }
        public double Kiswahili { get; set; }
        public double Mathematics { get; set; }
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double Biology { get; set; }
        public double HistoryAndGoverment { get; set; }
        public double Geography { get; set; }
        public double ChristianReligion { get; set; }
        public double HomeScience { get; set; }
        public double Agriculture { get; set; }
        public double BusinessStudies { get; set; }
        public double Total { get; set; }
        public double Average { get; set; }
        public GradeModel Grade { get; set; }
    }
}
