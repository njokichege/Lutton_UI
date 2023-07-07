namespace FimiAppUI.Contracts
{
    public interface IStudentService
    {
        Task<StudentModel> GetStudentByStudentNumber(int studentNumber);
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}