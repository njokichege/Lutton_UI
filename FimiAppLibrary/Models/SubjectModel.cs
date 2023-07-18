namespace FimiAppLibrary.Models
{
    public class SubjectModel
    {
        public int Code { get; set; }
        public string SubjectName { get; set; }
        public int SubjectCategoryId { get; set; }
        public SubjectCategoryModel SubjectCategory { get; set; }
    }
}
