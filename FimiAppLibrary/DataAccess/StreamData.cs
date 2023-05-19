namespace FimiAppLibrary.DataAccess
{
    public class StreamData : IStreamData
    {
        private readonly ISqlDbConnection _db;

        public StreamData(ISqlDbConnection db)
        {
            _db = db;
        }
        public Task<List<StreamModel>> GetAllStreams()
        {
            string sql = "SELECT * FROM dbo.Stream";
            return _db.LoadData<StreamModel, dynamic>(sql, new { });
        }
        public Task AddStream(StreamModel streamModel)
        {
            string sql = @"INSERT INTO Stream(Stream)VALUES(@Stream)";
            return _db.SaveData(sql, streamModel);
        }
    }
}
