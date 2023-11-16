namespace FimiAppLibrary.Models
{
    public class EventModel
    {
        public int EventId { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public int EventTypeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public EventTypeModel EventType { get; set; }
    }
}
