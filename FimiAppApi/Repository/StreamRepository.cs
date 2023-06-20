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
    }
}
