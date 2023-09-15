namespace FimiAppApi.Contracts
{
    public interface IStudentRepository
    {
        Task<StudentModel> CreateStudent(StudentModel student);
        Task<IEnumerable<StudentModel>> GetAllStudents();
        Task<StudentModel> GetStudent(int studentNumber);
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}
