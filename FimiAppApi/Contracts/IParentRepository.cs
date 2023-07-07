namespace FimiAppApi.Contracts
{
    public interface IParentRepository
    {
        Task<ParentModel> GetParentById(int nationalId);
    }
}
