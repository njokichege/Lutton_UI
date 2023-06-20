namespace FimiAppLibrary.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public int FormId { get; set; }
        public List<FormModel> Forms { get; set; }
        public int StreamId { get; set; }
        public int SessionYearId { get; set; }
        public int Capacity { get; set; }
        public int ClassTeacherId { get; set; }
        public int GradeId { get; set; }
    }
}
