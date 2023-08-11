namespace FimiAppApi.Contracts
{
    public interface IStreamRepository
    {
        Task<StreamModel> GetStreamById(int streamId);
        Task<IEnumerable<StreamModel>> GetStreams();
    }
}
