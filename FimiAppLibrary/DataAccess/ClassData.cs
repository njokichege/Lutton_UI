namespace FimiAppLibrary.DataAccess
{
    public class ClassData : IClassData
    {
        private readonly ISqlDbConnection _db;

        public ClassData(ISqlDbConnection db)
        {
            _db = db;
        }
        public Task<List<ClassModel>> GetClass()
        {
            string sql = "SELECT* FROM dbo.Class";
            return _db.LoadData<ClassModel, dynamic>(sql, new { });
        }
        public Task InsertClass(ClassModel student)
        {
            string sql = "";
            return _db.SaveData(sql, student);
        }
    }
}
