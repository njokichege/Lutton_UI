namespace FimiAppApi.Repository
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public StudentSubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId)
        {
            string sql = "SELECT \r\n    SubjectList.SubjectCode,\r\n    SubjectList.SubjectName,\r\n    SubjectList.StudentCount\r\nFROM SubjectList \r\nWHERE ClassId = @ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId, DbType.Int32);

            return await _dapperContext.LoadData<ClassSubjectList, dynamic>(sql, parameters);
        }
    }
}
