namespace FimiAppUI.Contracts
{
    public interface IStudentClassService
    {
        Task<HttpResponseMessage> AddStudentClass(StudentClassModel studentClassModel);
        Task<StudentClassModel> GetStudentClass(int classId, int studentNumber);
    }
}