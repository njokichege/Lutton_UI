namespace FimiAppLibrary.DataAccess
{
    public class SessionYearData : ISessionYearData
    {
        private readonly ISqlDbConnection _db;

        public SessionYearData(ISqlDbConnection db)
        {
            _db = db;
        }
        public Task<List<SessionYearModel>> GetAllSessionYears()
        {
            string sql = "SELECT * FROM dbo.SessionYear";
            return _db.LoadData<SessionYearModel, dynamic>(sql, new { });
        }
        public Task<SessionYearModel> FindSessionYear(string sessionYear)
        {
            string sql = $"SELECT SessionYear.SessionYearId FROM SessionYear WHERE SessionYear = {sessionYear}";
            return _db.LoadSingleData<SessionYearModel, dynamic>(sql, new { });
        }
        public Task AddSessionYear(SessionYearModel sessionYearModel)
        {
            string sql = @"INSERT INTO SessionYear(SessionYear)VALUES(@SessionYear)";
            return _db.SaveData(sql, sessionYearModel);
        }
    }
}
