namespace FimiAppApi.Contracts
{
    public interface IFormRepository
    {
        Task<FormModel> GetFormById(int formId);
        Task<IEnumerable<FormModel>> GetForms();
    }
}
