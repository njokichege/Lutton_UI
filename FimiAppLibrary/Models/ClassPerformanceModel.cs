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
        public int englishPosition { get; set; }
        public int kiswhiliPosition { get; set; }
        public int mathematicsPosition { get; set; }
        public int physicsPosition { get; set; }
        public int chemistryPosition { get; set; }
        public int biologyPosition { get; set; }
        public int historyPosition { get; set; }
        public int geographyPosition { get; set; }
        public int crePosition { get; set; }
        public int homesciencePosition { get; set; }
        public int agriculturePosition { get; set; }
        public int businessPosition { get; set; }
        public int classPosition { get; set; }
        public int TotalPoints { get; set; }
        public string EnglishName { get { return "English"; } }
        public string KiswahiliName { get { return "Kiswahili"; } }
        public string MathematicsName { get { return "Mathematics"; } }
        public string PhysicsName { get { return "Physics"; } }
        public string ChemistryName { get { return "Chemistry"; } }
        public string BiologyName { get { return "Biology"; } }
        public string HistoryAndGovermentName { get { return "History and Goverment"; } }
        public string GeographyName { get { return "Geography"; } }
        public string ChristianReligionName { get { return "Christian  Religion"; } }
        public string HomeScienceName { get { return "HomeScience"; } }
        public string AgricultureName { get { return "Agriculture"; } }
        public string BusinessStudiesName { get { return "Business Studies"; } }
    }
}
