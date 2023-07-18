using FimiAppLibrary.Models;

namespace FimiAppApi.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public SubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<SubjectModel>> GetSubjects()
        {
            string sql = "SELECT* FROM dbo.Subjects";
            return await _dapperContext.LoadData<SubjectModel, dynamic>(sql, new { });
        }
    }
}
