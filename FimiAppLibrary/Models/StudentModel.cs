namespace FimiAppLibrary.Models;
public class StudentModel
{
    public int StudentNumber { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime AdmissionDate { get; set; }
    public int KCPEResult { get; set; }
    public string PhoneNumber { get; set; }
    public List<ClassModel> StudentClasses { get; set; } = new List<ClassModel>();
    public string StudentName()
    {
        return $"{FirstName} {MiddleName} {Surname}";
    }
    public int Age()
    {
        return DateTime.Now.Year - DateOfBirth.Value.Year;
    }
}
