using System.Xml;

namespace FimiAppApi.Repository
{
    public class ParentStudentRepository : IParentStudentRepository
    {
        private readonly DapperContext _dapperContext;

        public ParentStudentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<ParentStudentModel> GetParentStudentById(int id)
        {
            string sql = "SELECT * FROM ParentStudent WHERE ParentStudentId = @ParentStudentId";
            var parameteres = new DynamicParameters();
            parameteres.Add("ParentStudentId", id);
            return await _dapperContext.LoadSingleData<ParentStudentModel, dynamic>(sql, parameteres);
        }
        public async Task<ParentStudentModel> AddParentStudent(ParentStudentModel parentStudent)
        {
            string sql = "INSERT INTO ParentStudent " +
                            "(StudentNumber,ParentId) " +
                         "VALUES" +
                            "(@StudentNumber,@ParentId); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("StudentNumber", parentStudent.StudentNumber, DbType.Int32);
            parameters.Add("ParentId", parentStudent.ParentId, DbType.Int32);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new ParentStudentModel
            {
                ParentStudentId = id,
                StudentNumber = parentStudent.StudentNumber,
                ParentId = parentStudent.ParentId
            };
            return createdModel;
        }
    }
}
