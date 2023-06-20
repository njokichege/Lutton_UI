namespace FimiAppUI.Services
{
    public interface IStreamService
    {
        Task<IEnumerable<StreamModel>> GetStreams();
    }
}
