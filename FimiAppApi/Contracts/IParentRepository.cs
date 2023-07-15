namespace FimiAppApi.Contracts
{
    public interface IParentRepository
    {
        Task<int> CreateParent(ParentModel parent);
        Task<ParentModel> GetParentById(int nationalId);
        Task<IEnumerable<ParentModel>> GetParents();
    }
}
