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
        public async Task<IEnumerable<FormModel>> ClassFormMapping(string sql)
        {
            var formDict = new Dictionary<int, FormModel>();
            var streamDict = new Dictionary<int, StreamModel>();
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<FormModel,ClassModel,StreamModel, FormModel>(sql,
                    map: (formOne,classOne,streamOne) =>
                    {
                        if (!formDict.TryGetValue(formOne.FormId, out var currentForm))
                        {
                            currentForm = formOne;
                            formDict.Add(currentForm.FormId, formOne);
                        }
                        currentForm.Classes.Add(classOne);
                        if (!streamDict.TryGetValue(streamOne.StreamId, out var currentStream))
                        {
                            currentStream = streamOne;
                            streamDict.Add(currentStream.StreamId, streamOne);
                        }
                        currentStream.Classes.Add(classOne);
                        return currentForm;
                    },
                    splitOn: "FormId,");
                return data.Distinct().ToList();
            }
        }
        public async Task<IEnumerable<ClassModel>> ClassFormStreamMapping(string sql)
        {
            var classDict = new Dictionary<int, ClassModel>();
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<ClassModel, FormModel, ClassModel>(sql,
                    map: (classOne, formOne) =>
                    {
                        if(!classDict.TryGetValue(classOne.ClassId,out var currentClass))
                        {
                            currentClass = classOne;
                            classDict.Add(currentClass.ClassId, classOne);
                        }
                        currentClass.Forms.Add(formOne);
                        return currentClass;
                    },
                    splitOn: "FormId");
                return data.Distinct().ToList();
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
