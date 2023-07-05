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

            return await _dapperContext.MapMultipleObjectsById(sql,types, map, splitOn, parameters);
        }
    }
}
