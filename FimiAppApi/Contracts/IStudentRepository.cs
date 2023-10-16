namespace FimiAppApi.Contracts
{
    public interface IStudentRepository
    {
        Task<StudentModel> AddExistingStudent(StudentModel student);
        Task<StudentModel> CreateStudent(StudentModel student);
        Task<IEnumerable<StudentModel>> GetAllStudents();
        Task<IEnumerable<StudentModel>> GetAllStudentsBySessionYear(int sesionYearId);
        Task<StudentModel> GetStudent(int studentNumber);
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}
