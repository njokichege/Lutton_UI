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
    public ClassModel StudentClass { get; set; } = new ClassModel();
    public string StudentName()
    {
        return $"{FirstName} {MiddleName} {Surname}";
    }
    public int Age()
    {
        if(DateOfBirth  == null)
        {
            return 0;
        }
        else
        {
            return DateTime.Now.Year - DateOfBirth.Value.Year;
        }
    }
}
