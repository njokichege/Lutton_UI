namespace FimiAppApi.Repository
{
    public class ParentStudentRepository : IParentStudentRepository
    {
        private readonly DapperContext _dapperContext;

        public ParentStudentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<StudentModel> GetHighestStudentNumber()
        {
            string sql = "DECLARE @stnumafter INT;\r\nSELECT @stnumafter = MAX(StudentNumber) FROM Student\r\nSELECT * FROM Student\r\nWHERE StudentNumber = @stnumafter";

            return await _dapperContext.LoadSingleData<StudentModel,dynamic>(sql, new {});
        }
        public async Task<int> AddParentStudent(int parentNationalId)
        {
            var student = await GetHighestStudentNumber();
            string sql = "INSERT INTO ParentStudent" +
                                "(StudentNumber,ParentNationalId) " +
                         "VALUES(@StudentNumber,@ParentNationalId)";
            var parameters = new DynamicParameters();
            parameters.Add("StudentNumber", student.StudentNumber, DbType.Int32);
            parameters.Add("ParentNationalId", parentNationalId, DbType.Int32);

            return await _dapperContext.CreateData<StudentModel, dynamic>(sql, parameters);
        }
    }
}
