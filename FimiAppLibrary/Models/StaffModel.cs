namespace FimiAppLibrary.Models
{
    public class StaffModel
    {
        public int NationalId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Designation { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {Surname}";
            }
        }
    }
}
