namespace FimiAppUI.Services
{
    public class SubjectCategoryService : ISubjectCategoryService
    {
        private readonly HttpClient _httpClient;

        public SubjectCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SubjectCategoryModel>> GetSubjectCategories()
        {
            return await _httpClient.GetFromJsonAsync<SubjectCategoryModel[]>("api/subjectcategory");
        }
    }
}
