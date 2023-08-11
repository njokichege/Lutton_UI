namespace FimiAppApi.Repository
{
    public class TermRepository : ITermRepository
    {
        private readonly DapperContext _dapperContext;

        public TermRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<TermModel>> GetAllTerms()
        {
            string sql = "SELECT * FROM Term";
            return await _dapperContext.LoadData<TermModel, dynamic>(sql, new { });
        }
    }
}
