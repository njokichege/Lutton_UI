namespace FimiAppLibrary.Models
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string TeacherType { get; set; }
        public string TSCNumber { get; set; }
        public int NationalId { get; set; }
        public StaffModel Staff { get; set; } 
        public string Initials()
        {
            string initials = $"{Staff.FirstName.ElementAt(0)}{Staff.MiddleName.ElementAt(0)}{Staff.Surname.ElementAt(0)}";
            return initials.ToUpper();
        }
    }
}
