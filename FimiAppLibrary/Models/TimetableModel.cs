namespace FimiAppLibrary.Models
{
    public  class TimetableModel
    {
        public int TimetableId { get; set; }
        public int Code { get; set; }
        public int ClassId { get; set; }
        public int TimeslotId { get; set; }
        public int TeacherId { get; set; }
        public string DayOfTheWeek { get; set; }
        public List<SubjectModel> Subject { get; set; } = new List<SubjectModel>();
        public ClassModel ClassModel { get; set; }
        public TimeSlotModel TimeSlot { get; set; }
        public List<TeacherModel> Teacher { get; set; } = new List<TeacherModel>(); 
    }
}
