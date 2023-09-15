
using FimiAppApi.Context;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Xml;

namespace FimiAppApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DapperContext _context;
        public ClassRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<ClassModel> CreateClass(ClassModel classModel)
        {
            string sql = "INSERT INTO Class" +
                "(FormId,StreamId,SessionYearId,TeacherId)" +
                "VALUES" +
                "(@FormId,@StreamId,@SessionYearId,@TeacherId); SELECT LAST_INSERT_ID();"; 
            var parameters = new DynamicParameters();
            parameters.Add("FormId", classModel.FormId, DbType.Int32);
            parameters.Add("StreamId", classModel.StreamId, DbType.Int32);
            parameters.Add("SessionYearId", classModel.SessionYearId, DbType.Int32);
            parameters.Add("TeacherId", classModel.TeacherId, DbType.Int32);

            int id = await _context.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new ClassModel
            {
                ClassId = id,
                Form = classModel.Form,
                Stream = classModel.Stream,
                SessionYear = classModel.SessionYear,
                Teacher = classModel.Teacher
            };
            return createdModel;
        }
        public async Task DeleteClass(int id)
        {
            string sql = "DELETE FROM Class WHERE ClassId=@Id";
            
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

            return await _context.LoadSingleData<ClassModel,dynamic>(sql, parameters);
        }
        public async Task<ClassModel> GetClassMultipleMappingById(int id)
        {
            string sql = "SELECT " +
                            "Class.ClassId," +
                            "Class.FormId," +
                            "Class.StreamId," +
                            "Class.TeacherId," +
                            "Class.SessionYearId," +
                            "Form.FormId," +
                            "Form.Form," +
                            "Stream.StreamId," +
                            "Stream.Stream," +
                            "SessionYear.SessionYearId," +
                            "SessionYear.StartDate," +
                            "SessionYear.EndDate," +
                            "Teacher.TeacherId," +
                            "Teacher.NationalId," +
                            "Teacher.TeacherType," +
                            "Teacher.TSCNumber," +
                            "Staff.FirstName," +
                            "Staff.MiddleName," +
                            "Staff.Surname," +
                            "Staff.DateOfBirth," +
                            "Staff.Designation," +
                            "Staff.EmploymentDate," +
                            "Staff.Gender," +
                            "Staff.NationalId," +
                            "Staff.PhoneNumber " +
                        "FROM Class " +
                        "INNER JOIN Form ON Class.FormId = Form.FormId " +
                        "INNER JOIN Stream ON Class.StreamId = Stream.StreamId " +
                        "INNER JOIN SessionYear ON SessionYear.SessionYearId = Class.SessionYearId " +
                        "LEFT JOIN Teacher ON Class.TeacherId = Teacher.TeacherId " +
                        "LEFT JOIN Staff ON Teacher.NationalId = Staff.NationalId " +
                        "WHERE Class.ClassId = @ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("@ClassId", id, DbType.Int32);

            Type[] types =
            {
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel),
                 typeof(SessionYearModel),
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], ClassModel> map = delegate (object[] obj)
            {
                ClassModel classDetails = obj[0] as ClassModel;
                FormModel formModel = obj[1] as FormModel;
                StreamModel streamModel = obj[2] as StreamModel;
                SessionYearModel sessionYear = obj[3] as SessionYearModel;
                TeacherModel teacherModel = obj[4] as TeacherModel;
                StaffModel staffModel = obj[5] as StaffModel;

                classDetails.Form = formModel;
                classDetails.Stream = streamModel;
                classDetails.SessionYear = sessionYear;
                classDetails.Teacher = teacherModel;
                teacherModel.Staff = staffModel;

                return classDetails;
            };
            string splitOn = "FormId,StreamId,SessionYearId,TeacherId,NationalId";
            var data = await _context.MapMultipleObjects<ClassModel,dynamic>(sql, types, map, splitOn, parameters);
            return data.FirstOrDefault();
        }
        public async Task<IEnumerable<ClassModel>> GetClasses()
        {
            string sql = "SELECT* FROM Class";
            return await _context.LoadData<ClassModel, dynamic>(sql, new { });
        }
        public async Task UpdateClassGrade(int classId, int gradeId)
        {
            string sql = "UPDATE Class SET GradeId=@GradeId WHERE ClassId=@ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId, DbType.Int32);
            parameters.Add("GradeId", gradeId, DbType.Int32);

            await _context.UpdateData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task UpdateClassTeacher(int classId, int teacherId)
        {
            string sql = "UPDATE Class SET TeacherId=@TeacherId WHERE ClassId=@ClassId";
            var parameters = new DynamicParameters();
            parameters.Add("TeacherId", teacherId, DbType.Int32);
            parameters.Add("ClassId", classId, DbType.Int32);

            await _context.UpdateData<ClassModel, dynamic>(sql, parameters);
        }
        public async Task<IEnumerable<ClassModel>> GetClassMultipleMapping()
        {
            string query = "SELECT " +
                                "Class.ClassId," +
                                "Class.FormId," +
                                "Class.StreamId," +
                                "Class.TeacherId," +
                                "Class.SessionYearId," +
                                "Form.FormId," +
                                "Form.Form," +
                                "Stream.StreamId," +
                                "Stream.Stream," +
                                "SessionYear.SessionYearId," +
                                "SessionYear.StartDate," +
                                "SessionYear.EndDate," +
                                "Teacher.TeacherId," +
                                "Staff.NationalId," +
                                "Form.Form," +
                                "Stream.Stream," +
                                "Staff.FirstName," +
                                "Staff.MiddleName," +
                                "Staff.Surname " +
                           "FROM Class " +
                           "INNER JOIN Form ON Class.FormId = Form.FormId " +
                           "INNER JOIN Stream ON Class.StreamId = Stream.StreamId " +
                           "INNER JOIN SessionYear ON SessionYear.SessionYearId = Class.SessionYearId " +
                           "LEFT JOIN Teacher ON Class.TeacherId = Teacher.TeacherId " +
                           "LEFT JOIN Staff ON Teacher.NationalId = Staff.NationalId";
            Type[] types =
            {
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel),
                 typeof(SessionYearModel),
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], ClassModel> map = delegate (object[] obj)
            {
                ClassModel classDetails = obj[0] as ClassModel;
                FormModel formModel = obj[1] as FormModel;
                StreamModel streamModel = obj[2] as StreamModel;
                SessionYearModel sessionYear = obj[3] as SessionYearModel;
                TeacherModel teacherModel = obj[4] as TeacherModel;
                StaffModel staffModel = obj[5] as StaffModel;
                

                classDetails.Form = formModel;
                classDetails.Stream = streamModel;
                classDetails.SessionYear = sessionYear;
                classDetails.Teacher = teacherModel;
                teacherModel.Staff = staffModel;

                return classDetails;
            };
            string splitOn = "FormId,StreamId,SessionYearId,TeacherId,NationalId";
            return await _context.MapMultipleObjects<ClassModel,dynamic>(query, types, map, splitOn, new {});   
        }
    }
}
