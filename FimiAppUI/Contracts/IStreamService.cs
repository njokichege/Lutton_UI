namespace FimiAppUI.Contracts
{
    public interface IStreamService
    {
        Task<StreamModel> GetStreamById(int streamId);
        Task<int> GetStreamByName(string streamName);
        Task<IEnumerable<StreamModel>> GetStreams();
    }
}
