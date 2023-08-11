namespace FimiAppLibrary.Models
{
    public class TimeSlotModel
    {
        public int TimeslotId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string IsBeforeBreak { get; set; }
        public string IsAfterBreak { get; set; }
    }
}
