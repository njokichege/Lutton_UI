namespace FimiAppApi.Contracts
{
    public interface IStudentClassRepository
    {
        Task<StudentClassModel> AddStudentClass(StudentClassModel studentClassModel);
        Task<StudentModel> GetStudentClassById(int studentClassId);
    }
}