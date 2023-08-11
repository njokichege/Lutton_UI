namespace FimiAppUI.Contracts
{
    public interface IFormService
    {
        Task<FormModel> GetFormById(int formId);
        Task<IEnumerable<FormModel>> GetForms();
    }
}
