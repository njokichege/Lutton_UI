namespace FimiAppLibrary.Models
{
    public class FormModel
    {
        public int FormId { get; set; }
        public int Form { get; set; }
        public ICollection<ClassModel> Classes { get; set; }
        public FormModel()
        {
            Classes = new List<ClassModel>();
        }
    }
}
