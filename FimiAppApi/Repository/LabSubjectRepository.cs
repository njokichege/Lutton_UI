namespace FimiAppApi.Repository
{
    public class LabSubjectRepository : ILabSubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public LabSubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<List<LabSubjectModel>> GetAllLabSubjects()
        {
            string sql = "SELECT * FROM LabSubject;";

            return await _dapperContext.LoadData<LabSubjectModel, dynamic>(sql, new { });
        }
    }
}
