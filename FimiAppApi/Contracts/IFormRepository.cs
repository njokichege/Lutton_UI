namespace FimiAppApi.Contracts
{
    public interface IFormRepository
    {
        Task<IEnumerable<FormModel>> GetForms();
        Task<IEnumerable<FormModel>> ClassFormMapping();
    }
}
