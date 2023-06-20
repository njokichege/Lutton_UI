using FimiAppApi.Context;

namespace FimiAppApi.Repository
{
    public class SessionYearRepository : ISessionYearRepository
    {
        private readonly DapperContext _dapperContext;

        public SessionYearRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<SessionYearModel>> GetSessionYears()
        {
            string sql = "SELECT* FROM dbo.SessionYear";
            return await _dapperContext.LoadData<SessionYearModel, dynamic>(sql, new { });
        }
    }
}
