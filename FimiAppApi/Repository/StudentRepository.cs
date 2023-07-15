using static Slapper.AutoMapper;

namespace FimiAppApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _dapperContext;

        public StudentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            string sql = "SELECT * FROM Student";
            return await _dapperContext.LoadData<StudentModel, dynamic>(sql, new {});
        }
        public async Task<int> CreateStudent(StudentModel student)
        {
            string sql = "DECLARE @stnum INT; " +
                         "SELECT @stnum = MAX(StudentNumber) FROM Student " +
                         "INSERT INTO Student " +
                            "(StudentNumber,FirstName,MiddleName,Surname,Gender,DateOfBirth,AdmissionDate) " +
                         "VALUES " +
                            "((@stnum + 1),@FirstName,@MiddleName,@Surname,@Gender,@DateOfBirth,GETDATE())";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", student.FirstName, DbType.String);
            parameters.Add("MiddleName", student.MiddleName, DbType.String);
            parameters.Add("Surname", student.Surname, DbType.String);
            parameters.Add("Gender", student.Gender, DbType.String);
            parameters.Add("DateOfBirth", student.DateOfBirth, DbType.Date);
            
            return await _dapperContext.CreateData<StudentModel, dynamic>(sql, parameters);
        }
        public async Task<StudentModel> GetStudent(int studentNumber)
        {
            string sql = "SELECT " +
                                "* " +
                         "FROM Student WHERE Student.StudentNumber = @StudentNumber";
            var parameteres = new DynamicParameters();
            parameteres.Add("StudentNumber", studentNumber);
            return await _dapperContext.LoadSingleData<StudentModel,dynamic>(sql,parameteres);
        }
        public async Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId)
        {
            string sql = "SELECT " +
                            "Student.*, " +
                            "Class.* " +
                         "FROM Student " +
                         "INNER JOIN StudentClass ON StudentClass.StudentNumber = Student.StudentNumber " +
                         "INNER JOIN Class ON StudentClass.ClassId = Class.ClassId " +
                         "WHERE Class.ClassId = @ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId);

            Type[] types =
            {
                 typeof(StudentModel),
                 typeof(ClassModel)
            };
            Func<object[], StudentModel> map = delegate (object[] obj)
            {
                StudentModel studentModel = obj[0] as StudentModel;
                ClassModel classDetails = obj[1] as ClassModel;

                studentModel.StudentClasses.Add(classDetails);

                return studentModel;
            };
            string splitOn = "StudentNumber,ClassId";

            return await _dapperContext.MapMultipleObjects<StudentModel,dynamic>(sql,types, map, splitOn, parameters);
        }
    }
}
