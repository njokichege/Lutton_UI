using FimiAppApi.Context;
using System.Net.Http;

namespace FimiAppApi.Repository
{
    public class SessionYearRepository : ISessionYearRepository
    {
        private readonly DapperContext _dapperContext;

        public SessionYearRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<SessionYearModel> GetSessionYearByDates(SessionYearModel sessionYear)
        {
            string sql = "SELECT * " +
                         "FROM SessionYear " +
                         "WHERE StartDate = @StartDate " +
                         "AND EndDate = @EndDate";
            var parameters = new DynamicParameters();
            parameters.Add("StartDate", sessionYear.StartDate, DbType.DateTime);
            parameters.Add("EndDate", sessionYear.EndDate, DbType.DateTime);
            return await _dapperContext.LoadSingleData<SessionYearModel, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<SessionYearModel>> GetSessionYears()
        {
            string sql = "SELECT* FROM dbo.SessionYear";
            return await _dapperContext.LoadData<SessionYearModel, dynamic>(sql, new { });
        }
        public async Task<int> CreateSessionYear(SessionYearModel sessionYear)
        {
            string sql = "INSERT INTO SessionYear" +
                                "(StartDate, EndDate) " +
                         "VALUES" +
                                "(@StartDate,@EndDate)";
            var parameters = new DynamicParameters();
            parameters.Add("StartDate", sessionYear.StartDate, DbType.DateTime);
            parameters.Add("EndDate", sessionYear.EndDate, DbType.DateTime);

            var id = await _dapperContext.CreateData<SessionYearModel, dynamic>(sql, parameters);
            return id;
        }
    }
}
