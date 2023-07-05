namespace FimiAppApi.Contracts
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId);
    }
}
