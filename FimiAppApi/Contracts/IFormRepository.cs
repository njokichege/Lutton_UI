namespace FimiAppApi.Contracts
{
    public interface IFormRepository
    {
        Task<FormModel> GetFormById(int formId);
        Task<int> GetFormByName(string formName);
        Task<IEnumerable<FormModel>> GetForms();
    }
}
