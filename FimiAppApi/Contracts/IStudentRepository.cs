namespace FimiAppApi.Contracts
{
    public interface IStudentRepository
    {
        Task<int> CreateStudent(StudentModel student);
        Task<StudentModel> GetStudent(int studentNumber);
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}
