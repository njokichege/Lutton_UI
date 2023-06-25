namespace FimiAppLibrary.Models
{
    public class StreamModel
    {
        public int StreamId { get; set; }
        public string Stream { get; set; }
        public ICollection<ClassModel> Classes { get; set; }
        public StreamModel()
        {
            Classes = new List<ClassModel>();
        }
    }
}
