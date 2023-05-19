namespace FimiAppLibrary.DataAccess
{
    public interface IFormData
    {
        Task AddForm(FormModel form);
        Task<List<FormModel>> GetAllForms();
    }
}