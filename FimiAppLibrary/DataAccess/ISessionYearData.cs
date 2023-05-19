namespace FimiAppLibrary.DataAccess
{
    public interface ISessionYearData
    {
        Task AddSessionYear(SessionYearModel sessionYearModel);
        Task<SessionYearModel> FindSessionYear(string sessionYear);
        Task<List<SessionYearModel>> GetAllSessionYears();
    }
}