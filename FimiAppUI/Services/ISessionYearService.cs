namespace FimiAppUI.Services
{
    public interface ISessionYearService
    {
        Task<IEnumerable<SessionYearModel>> GetSessionYear();
    }
}
