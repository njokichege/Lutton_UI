namespace FimiAppUI.Contracts
{
    public interface IParentService
    {
        Task<ParentModel> GetParentById(int studentNumber);
    }
}
