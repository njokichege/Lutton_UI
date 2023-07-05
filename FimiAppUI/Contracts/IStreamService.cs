namespace FimiAppUI.Contracts
{
    public interface IStreamService
    {
        Task<IEnumerable<StreamModel>> GetStreams();
    }
}
