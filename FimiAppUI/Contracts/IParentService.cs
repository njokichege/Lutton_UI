namespace FimiAppUI.Contracts
{
    public interface IParentService
    {
        Task<HttpResponseMessage> AddParent(ParentModel parent);
        Task<ParentModel> GetParentById(int nationalId);
        Task<IEnumerable<ParentModel>> GetParents();
    }
}
