namespace FimiAppUI.Services
{
    public interface IFormService
    {
        Task<IEnumerable<FormModel>> GetForms();
    }
}
