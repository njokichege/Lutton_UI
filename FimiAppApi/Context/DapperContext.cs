using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace FimiAppApi.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        public DapperContext(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("AZURE_MYSQL_CONNECTIONSTRING"));
            }
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = Connection)
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        public async Task<List<T>> MapMultipleObjects<T,U>(string sql, Type[] types, Func<object[], T> map, string splitOn, U parameters)
        {
            using (IDbConnection connection = Connection)
            {
                var data = await connection.QueryAsync<T>(sql,types,map:map, parameters, splitOn:splitOn);
                return data.ToList();
            }
        }
        public async Task<T> LoadSingleData<T,U>(string sql, U parameters)
        {
            using (IDbConnection connection = Connection)
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                return data;
            }
        }
        public async Task<int> UpdateData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = Connection)
            {
                var data = await connection.ExecuteAsync(sql, parameters);
                return data;
            }
        }
    }
}
