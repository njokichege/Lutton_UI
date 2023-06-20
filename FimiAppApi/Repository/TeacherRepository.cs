namespace FimiAppApi.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DapperContext _dapperContext;

        public TeacherRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<TeacherModel>> GetTeachers()
        {
            string sql = "SELECT* FROM dbo.Teacher";
            return await _dapperContext.LoadData<TeacherModel, dynamic>(sql, new { });
        }
    }
}
