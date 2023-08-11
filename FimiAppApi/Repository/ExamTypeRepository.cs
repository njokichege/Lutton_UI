namespace FimiAppApi.Repository
{
    public class ExamTypeRepository : IExamTypeRepository
    {
        private readonly DapperContext _dapperContext;

        public ExamTypeRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<ExamTypeModel>> GetAllExamTypes()
        {
            string sql = "SELECT * FROM ExamType";
            return await _dapperContext.LoadData<ExamTypeModel, dynamic>(sql, new { });
        }
    }
}
