namespace FimiAppLibrary.Models
{
    public class ClassPerformanceModel
    {
        public int SessionYearId { get; set; }
        public int ClassId { get; set; }
        public int TermId { get; set; }
        public int ExamTypeId { get; set; }
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
        public GradeModel TotalGrade { get; set; }
        public GradeModel EnglishGrade { get; set; }
        public GradeModel KiswahiliGrade { get; set; }
        public GradeModel MathematicsGrade { get; set; }
        public GradeModel PhysicsGrade { get; set; }
        public GradeModel ChemistryGrade { get; set; }
        public GradeModel BiologyGrade { get; set; }
        public GradeModel HistoryAndGovermentGrade { get; set; }
        public GradeModel GeographyGrade { get; set; }
        public GradeModel ChristianReligionGrade { get; set; }
        public GradeModel HomeScienceGrade { get; set; }
        public GradeModel AgricultureGrade { get; set; }
        public GradeModel BusinessStudiesGrade { get; set; }
    }
}
