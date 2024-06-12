namespace FimiAppUI.Services
{
    public class ExamTypeService : IExamTypeService
    {
        private readonly HttpClient _httpClient;

        public ExamTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ExamTypeModel>> GetAllExamTypes()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ExamTypeModel>>("api/examtype");
        }
        public async Task<ExamTypeModel> GetExamTypeIdByName(string examName)
        {
            return await _httpClient.GetFromJsonAsync<ExamTypeModel>($"api/examtype/{examName}");
        }
    }
}
