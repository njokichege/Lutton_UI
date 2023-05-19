namespace FimiAppLibrary.DataAccess
{
    public class FormData : IFormData
    {
        private readonly ISqlDbConnection _db;

        public FormData(ISqlDbConnection db)
        {
            _db = db;
        }
        public Task<List<FormModel>> GetAllForms()
        {
            string sql = "SELECT * FROM dbo.Form";
            return _db.LoadData<FormModel, dynamic>(sql, new { });
        }
        public Task AddForm(FormModel form)
        {
            string sql = @"INSERT INTO Form(Form)VALUES(@Form)";
            return _db.SaveData(sql, form);
        }
    }
}
