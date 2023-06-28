namespace FimiAppApi.Contracts
{
    public interface ISessionYearRepository
    {
        Task<int> CreateSessionYear(SessionYearModel sessionYear);
        Task<SessionYearModel> GetSessionYearByDates(SessionYearModel sessionYear);
        Task<IEnumerable<SessionYearModel>> GetSessionYears();
    }
}
