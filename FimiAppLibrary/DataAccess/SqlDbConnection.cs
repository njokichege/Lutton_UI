using Dapper;
using Microsoft.Extensions.Configuration;
//using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FimiAppLibrary.DataAccess;

public class SqlDbConnection : ISqlDbConnection
{
    private readonly IConfiguration _config;
    public string ConnecctionStringName { get; set; } = "Default";
    public SqlDbConnection(IConfiguration config)
    {
        _config = config;
    }
    public async Task<List<T>> LoadData<T,U>(string sql,U parameters)
    {
        string connectionString = _config.GetConnectionString(ConnecctionStringName);
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync<T>(sql, parameters);
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
    public async Task SaveData<T>(string sql,T parameters)
    {
        string connectionString = _config.GetConnectionString(ConnecctionStringName);
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}


