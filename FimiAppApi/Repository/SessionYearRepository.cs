using FimiAppApi.Context;
using System.Net.Http;
using System.Xml;

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
            return await _dapperContext.LoadSingleData<SessionYearModel,dynamic>(sql, parameters);
        }
        public async Task<int> GetSessionYearByStartDate(DateTime dateTime)
        {
            string sql = "select\n\tSessionYearId\nfrom SessionYear\nwhere StartDate = @StartDate;";
            var parameters = new DynamicParameters();
            parameters.Add("StartDate", dateTime);
            return await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<SessionYearModel>> GetSessionYears()
        {
            string sql = "SELECT* FROM SessionYear";
            return await _dapperContext.LoadData<SessionYearModel, dynamic>(sql, new { });
        }
        public async Task<SessionYearModel> GetSessionYearById(int sessionId)
        {
            string sql = "SELECT * FROM SessionYear where SessionYearId = @SessionYearId;";
            var parameteres = new DynamicParameters();
            parameteres.Add("SessionYearId", sessionId, DbType.Int32);
            return await _dapperContext.LoadSingleData<SessionYearModel, dynamic>(sql, parameteres);
        }
        public async Task<SessionYearModel> CreateSessionYear(SessionYearModel sessionYear)
        {
            string sql = "INSERT INTO SessionYear" +
                                "(StartDate, EndDate) " +
                         "VALUES" +
                                "(@StartDate,@EndDate); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("StartDate", sessionYear.StartDate, DbType.DateTime);
            parameters.Add("EndDate", sessionYear.EndDate, DbType.DateTime);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new SessionYearModel
            {
                SessionYearId = id,
                StartDate = sessionYear.StartDate,
                EndDate = sessionYear.EndDate
            };
            return createdModel;
        }
    }
}
