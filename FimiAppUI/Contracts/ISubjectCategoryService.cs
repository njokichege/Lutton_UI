namespace FimiAppUI.Contracts
{
    public interface ISubjectCategoryService
    {
        Task<IEnumerable<SubjectCategoryModel>> GetSubjectCategories();
    }
}
