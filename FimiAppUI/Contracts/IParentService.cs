namespace FimiAppUI.Contracts
{
    public interface IParentService
    {
        Task<HttpResponseMessage> AddParent(ParentModel parent);
        Task<ParentModel> GetParentById(int studentNumber);
        Task<IEnumerable<ParentModel>> GetParents();
    }
}
