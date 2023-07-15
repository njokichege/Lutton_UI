namespace FimiAppUI.Contracts
{
    public interface IStudentService
    {
        Task<HttpResponseMessage> AddStudent(StudentModel student);
        Task<StudentModel> GetStudentByStudentNumber(int studentNumber);
        Task<IEnumerable<StudentModel>> GetStudents();
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}