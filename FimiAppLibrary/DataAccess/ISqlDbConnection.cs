namespace FimiAppLibrary.DataAccess
{
    public interface ISqlDbConnection
    {
        string ConnecctionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<T> LoadSingleData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}