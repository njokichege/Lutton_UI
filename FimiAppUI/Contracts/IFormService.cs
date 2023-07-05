namespace FimiAppUI.Contracts
{
    public interface IFormService
    {
        Task<IEnumerable<FormModel>> GetForms();
    }
}
