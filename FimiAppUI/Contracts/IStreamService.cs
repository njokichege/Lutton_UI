namespace FimiAppUI.Contracts
{
    public interface IStreamService
    {
        Task<StreamModel> GetStreamById(int streamId);
        Task<IEnumerable<StreamModel>> GetStreams();
    }
}
