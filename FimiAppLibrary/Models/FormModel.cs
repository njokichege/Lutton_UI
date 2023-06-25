namespace FimiAppLibrary.Models
{
    public class FormModel
    {
        public int FormId { get; set; }
        public string Form { get; set; }
        public ICollection<ClassModel> Classes { get; set; }
        public FormModel()
        {
            Classes = new List<ClassModel>();
        }
    }
}
