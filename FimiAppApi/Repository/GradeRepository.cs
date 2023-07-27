namespace FimiAppApi.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DapperContext _dapperContext;

        public GradeRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<GradeModel>> GetAllGrades()
        {
            string sql = "SELECT * FROM Grade";
            return await _dapperContext.LoadData<GradeModel, dynamic>(sql, new { });
        }
        public async Task<int> AddGrades(GradeModel grade)
        {
            string sql = "INSERT INTO " +
                            "Grade " +
                                "(Grade,StartGrade,EndGrade) " +
                            "VALUES " +
                                "(@Grade,@StartGrade,@EndGrade)";
            var parameters = new DynamicParameters();
            parameters.Add("Grade", grade.Grade, DbType.String);
            parameters.Add("StartGrade", grade.StartGrade, DbType.Double);
            parameters.Add("EndGrade", grade.EndGrade, DbType.Double);

            var id = await _dapperContext.CreateData<GradeModel, dynamic>(sql, parameters);
            return id;
        }
    }
}
