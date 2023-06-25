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
            string sql = "SELECT\r\n    Teacher.TeacherId,\r\n    Staff.NationalId,\r\n    Staff.FirstName,\r\n    Staff.MiddleName,\r\n    Staff.Surname\r\nFROM Teacher\r\nINNER JOIN Staff ON Teacher.NationalId = Staff.NationalId";
            return await _dapperContext.MapStaffOnTeacher(sql);
        }
    }
}
