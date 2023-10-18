namespace FimiAppUI.Contracts
{
    public interface ILabService
    {
        Task<IEnumerable<LabModel>> GetAllLabs();
    }
}