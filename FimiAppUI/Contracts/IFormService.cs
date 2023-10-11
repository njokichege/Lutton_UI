namespace FimiAppUI.Contracts
{
    public interface IFormService
    {
        Task<FormModel> GetFormById(int formId);
        Task<int> GetFormByName(string formName);
        Task<IEnumerable<FormModel>> GetForms();
    }
}
