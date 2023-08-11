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
            string sql = "SELECT* FROM dbo.Stream";
            return await _dapperContext.LoadData<StreamModel, dynamic>(sql, new { });
        }
        public async Task<StreamModel> GetStreamById(int streamId)
        {
            string sql = "SELECT * FROM Stream WHERE StreamId = @StreamId";
            var parameteres = new DynamicParameters();
            parameteres.Add("StreamId", streamId, DbType.Int32);
            return await _dapperContext.LoadSingleData<StreamModel, dynamic>(sql, parameteres);
        }
    }
}
