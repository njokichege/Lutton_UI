
namespace FimiAppApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DapperContext _context;
        public ClassRepository(DapperContext context)
        {
            _context = context;
        }
        public Task<List<ClassModel>> GetClass()
        {
            string sql = "SELECT* FROM dbo.Class";
            return _context.LoadData<ClassModel, dynamic>(sql, new { });
        }
        public Task InsertClass(ClassModel student)
        {
            string sql = "";
            return _context.SaveData(sql, student);
        }
    }
}
