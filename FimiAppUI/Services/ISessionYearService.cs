namespace FimiAppUI.Services
{
    public interface ISessionYearService
    {
        Task<HttpResponseMessage> CreateSessionYear(SessionYearModel sessionYear);
        Task<IEnumerable<SessionYearModel>> GetSessionYear();
    }
}
