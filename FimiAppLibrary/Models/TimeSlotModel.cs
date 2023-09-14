namespace FimiAppLibrary.Models
{
    public class TimeSlotModel
    {
        public int TimeslotId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string IsBeforeBreak { get; set; }
        public string IsAfterBreak { get; set; }
        public string TimeSlotString()
        {
            return $"{StartTime} - {EndTime}";
        }
    }
}
