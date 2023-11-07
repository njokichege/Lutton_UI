namespace FimiAppLibrary.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public string Text { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
    }
}
