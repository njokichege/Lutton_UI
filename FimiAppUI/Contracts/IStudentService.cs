namespace FimiAppUI.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}