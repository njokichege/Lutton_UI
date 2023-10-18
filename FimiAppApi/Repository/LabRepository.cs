using FimiAppApi.Context;

namespace FimiAppApi.Repository
{
    public class LabRepository : ILabRepository
    {
        private readonly DapperContext _dapperContext;

        public LabRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<LabModel>> GetAllLabs()
        {
            string sql = "SELECT * FROM development_kasarini.lab;";

            return await _dapperContext.LoadData<LabModel, dynamic>(sql, new { });
        }
    }
}
