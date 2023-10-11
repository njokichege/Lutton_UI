namespace FimiAppUI.Contracts
{
    public interface ISessionYearService
    {
        Task<HttpResponseMessage> CreateSessionYear(SessionYearModel sessionYear);
        Task<int> GetSessionYearByStartDate(DateTime dateTime);
        Task<IEnumerable<SessionYearModel>> GetSessionYears();
    }
}
