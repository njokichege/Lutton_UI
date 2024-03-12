namespace FimiAppLibrary.Models
{
    public class StudentResultsModel
    {
        public int SessionYearId { get; set; }
        public int ClassId { get; set; }
        public int TermId { get; set; }
        public int ExamTypeId { get; set; }
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public int English { get; set; }
        public int Kiswahili { get; set; }
        public int Mathematics { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Biology { get; set; }
        public int HistoryGovernment { get; set; }
        public int Cre { get; set; }
        public int HomeScience { get; set; }
        public int Agriculture { get; set; }
        public int BusinessStudies { get; set; }
    }
}
