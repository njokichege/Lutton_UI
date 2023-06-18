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
            string sql = "SELECT* FROM dbo.Form";
            return await _dapperContext.LoadData<FormModel, dynamic>(sql, new { });
        }
    }
}
