using System.Xml;

namespace FimiAppApi.Repository
{
    public class ParentRepository : IParentRepository
    {
        private readonly DapperContext _dapperContext;

        public ParentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<ParentModel>> GetParents()
        {
            string sql = "SELECT* FROM Parent";
            return await _dapperContext.LoadData<ParentModel, dynamic>(sql, new { });
        }
        public async Task<ParentModel> GetParentById(int nationalId)
        {
            string sql = "SELECT " +
                                "*" +
                         "FROM Parent WHERE Parent.NationalId = @NationalId";
            var parameters = new DynamicParameters();
            parameters.Add("NationalId", nationalId);
            return await _dapperContext.LoadSingleData<ParentModel,dynamic>(sql, parameters);
        }
        public async Task<ParentModel> CreateParent(ParentModel parent)
        {
            string sql = "INSERT INTO Parent " +
                                "(NationalId,FirstName,MiddleName,Surname,PhoneNumber,Gender) " +
                         "VALUES " +
                         "(@NationalId,@FirstName,@MiddleName,@Surname,@PhoneNumber,@Gender); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("NationalId", parent.NationalId, DbType.Int32);
            parameters.Add("FirstName", parent.FirstName, DbType.String);
            parameters.Add("MiddleName", parent.MiddleName, DbType.String);
            parameters.Add("Surname", parent.Surname, DbType.String);
            parameters.Add("PhoneNumber", parent.PhoneNumber, DbType.String);
            parameters.Add("Gender", parent.Gender, DbType.String);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new ParentModel
            {
                ParentId = id,
                NationalId = parent.NationalId,
                FirstName = parent.FirstName,
                MiddleName = parent.MiddleName,
                Surname = parent.Surname,
                PhoneNumber = parent.PhoneNumber,
                Gender = parent.Gender
            };
            return createdModel;
        }
    }
}
