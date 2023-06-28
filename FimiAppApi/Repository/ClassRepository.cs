
using FimiAppApi.Context;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Security.Claims;

namespace FimiAppApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DapperContext _context;
        public ClassRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateClass(ClassModel classDetails)
        {
            string sql = "INSERT INTO Class" +
                "(FormId,StreamId,SessionYearId)" +
                "VALUES" +
                "(@FormId,@StreamId,@SessionYearId)" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)"; 
            var parameters = new DynamicParameters();
            parameters.Add("FormId", classDetails.FormId, DbType.Int32);
            parameters.Add("StreamId", classDetails.StreamId, DbType.Int32);
            parameters.Add("SessionYearId", classDetails.SessionYearId, DbType.Int32);

            var id = await _context.CreateData<ClassModel,dynamic>(sql, parameters);
            return id;
        }
        public async Task DeleteClass(int id)
        {
            string sql = "DELETE FROM dbo.Class WHERE ClassId=@Id";
            
            await _context.UpdateData<ClassModel, dynamic>(sql, new {id});
        }
        public async Task<ClassModel> GetClassByForeignKeys(ClassModel classDetails)
        {
            string sql = "SELECT " +
                               "* " +
                         "FROM Class " +
                         "WHERE FormId = @FormId " +
                         "AND StreamId = @StreamId " +
                         "AND SessionYearId = @SessionYearId";
            var parameters = new DynamicParameters();
            parameters.Add("FormId", classDetails.FormId, DbType.Int32);
            parameters.Add("StreamId", classDetails.StreamId, DbType.Int32);
            parameters.Add("SessionYearId", classDetails.SessionYearId, DbType.Int32);

            return await _context.LoadSingleData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task<ClassModel> GetClassById(int id)
        {
            string sql = "SELECT * FROM dbo.Class WHERE ClassId = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            return await _context.LoadSingleData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<ClassModel>> GetClasses()
        {
            string sql = "SELECT* FROM dbo.Class";
            return await _context.LoadData<ClassModel, dynamic>(sql, new { });
        }
        public async Task UpdateClassGrade(int id, ClassModel classModel)
        {
            string sql = "UPDATE dbo.Class SET GradeId=@GradeId WHERE ClassId=@ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", id, DbType.Int32);
            //parameters.Add("GradeId", classModel.GradeId, DbType.Int32);

            await _context.UpdateData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task UpdateClassTeacher(int id, ClassModel classModel)
        {
            string sql = "UPDATE dbo.Class SET TeacherId=@TeacherId WHERE ClassId=@ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("TeacherId", classModel.TeacherId, DbType.Int32);
            parameters.Add("ClassId", id, DbType.Int32);

            await _context.UpdateData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<ClassModel>> GetMultipleMapping()
        {
            string query = "SELECT  " +
                                "Class.ClassId," +
                                "Class.FormId," +
                                "Class.StreamId," +
                                "Class.TeacherId," +
                                "Form.FormId," +
                                "Form.Form," +
                                "Stream.StreamId," +
                                "Stream.Stream," +
                                "Teacher.TeacherId," +
                                "Staff.NationalId," +
                                "Staff.FirstName," +
                                "Staff.MiddleName," +
                                "Staff.Surname " +
                          "FROM Class " +
                          "INNER JOIN Form ON Class.FormId = Form.FormId " +
                          "INNER JOIN Stream ON Class.StreamId = Stream.StreamId " +
                          "INNER JOIN Teacher ON Class.TeacherId = Teacher.TeacherId " +
                          "INNER JOIN Staff ON Teacher.NationalId = Staff.NationalId";
            return await _context.MapMultipleObjects(query);   
        }
    }
}
