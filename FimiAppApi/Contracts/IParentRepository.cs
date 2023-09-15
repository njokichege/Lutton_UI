namespace FimiAppApi.Contracts
{
    public interface IParentRepository
    {
        Task<ParentModel> CreateParent(ParentModel parent);
        Task<ParentModel> GetParentById(int nationalId);
        Task<IEnumerable<ParentModel>> GetParents();
    }
}
