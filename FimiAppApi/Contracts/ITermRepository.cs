namespace FimiAppApi.Contracts
{
    public interface ITermRepository
    {
        Task<IEnumerable<TermModel>> GetAllTerms();
    }
}
