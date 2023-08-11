namespace FimiAppUI.Contracts
{
    public interface ISchoolPerformanceService
    {
        Task<IEnumerable<SchoolPerformanceModel>> GetSchoolPerformances(int sessionYearId, int termId, int examTypeId);
    }
}
