namespace FimiAppUI.Contracts
{
    public interface IStudentClassService
    {
        Task<HttpResponseMessage> AddStudentClass(StudentClassModel studentClassModel);
    }
}