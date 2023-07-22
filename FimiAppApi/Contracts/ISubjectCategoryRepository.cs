namespace FimiAppApi.Contracts
{
    public interface ISubjectCategoryRepository
    {
        Task<IEnumerable<SubjectCategoryModel>> GetCategories();
    }
}
