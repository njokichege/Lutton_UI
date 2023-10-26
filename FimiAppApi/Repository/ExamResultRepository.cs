namespace FimiAppApi.Repository
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly DapperContext _dapperContext;

        public ExamResultRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<ExamResultModel>> GetYearlySchoolResults(int sessionYearId)
        {
            string sql = "select " +
                            "Form.Form," +
                            "Stream.Stream," +
                            "Term.TermName," +
                            "avg(ExamResult.Marks) AS Total " +
                         "from ExamResult " +
                         "inner join StudentClass on StudentClass.StudentClassId = ExamResult.StudentClassId " +
                         "inner join Exam on Exam.ExamId = ExamResult.ExamId " +
                         "inner join Term on Term.TermId = Exam.TermId " +
                         "inner join Class on Class.ClassId = StudentClass.ClassId " +
                         "inner join Form on Form.FormId = Class.FormId " +
                         "inner join Stream on Stream.StreamId = Class.StreamId " +
                         "where Class.SessionYearId = @SessionYearId " +
                         "group by " +
                            "Form.Form," +
                            "Stream.Stream," +
                            "Term.TermName;";

            var parameters = new DynamicParameters();
            parameters.Add("SessionYearId", sessionYearId);

            return await _dapperContext.LoadData<ExamResultModel, dynamic>(sql, parameters);
        }
    }
}
