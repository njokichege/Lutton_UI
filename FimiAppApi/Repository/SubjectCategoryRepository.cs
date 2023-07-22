namespace FimiAppApi.Repository
{
    public class SubjectCategoryRepository : ISubjectCategoryRepository
    {
        private readonly DapperContext _dapperContext;

        public SubjectCategoryRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<SubjectCategoryModel>> GetCategories()
        {
            string sql = "SELECT* FROM dbo.SubjectCategory";
            return await _dapperContext.LoadData<SubjectCategoryModel, dynamic>(sql, new { });
        }
    }
}
