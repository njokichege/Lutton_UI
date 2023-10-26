namespace FimiAppApi.Contracts
{
    public interface IExamResultRepository
    {
        Task<IEnumerable<ExamResultModel>> GetYearlySchoolResults(int sessionYearId);
    }
}