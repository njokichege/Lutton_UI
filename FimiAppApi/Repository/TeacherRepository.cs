using System.Drawing;
using System.Xml;
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
            string sql = "SELECT* FROM Teacher";
            var data = await _dapperContext.LoadData<TeacherModel, dynamic>(sql, new { });

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
        public async Task<TeacherModel> GetTeacherById(int nationalId)
        {
            string sql = "SELECT\r\n    *\r\nFROM Teacher\r\nWHERE\r\n    Teacher.NationalId = @NationalId";
            var parameteres = new DynamicParameters();
            parameteres.Add("NationalId", nationalId, DbType.Int32);
            return await _dapperContext.LoadSingleData<TeacherModel, dynamic>(sql, parameteres);
        }
        public async Task<TeacherModel> AddTeacher(TeacherModel teacher)
        {
            string sql = "INSERT INTO " +
                            "Teacher " +
                                "(TeacherType,TSCNumber,NationalId) " +
                            "VALUES " +
                                "(@TeacherType,@TSCNumber,@NationalId); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("TeacherType", teacher.TeacherType, DbType.String);
            parameters.Add("TSCNumber", teacher.TSCNumber, DbType.String);
            parameters.Add("NationalId", teacher.Staff.NationalId, DbType.Int32);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new TeacherModel
            {
                TeacherId = id,
                TeacherType = teacher.TeacherType,
                TSCNumber = teacher.TSCNumber,
                NationalId = teacher.NationalId,
            };
            return createdModel;
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

            var data = await _dapperContext.MapMultipleObjects<TeacherModel,dynamic>(sql, types, map, splitOn, new {});

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
        public async Task<IEnumerable<TeacherModel>> MapStaffOnTeacherById(int teacherId)
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
                         "INNER JOIN Staff ON Teacher.NationalId = Staff.NationalId " +
                         "WHERE Teacher.TeacherId = @TeacherId";
            var parameters = new DynamicParameters();
            parameters.Add("TeacherId", teacherId, DbType.Int32);
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

            var data = await _dapperContext.MapMultipleObjects<TeacherModel, dynamic>(sql, types, map, splitOn, parameters);

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
    }
}
