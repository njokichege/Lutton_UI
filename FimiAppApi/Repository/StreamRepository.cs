namespace FimiAppApi.Repository
{
    public class StreamRepository : IStreamRepository
    {
        private readonly DapperContext _dapperContext;

        public StreamRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<StreamModel>> GetStreams()
        {
            string sql = "SELECT* FROM Stream";
            return await _dapperContext.LoadData<StreamModel, dynamic>(sql, new { });
        }
        public async Task<StreamModel> GetStreamById(int streamId)
        {
            string sql = "SELECT * FROM Stream WHERE StreamId = @StreamId";
            var parameteres = new DynamicParameters();
            parameteres.Add("StreamId", streamId, DbType.Int32);
            return await _dapperContext.LoadSingleData<StreamModel, dynamic>(sql, parameteres);
        }
        public async Task<int> GetStreamByName(string streamName)
        {
            string sql = "select " +
                            "StreamId " +
                         "from Stream " +
                         "where Stream = @Stream;";
            var parameteres = new DynamicParameters();
            parameteres.Add("Stream", streamName);
            return await _dapperContext.LoadSingleData<int, dynamic>(sql, parameteres);
        }
    }
}
