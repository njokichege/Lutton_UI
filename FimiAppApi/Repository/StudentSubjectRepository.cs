namespace FimiAppApi.Repository
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public StudentSubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<StudentSubjectModel>> MapStudentfOnSubject(int classId)
        {
            string sql = "SELECT  " +
                            "StudentSubject.Code, " +
                            "StudentSubject.StudentNumber, " +
                            "Subjects.Code, " +
                            "Subjects.SubjectName, " +
                            "Student.StudentNumber " +
                         "FROM StudentSubject   " +
                         "INNER JOIN Subjects ON Subjects.Code = StudentSubject.Code    " +
                         "INNER JOIN Student ON Student.StudentNumber = StudentSubject.StudentNumber    " +
                         "INNER JOIN StudentClass ON StudentClass.StudentNumber = Student.StudentNumber " +
                         "WHERE StudentClass.ClassId = @ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId, DbType.Int32);
            Type[] types =
            {
                 typeof(StudentSubjectModel),
                 typeof(SubjectModel),
                 typeof(StudentModel)
            };
            Func<object[], StudentSubjectModel> map = delegate (object[] obj)
            {
                StudentSubjectModel studentSubject = obj[0] as StudentSubjectModel;
                SubjectModel subject = obj[1] as SubjectModel;
                StudentModel student = obj[2] as StudentModel;

                studentSubject.Subject = subject;
                studentSubject.Student = student;

                return studentSubject;
            };
            string splitOn = "Code,StudentNumber,StudentNumber";

            return await _dapperContext.MapMultipleObjects<StudentSubjectModel, dynamic>(sql, types, map, splitOn, parameters);
        }
    }
}
