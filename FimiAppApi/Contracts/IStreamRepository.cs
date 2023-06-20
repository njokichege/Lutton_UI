namespace FimiAppApi.Contracts
{
    public interface IStreamRepository
    {
        Task<IEnumerable<StreamModel>> GetStreams();
    }
}
