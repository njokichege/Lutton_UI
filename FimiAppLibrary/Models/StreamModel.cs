namespace FimiAppLibrary.Models
{
    public class StreamModel
    {
        public int StreamId { get; set; }
        public string Stream { get; set; }
        public List<ClassModel> Classes { get; set; } = new List<ClassModel>();
    }
}
