namespace FimiAppLibrary.DataAccess
{
    public interface IStreamData
    {
        Task AddStream(StreamModel streamModel);
        Task<List<StreamModel>> GetAllStreams();
    }
}