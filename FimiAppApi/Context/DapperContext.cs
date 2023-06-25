using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace FimiAppApi.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        public string ConnecctionStringName { get; set; } = "Default";
        public DapperContext(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        public async Task<IEnumerable<ClassModel>> MapMultipleObjects(string sql)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<ClassModel>(sql,
                    new[]
                    {
                        typeof(ClassModel),
                        typeof(FormModel),
                        typeof(StreamModel),
                        typeof(TeacherModel),
                        typeof(StaffModel)
                    },
                    obj =>
                    {
                        ClassModel classModel = obj[0] as ClassModel;
                        FormModel formModel = obj[1] as FormModel;
                        StreamModel streamModel = obj[2] as StreamModel;
                        TeacherModel teacherModel = obj[3] as TeacherModel;
                        StaffModel staffModel = obj[4] as StaffModel;

                        classModel.Form = formModel;
                        classModel.Stream = streamModel;
                        classModel.Teacher = teacherModel;
                        teacherModel.Staff = staffModel;

                        return classModel;
                    },
                    splitOn: "FormId,StreamId,TeacherId,NationalId");
                return data.ToList();
            }
        }
        public async Task<IEnumerable<TeacherModel>> MapStaffOnTeacher(string sql)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<TeacherModel,StaffModel,TeacherModel>(sql,
                    (teacherModel,staffModel) =>
                    {
                        teacherModel.Staff = staffModel;
                        return teacherModel;
                    },
                    splitOn: "NationalId");
                return data.ToList();
            }
        }
        public async Task<T> LoadSingleData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                return data;
            }
        }
        public async Task<int> AddData<T,U>(string sql, DynamicParameters parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QuerySingleAsync<int>(sql, parameters);
                return data;
            }
        }
        public async Task UpdateData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
