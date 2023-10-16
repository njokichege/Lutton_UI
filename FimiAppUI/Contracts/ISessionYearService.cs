namespace FimiAppUI.Contracts
{
    public interface ISessionYearService
    {
        Task<HttpResponseMessage> CreateSessionYear(SessionYearModel sessionYear);
        Task<int> GetSessionYearByStartDate(string date);
        Task<IEnumerable<SessionYearModel>> GetSessionYears();
    }
}
