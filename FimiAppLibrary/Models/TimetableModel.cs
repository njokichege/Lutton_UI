  namespace FimiAppLibrary.Models
{
    public  class TimetableModel
    {
        public int TimetableId { get; set; }
        public int ClassId { get; set; }
        public int TimeslotId { get; set; }
        public string DayOfTheWeek { get; set; }
        public int LabId { get; set; }
        public List<TeacherSubjectModel> TeacherSubjects { get; set; } = new List<TeacherSubjectModel>();
        public ClassModel ClassModel { get; set; }
        public TimeSlotModel TimeSlot { get; set; }
        public LabModel Lab { get; set; }
    }
}
