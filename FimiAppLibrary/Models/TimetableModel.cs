namespace FimiAppLibrary.Models
{
    public  class TimetableModel
    {
        public int TimetableId { get; set; }
        public int Code { get; set; }
        public int ClassId { get; set; }
        public int TimeslotId { get; set; }
        public int TeacherId { get; set; }
        public SubjectModel Subject { get; set; }
        public ClassModel ClassModel { get; set; }
        public TimeSlotModel TimeSlot { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}
