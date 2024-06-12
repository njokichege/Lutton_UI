namespace FimiAppUI.Services
{
    public class ExamService : IExamService
    {
        private readonly HttpClient _httpClient;

        public ExamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddExam(ExamModel examModel)
        {
            return await _httpClient.PostAsJsonAsync<ExamModel>("api/exam", examModel);
        }
        public async Task<IEnumerable<ExamModel>> GetExamsBySchoolYear(int schoolYear)
        {
            return await _httpClient.GetFromJsonAsync<ExamModel[]>($"api/exam/allExams/{schoolYear}");
        }
        public async Task<ExamModel> GetExamByTermAndExamType(int termId, int examTypeId, int schoolYear)
        {
            return await _httpClient.GetFromJsonAsync<ExamModel>($"api/exam/{termId}/{examTypeId}/{schoolYear}");
        }
    }
}
