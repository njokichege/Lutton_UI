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
        public async Task<IEnumerable<TeacherModel>> GetMapStaffOnTeacher()
        {
            string sql = "SELECT " +
                                "Teacher.TeacherId, " +
                                "Staff.NationalId, " +
                                "Staff.FirstName, " +
                                "Staff.MiddleName, " +
                                "Staff.Surname " +
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
