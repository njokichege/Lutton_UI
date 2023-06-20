namespace FimiAppApi.Contracts
{
    public interface ISessionYearRepository
    {
        Task<IEnumerable<SessionYearModel>> GetSessionYears();
    }
}
