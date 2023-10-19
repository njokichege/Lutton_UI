namespace FimiAppApi.Repository
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public StudentSubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<StudentSubjectModel> GetStudentSubjectById(int studentSubjectModelId)
        {
            string sql = "SELECT * FROM studentsubject where StudentSubjectId = @StudentSubjectId;";

            var parameteres = new DynamicParameters();
            parameteres.Add("StudentSubjectId", studentSubjectModelId);

            return await _dapperContext.LoadSingleData<StudentSubjectModel, dynamic>(sql, parameteres);
        }
        public async Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId)
        {
            string sql = "SELECT \r\n    SubjectList.SubjectCode,\r\n    SubjectList.SubjectName,\r\n    SubjectList.StudentCount\r\nFROM SubjectList \r\nWHERE ClassId = @ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId, DbType.Int32);

            return await _dapperContext.LoadData<ClassSubjectList, dynamic>(sql, parameters);
        }
        public async Task<List<StudentSubjectModel>> GetSubjectsByStudentNumber(int studentNumber)
        {
            string sql = "SELECT " +
                            "StudentSubject.*, " +
                            "Student.*, " +
                            "subjects.*," +
                            "subjectcategory.* " +
                         "FROM StudentSubject " +
                         "INNER JOIN Student ON Student.StudentNumber = StudentSubject.StudentNumber " +
                         "INNER JOIN subjects ON subjects.Code = StudentSubject.Code " +
                         "inner join subjectcategory on subjects.SubjectCategoryId = subjectcategory.SubjectCategoryId  " +
                         "WHERE Student.StudentNumber = @StudentNumber;";
            var parameters = new DynamicParameters();
            parameters.Add("StudentNumber", studentNumber, DbType.Int32);

            Type[] types =
            {
                 typeof(StudentSubjectModel),
                 typeof(StudentModel),
                 typeof(SubjectModel),
                 typeof(SubjectCategoryModel),
            };
            Func<object[], StudentSubjectModel> map = delegate (object[] obj)
            {
                StudentSubjectModel studentSubjectModel = obj[0] as StudentSubjectModel;
                StudentModel studentModel = obj[1] as StudentModel;
                SubjectModel subjectModel = obj[2] as SubjectModel;
                SubjectCategoryModel subjectCategoryModel = obj[3] as SubjectCategoryModel;

                studentSubjectModel.Student = studentModel;
                studentSubjectModel.Subject = subjectModel;
                subjectModel.SubjectCategory = subjectCategoryModel;

                return studentSubjectModel;
            };
            string splitOn = "StudentNumber,Code,SubjectCategoryId";
            return await _dapperContext.MapMultipleObjects<StudentSubjectModel, dynamic>(sql, types, map, splitOn, parameters);
        }
        public async Task<StudentSubjectModel> AddStudentSubject(StudentSubjectModel studentSubjectModel)
        {
            string sql = "INSERT INTO StudentSubject " +
                            "(StudentNumber,Code) " +
                         "VALUES " +
                            "(@StudentNumber,@Code); SELECT LAST_INSERT_ID();";

            var parameters = new DynamicParameters();
            parameters.Add("StudentNumber", studentSubjectModel.StudentNumber);
            parameters.Add("Code", studentSubjectModel.Code);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);

            var createdModel = new StudentSubjectModel
            {
                StudentSubjectId = id,
                StudentNumber = studentSubjectModel.StudentNumber,
                Code = studentSubjectModel.Code
            };
            return createdModel;
        }
        public async Task<StudentSubjectModel> FindEntry(int studentNumber, int code)
        {
            string sql = "SELECT * FROM studentsubject where StudentNumber = @StudentNumber and Code = @Code;";

            var parameters = new DynamicParameters();
            parameters.Add("StudentNumber", studentNumber);
            parameters.Add("Code", code);

            return await _dapperContext.LoadSingleData<StudentSubjectModel, dynamic>(sql, parameters);
        }
    }
}
