namespace FimiAppUI.Contracts
{
    public interface IReportService
    {
        Task<HttpResponseMessage> GetStudentListStudent(List<int> students);
    }
}