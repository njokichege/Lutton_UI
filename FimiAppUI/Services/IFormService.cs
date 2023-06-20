namespace FimiAppUI.Services
{
    public interface IFormService
    {
        Task<IEnumerable<FormModel>> GetForms();
        Task<IEnumerable<FormModel>> GetClassFormMapping();
    }
}
