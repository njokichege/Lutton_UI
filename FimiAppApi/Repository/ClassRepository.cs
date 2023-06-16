
namespace FimiAppApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DapperContext _context;
        public ClassRepository(DapperContext context)
        {
            _context = context;
        }

        public Task<ClassModel> GetClass(int id)
        {
            string sql = "SELECT * FROM dbo.Class WHERE ClassId = @Id";
            return _context.LoadSingleData<ClassModel, dynamic>(sql, new { id });
        }

        public Task<IEnumerable<ClassModel>> GetClasses()
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
