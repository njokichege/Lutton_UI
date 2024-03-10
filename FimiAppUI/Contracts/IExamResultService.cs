
namespace FimiAppUI.Contracts
{
    public interface IExamResultService
    {
        Task<HttpResponseMessage> AddExamResult(ExamResultModel examResultModel);
        Task<IEnumerable<ExamResultModel>> GetYearlySchoolResults(int sessionYearId);
    }
}