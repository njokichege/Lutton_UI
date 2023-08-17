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
        public async Task<IEnumerable<T>> LoadDataStoredProcedure<T, U>(string procedure, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(procedure, parameters,commandType:CommandType.StoredProcedure);
                return data.ToList();
            }
        }
        public async Task<IEnumerable<T>> MapMultipleObjects<T,U>(string sql, Type[] types, Func<object[], T> map, string splitOn, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql,types,map:map, parameters, splitOn:splitOn);
                return data;
            }
        }
        public async Task<T> LoadSingleData<T,U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                return data;
            }
        }
        public async Task<int> CreateData<T,U>(string sql, DynamicParameters parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.ExecuteAsync(sql, parameters);
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
