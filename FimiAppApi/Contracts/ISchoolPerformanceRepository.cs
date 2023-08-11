namespace FimiAppApi.Contracts
{
    public interface ISchoolPerformanceRepository
    {
        Task<IEnumerable<SchoolPerformanceModel>> GetSchoolPerformances(int sessionYearId, int termId, int examTypeId);
    }
}
