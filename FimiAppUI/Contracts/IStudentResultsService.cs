
namespace FimiAppUI.Contracts
{
    public interface IStudentResultsService
    {
        Task<IEnumerable<StudentResultsModel>> GetStudentResultsByClass(int classId);
    }
}