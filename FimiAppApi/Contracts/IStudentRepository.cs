namespace FimiAppApi.Contracts
{
    public interface IStudentRepository
    {
        Task<StudentModel> GetStudent(int studentNumber);
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}
