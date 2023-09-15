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
        public async Task<int> GetHighestStudentNumber()
        {
            string sql = "SELECT max(student.StudentNumber) FROM Student";

            return await _dapperContext.LoadSingleData<int,dynamic>(sql, new {});
        }
        public async Task<ParentStudentModel> AddParentStudent(int parentNationalId)
        {
            var student = await GetHighestStudentNumber();
            string sql = "INSERT INTO ParentStudent" +
                                "(StudentNumber,ParentNationalId) " +
                         "VALUES(@StudentNumber,@ParentNationalId); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("StudentNumber", student, DbType.Int32);
            parameters.Add("ParentNationalId", parentNationalId, DbType.Int32);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new ParentStudentModel
            {
                ParentStudentId = id,
                StudentNumber = student,
                ParentNationalId = parentNationalId
            };
            return createdModel;
        }
    }
}
