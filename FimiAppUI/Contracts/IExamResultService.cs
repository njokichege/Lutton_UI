namespace FimiAppUI.Contracts
{
    public interface IExamResultService
    {
        Task<IEnumerable<ExamResultModel>> GetYearlySchoolResults(int sessionYearId);
    }
}