namespace FimiAppUI.Contracts
{
    public interface ITermService
    {
        Task<IEnumerable<TermModel>> GetAllTerms();
        Task<TermModel> GetTermIdByName(string termName);
    }
}
