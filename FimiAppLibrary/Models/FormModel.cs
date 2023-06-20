namespace FimiAppLibrary.Models
{
    public class FormModel
    {
        public int FormId { get; set; }
        public int Form { get; set; }
        public List<ClassModel> Classes { get; set; } = new List<ClassModel>();
    }
}
