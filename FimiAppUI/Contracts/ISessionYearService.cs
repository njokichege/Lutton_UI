namespace FimiAppUI.Contracts
{
    public interface ISessionYearService
    {
        Task<HttpResponseMessage> CreateSessionYear(SessionYearModel sessionYear);
        Task<IEnumerable<SessionYearModel>> GetSessionYears();
    }
}
