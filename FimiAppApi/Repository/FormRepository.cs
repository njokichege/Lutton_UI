namespace FimiAppApi.Repository
{
    public class FormRepository : IFormRepository
    {
        private readonly DapperContext _dapperContext;

        public FormRepository(DapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }

        public async Task<IEnumerable<FormModel>> ClassFormMapping()
        {
            string sql = "SELECT Class.ClassId,\r\n    Form.FormId,\r\n    Form.Form\r\nFROM Form\r\nINNER JOIN Class ON Class.FormId = Form.FormId";
            return await _dapperContext.ClassFormMapping(sql);
        }

        public async Task<IEnumerable<FormModel>> GetForms()
        {
            string sql = "SELECT* FROM dbo.Form";
            return await _dapperContext.LoadData<FormModel, dynamic>(sql, new { });
        }
    }
}
