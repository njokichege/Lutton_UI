using System.Xml;
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
        public async Task<StudentModel> CreateStudent(StudentModel student)
        {
            string sql = "INSERT INTO Student " +
                            "(FirstName,MiddleName,Surname,Gender,DateOfBirth,AdmissionDate) " +
                         "VALUES " +
                            "(@FirstName,@MiddleName,@Surname,@Gender,@DateOfBirth,sysdate()); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", student.FirstName, DbType.String);
            parameters.Add("MiddleName", student.MiddleName, DbType.String);
            parameters.Add("Surname", student.Surname, DbType.String);
            parameters.Add("Gender", student.Gender, DbType.String);
            parameters.Add("DateOfBirth", student.DateOfBirth, DbType.Date);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new StudentModel
            {
                StudentNumber = id,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                Surname = student.Surname,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth
            };
            return createdModel;
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
