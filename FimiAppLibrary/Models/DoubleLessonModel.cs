namespace FimiAppLibrary.Models
{
    public class DoubleLessonModel
    {
        public int DoubleLessonId { get; set; }
        public TimeSlotModel FirstSlot { get; set; }
        public TimeSlotModel SecondSlot { get; set; }
    }
}
