namespace FimiAppApi.Contracts
{
    public interface ILabRepository
    {
        Task<List<LabModel>> GetAllLabs();
    }
}