using System.Drawing;
using static Slapper.AutoMapper;

namespace FimiAppApi.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DapperContext _dapperContext;

        public TeacherRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<TeacherModel>> GetTeachers()
        {
            string sql = "SELECT* FROM dbo.Teacher";
            return await _dapperContext.LoadData<TeacherModel, dynamic>(sql, new { });
        }
        public async Task<TeacherModel> GetTeacher(int nationalId)
        {
            string sql = "SELECT\r\n    *\r\nFROM Teacher\r\nWHERE\r\n    Teacher.NationalId = @NationalId";
            var parameteres = new DynamicParameters();
            parameteres.Add("NationalId", nationalId, DbType.Int32);
            return await _dapperContext.LoadSingleData<TeacherModel, dynamic>(sql, parameteres);
        }
        public async Task<int> AddTeacher(TeacherModel teacher)
        {
            string sql = "INSERT INTO " +
                            "Teacher " +
                                "(TeacherType,TSCNumber,NationalId) " +
                            "VALUES " +
                                "(@TeacherType,@TSCNumber,@NationalId)";
            var parameters = new DynamicParameters();
            parameters.Add("TeacherType", teacher.TeacherType, DbType.String);
            parameters.Add("TSCNumber", teacher.TSCNumber, DbType.String);
            parameters.Add("NationalId", teacher.Staff.NationalId, DbType.Int32);

            return await _dapperContext.CreateData<TeacherModel, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<TeacherModel>> MapStaffOnTeacher()
        {
            string sql = "SELECT " +
                                "Teacher.TeacherId, " +
                                "Teacher.NationalId, " +
                                "Teacher.TeacherType, " +
                                "Teacher.TSCNumber, " +
                                "Staff.NationalId, " +
                                "Staff.FirstName, " +
                                "Staff.MiddleName, " +
                                "Staff.Surname, " +
                                "Staff.Designation, " +
                                "Staff.EmploymentDate, " +
                                "Staff.Gender, " +
                                "Staff.PhoneNumber " +
                         "FROM Teacher " +
                         "INNER JOIN Staff ON Teacher.NationalId = Staff.NationalId";
            Type[] types =
            {
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], TeacherModel> map = delegate (object[] obj)
            {
                TeacherModel teacherModel = obj[0] as TeacherModel;
                StaffModel staffModel = obj[1] as StaffModel;

                teacherModel.Staff = staffModel;

                return teacherModel;
            };
            string splitOn = "NationalId";

            return await _dapperContext.MapMultipleObjects<TeacherModel,dynamic>(sql, types, map, splitOn, new {});
        }
    }
}
