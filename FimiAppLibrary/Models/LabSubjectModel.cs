namespace FimiAppLibrary.Models
{
    public class LabSubjectModel
    {
        public int LabSubjectId { get; set; }
        public int LabId { get; set; }
        public int Code { get; set; }
        public LabModel Lab { get; set; }
        public SubjectModel Subject { get; set; }
    }
}
