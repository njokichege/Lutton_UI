
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
        public async Task<int> CreateClass(int formId, int streamId, int sessionYearId)
        {
            string sql = "INSERT INTO Class" +
                "(FormId,StreamId,SessionYearId)" +
                "VALUES" +
                "(@FormId,@StreamId,@SessionYearId)" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)"; 
            var parameters = new DynamicParameters();
            parameters.Add("FormId", formId, DbType.Int32);
            parameters.Add("StreamId", streamId, DbType.Int32);
            parameters.Add("SessionYearId", sessionYearId, DbType.Int32);

            var id = await _context.CreateData<ClassModel,dynamic>(sql, parameters);
            return id;
        }
        public async Task DeleteClass(int id)
        {
            string sql = "DELETE FROM dbo.Class WHERE ClassId=@Id";
            
            await _context.UpdateData<ClassModel, dynamic>(sql, new {id});
        }
        public async Task<ClassModel> GetClassByForeignKeys(int formId, int streamId, int sessionYearId)
        {
            string sql = "SELECT " +
                               "* " +
                         "FROM Class " +
                         "WHERE FormId = @FormId " +
                         "AND StreamId = @StreamId " +
                         "AND SessionYearId = @SessionYearId";
            var parameters = new DynamicParameters();
            parameters.Add("FormId", formId, DbType.Int32);
            parameters.Add("StreamId", streamId, DbType.Int32);
            parameters.Add("SessionYearId",sessionYearId, DbType.Int32);

            return await _context.LoadSingleData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task<ClassModel> GetClassMultipleMappingById(int id)
        {
            string sql = "SELECT " +
                                "Class.ClassId, " +
                                "Class.FormId," +
                                "Class.StreamId," +
                                "Class.TeacherId," +
                                "Form.FormId," +
                                "Form.Form," +
                                "Stream.StreamId," +
                                "Stream.Stream," +
                                "Teacher.TeacherId," +
                                "Teacher.TSCNumber, "+
                                "Staff.NationalId," +
                                "Staff.FirstName," +
                                "Staff.MiddleName," +
                                "Staff.Surname, " +
                                "Staff.Designation "+
                         "FROM Class " +
                         "INNER JOIN Form ON Class.FormId = Form.FormId " +
                         "INNER JOIN Stream ON Class.StreamId = Stream.StreamId " +
                         "INNER JOIN Teacher ON Class.TeacherId = Teacher.TeacherId  " +
                         "INNER JOIN Staff ON Teacher.NationalId = Staff.NationalId " +
                         "WHERE Class.ClassId = @ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("@ClassId", id, DbType.Int32);

            Type[] types =
            {
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel),
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], ClassModel> map = delegate (object[] obj)
            {
                ClassModel classDetails = obj[0] as ClassModel;
                FormModel formModel = obj[1] as FormModel;
                StreamModel streamModel = obj[2] as StreamModel;
                TeacherModel teacherModel = obj[3] as TeacherModel;
                StaffModel staffModel = obj[4] as StaffModel;

                classDetails.Form = formModel;
                classDetails.Stream = streamModel;
                classDetails.Teacher = teacherModel;
                teacherModel.Staff = staffModel;

                return classDetails;
            };
            string splitOn = "FormId,StreamId,TeacherId,NationalId";
            var data = await _context.MapMultipleObjectsById<ClassModel>(sql, types, map, splitOn, parameters);
            return data.FirstOrDefault();
        }
        public async Task<IEnumerable<ClassModel>> GetClasses()
        {
            string sql = "SELECT* FROM dbo.Class";
            return await _context.LoadData<ClassModel, dynamic>(sql, new { });
        }
        public async Task UpdateClassGrade(int classId, int gradeId)
        {
            string sql = "UPDATE dbo.Class SET GradeId=@GradeId WHERE ClassId=@ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId, DbType.Int32);
            parameters.Add("GradeId", gradeId, DbType.Int32);

            await _context.UpdateData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task UpdateClassTeacher(int classId, int teacherId)
        {
            string sql = "UPDATE dbo.Class SET TeacherId=@TeacherId WHERE ClassId=@ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("TeacherId", teacherId, DbType.Int32);
            parameters.Add("ClassId", classId, DbType.Int32);

            await _context.UpdateData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<ClassModel>> GetClassMultipleMapping()
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
            Type[] types =
            {
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel),
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], ClassModel> map = delegate (object[] obj)
            {
                ClassModel classDetails = obj[0] as ClassModel;
                FormModel formModel = obj[1] as FormModel;
                StreamModel streamModel = obj[2] as StreamModel;
                TeacherModel teacherModel = obj[3] as TeacherModel;
                StaffModel staffModel = obj[4] as StaffModel;

                classDetails.Form = formModel;
                classDetails.Stream = streamModel;
                classDetails.Teacher = teacherModel;
                teacherModel.Staff = staffModel;

                return classDetails;
            };
            string splitOn = "FormId,StreamId,TeacherId,NationalId";
            return await _context.MapMultipleObjects(query, types, map, splitOn);   
        }
    }
}
