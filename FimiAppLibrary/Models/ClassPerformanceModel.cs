namespace FimiAppLibrary.Models
{
    public class ClassPerformanceModel
    {
        public int SessionYearId { get; set; }
        public int Index { get; set; }
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
        public int EnglishPosition { get; set; }
        public int KiswhiliPosition { get; set; }
        public int MathematicsPosition { get; set; }
        public int PhysicsPosition { get; set; }
        public int ChemistryPosition { get; set; }
        public int BiologyPosition { get; set; }
        public int HistoryPosition { get; set; }
        public int GeographyPosition { get; set; }
        public int ChristianReligionPosition { get; set; }
        public int HomesciencePosition { get; set; }
        public int AgriculturePosition { get; set; }
        public int BusinessPosition { get; set; }
        public int ClassPosition { get; set; }
        public int TotalPoints { get; set; }
        public static string EnglishName { get { return "English"; } }
        public static string KiswahiliName { get { return "Kiswahili"; } }
        public static string MathematicsName { get { return "Mathematics"; } }
        public static string PhysicsName { get { return "Physics"; } }
        public static string ChemistryName { get { return "Chemistry"; } }
        public static string BiologyName { get { return "Biology"; } }
        public static string HistoryAndGovermentName { get { return "History and Goverment"; } }
        public static string GeographyName { get { return "Geography"; } }
        public static string ChristianReligionName { get { return "Christian  Religion"; } }
        public static string HomeScienceName { get { return "HomeScience"; } }
        public static string AgricultureName { get { return "Agriculture"; } }
        public static string BusinessStudiesName { get { return "Business Studies"; } }
    }
}
