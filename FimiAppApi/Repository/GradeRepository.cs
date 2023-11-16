using System.Xml;

namespace FimiAppApi.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DapperContext _dapperContext;

        public GradeRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<GradeModel> GetGradeById(int gradeId)
        {
            string sql = "SELECT * FROM Grade WHERE GradeId = @GradeId;";
            var parameteres = new DynamicParameters();
            parameteres.Add("GradeId", gradeId, DbType.Int32);
            return await _dapperContext.LoadSingleData<GradeModel, dynamic>(sql, parameteres);
        }
        public async Task<IEnumerable<GradeModel>> GetAllGrades()
        {
            string sql = "SELECT * FROM Grade";
            var data = await _dapperContext.LoadData<GradeModel, dynamic>(sql, new { });

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
        public async Task<GradeModel> AddGrades(GradeModel grade)
        {
            string sql = "INSERT INTO " +
                            "Grade " +
                                "(Grade,UpperLimit,LowerLimit,Points,Remarks) " +
                            "VALUES " +
                                "(@Grade,@UpperLimit,@LowerLimit,@Points,@Remarks); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("Grade", grade.Grade, DbType.String);
            parameters.Add("UpperLimit", grade.UpperLimit, DbType.Double);
            parameters.Add("Points", grade.Points);
            parameters.Add("Remarks", grade.Remarks);
            parameters.Add("LowerLimit", grade.LowerLimit, DbType.Double);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new GradeModel
            {
                GradeId = id,
                Grade = grade.Grade,
                UpperLimit = grade.UpperLimit,
                LowerLimit = grade.LowerLimit
            };
            return createdModel;
        }
    }
}
