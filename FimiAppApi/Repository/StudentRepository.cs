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
                            "(FirstName,MiddleName,Surname,Gender,DateOfBirth,AdmissionDate,PhoneNumber,KCPEResult) " +
                         "VALUES " +
                            "(@FirstName,@MiddleName,@Surname,@Gender,@DateOfBirth,sysdate(),@PhoneNumber,@KCPEResult); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", student.FirstName);
            parameters.Add("MiddleName", student.MiddleName);
            parameters.Add("Surname", student.Surname);
            parameters.Add("Gender", student.Gender);
            parameters.Add("DateOfBirth", student.DateOfBirth);
            parameters.Add("PhoneNumber", student.PhoneNumber);
            parameters.Add("KCPEResult", student.KCPEResult);

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
        public async Task<StudentModel> AddExistingStudent(StudentModel student)
        {
            string sql = "INSERT INTO Student " +
                            "(StudentNumber,FirstName,MiddleName,Surname,Gender,DateOfBirth,AdmissionDate,PhoneNumber,KCPEResult) " +
                         "VALUES " +
                            "(@StudentNumber,@FirstName,@MiddleName,@Surname,@Gender,@DateOfBirth,sysdate(),@PhoneNumber,@KCPEResult); " +
                            "SELECT StudentNumber from Student WHERE StudentNumber=StudentNumber;";
            var parameters = new DynamicParameters();
            parameters.Add("StudentNumber", student.StudentNumber);
            parameters.Add("FirstName", student.FirstName);
            parameters.Add("MiddleName", student.MiddleName);
            parameters.Add("Surname", student.Surname);
            parameters.Add("Gender", student.Gender);
            parameters.Add("DateOfBirth", student.DateOfBirth);
            parameters.Add("PhoneNumber", student.PhoneNumber);
            parameters.Add("KCPEResult", student.KCPEResult);

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
            return await _dapperContext.LoadSingleData<StudentModel, dynamic>(sql, parameteres);
        }
        public async Task<IEnumerable<StudentModel>> GetAllStudentsBySessionYear(int sesionYearId)
        {
            string sql = "SELECT " +
                            "Student.*, " +
                            "Class.*, " +
                            "Form.*, " +
                            "Stream.* " +
                         "FROM Student " +
                         "INNER JOIN StudentClass ON StudentClass.StudentNumber = Student.StudentNumber " +
                         "INNER JOIN Class ON StudentClass.ClassId = Class.ClassId " +
                         "INNER JOIN Form ON Class.FormId = Form.FormId " +
                         "INNER JOIN Stream ON Class.StreamId = Stream.StreamId " +
                         "WHERE Class.SessionYearId = @SessionYearId";
            var parameters = new DynamicParameters();
            parameters.Add("SessionYearId", sesionYearId);

            Type[] types =
            {
                 typeof(StudentModel),
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel)
            };
            Func<object[], StudentModel> map = delegate (object[] obj)
            {
                StudentModel studentModel = obj[0] as StudentModel;
                ClassModel classDetails = obj[1] as ClassModel;
                FormModel formModel = obj[2] as FormModel;
                StreamModel streamModel = obj[3] as StreamModel;

                studentModel.StudentClass = classDetails;
                classDetails.Form = formModel;
                classDetails.Stream = streamModel;

                return studentModel;
            };
            string splitOn = "StudentNumber,ClassId,FormId,StreamId";

            return await _dapperContext.MapMultipleObjects<StudentModel, dynamic>(sql, types, map, splitOn, parameters);
        }
        public async Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId)
        {
            string sql = "SELECT " +
                            "Student.*, " +
                            "Class.*, " +
                            "Form.*, " +
                            "Stream.* " +
                         "FROM Student " +
                         "INNER JOIN StudentClass ON StudentClass.StudentNumber = Student.StudentNumber " +
                         "INNER JOIN Class ON StudentClass.ClassId = Class.ClassId " +
                         "INNER JOIN Form ON Class.FormId = Form.FormId " +
                         "INNER JOIN Stream ON Class.StreamId = Stream.StreamId " +
                         "WHERE Class.ClassId = @ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId);

            Type[] types =
            {
                 typeof(StudentModel),
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel)
            };
            Func<object[], StudentModel> map = delegate (object[] obj)
            {
                StudentModel studentModel = obj[0] as StudentModel;
                ClassModel classDetails = obj[1] as ClassModel;
                FormModel formModel = obj[2] as FormModel;
                StreamModel streamModel = obj[3] as StreamModel;

                studentModel.StudentClass = classDetails;
                classDetails.Form = formModel;
                classDetails.Stream = streamModel;

                return studentModel;
            };
            string splitOn = "StudentNumber,ClassId,FormId,StreamId";

            return await _dapperContext.MapMultipleObjects<StudentModel,dynamic>(sql,types, map, splitOn, parameters);
        }
    }
}
