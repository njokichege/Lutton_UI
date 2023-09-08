using Microsoft.SqlServer.Server;

namespace FimiAppApi.Repository
{
    public class FormRepository : IFormRepository
    {
        private readonly DapperContext _dapperContext;

        public FormRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }
        public async Task<IEnumerable<FormModel>> GetForms()
        {
            string sql = "SELECT* FROM Form";
            return await _dapperContext.LoadData<FormModel, dynamic>(sql, new { });
        }
        public async Task<FormModel> GetFormById(int formId)
        {
            string sql = "SELECT * FROM Form WHERE FormId = @FormId";
            var parameteres = new DynamicParameters();
            parameteres.Add("FormId", formId, DbType.Int32);
            return await _dapperContext.LoadSingleData<FormModel, dynamic>(sql, parameteres);
        }
    }
}
