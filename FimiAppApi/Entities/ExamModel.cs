namespace FimiAppApi.Entities
{
    public class ExamModel
    {
        public int ExamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExamTypeId { get; set; }
    }
}
