namespace FimiAppLibrary.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string TeacherType { get; set; }
        public string TSCNumber { get; set; }
        public int NationalId { get; set; }
        public StaffModel Staff { get; set; }
        public string FullName()
        {
            return $"{Staff.FirstName} {Staff.MiddleName} {Staff.Surname}";
        }
    }
}
