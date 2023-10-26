using MySql.Data.MySqlClient;

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

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        public async Task<List<T>> MapMultipleObjects<T,U>(string sql, Type[] types, Func<object[], T> map, string splitOn, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql,types,map:map, parameters, splitOn:splitOn);
                return data.ToList();
            }
        }
        public async Task<T> LoadSingleData<T,U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                return data;
            }
        }
        public async Task<int> UpdateData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var data = await connection.ExecuteAsync(sql, parameters);
                return data;
            }
        }
        public async Task BulkInsert(StringBuilder sql, List<string> rows)
        {
            string connectionString = _config.GetConnectionString(ConnecctionStringName);
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                sql.Append(string.Join(",", rows));
                sql.Append(";");
                connection.Open();
                using (MySqlCommand myCmd = new MySqlCommand(sql.ToString(), connection))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
