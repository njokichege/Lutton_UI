namespace FimiAppApi.Contracts
{
    public interface IStreamRepository
    {
        Task<StreamModel> GetStreamById(int streamId);
        Task<int> GetStreamByName(string streamName);
        Task<IEnumerable<StreamModel>> GetStreams();
    }
}
