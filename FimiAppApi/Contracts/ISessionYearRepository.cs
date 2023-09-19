namespace FimiAppApi.Contracts
{
    public interface ISessionYearRepository
    {
        Task<SessionYearModel> CreateSessionYear(SessionYearModel sessionYear);
        Task<SessionYearModel> GetSessionYearByDates(SessionYearModel sessionYear);
        Task<SessionYearModel> GetSessionYearById(int sessionId);
        Task<IEnumerable<SessionYearModel>> GetSessionYears();
    }
}
