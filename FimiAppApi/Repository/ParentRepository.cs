namespace FimiAppApi.Repository
{
    public class ParentRepository : IParentRepository
    {
        private readonly DapperContext _dapperContext;

        public ParentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<ParentModel> GetParentById(int nationalId)
        {
            string sql = "SELECT " +
                                "*" +
                         "FROM Parent WHERE Parent.NationalId = @NationalId";
            var parameters = new DynamicParameters();
            parameters.Add("NationalId", nationalId);
            return await _dapperContext.LoadSingleData<ParentModel>(sql, parameters);
        }
    }
}
