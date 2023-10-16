namespace FimiAppUI.Contracts
{
    public interface IStudentService
    {
        Task<HttpResponseMessage> AddExistingStudent(StudentModel student);
        Task<HttpResponseMessage> AddStudent(StudentModel student);
        Task<IEnumerable<StudentModel>> GetAllStudentsBySessionYear(int sesionYearId);
        Task<StudentModel> GetStudentByStudentNumber(int studentNumber);
        Task<IEnumerable<StudentModel>> GetStudents();
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}