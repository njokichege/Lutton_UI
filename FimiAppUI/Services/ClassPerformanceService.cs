namespace FimiAppUI.Services
{
    public class ClassPerformanceService : IClassPerformanceService
    {
        private readonly HttpClient _httpClient;

        public ClassPerformanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ClassPerformanceModel> GetStudentResults(int studentNumber, int sessionYearId, int termId, int examTypeId)
        {
            return await _httpClient.GetFromJsonAsync<ClassPerformanceModel>($"api/classsubjectperformance/studentresult/{studentNumber}/{sessionYearId}/{termId}/{examTypeId}");
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClassPerformanceModel>>($"api/classsubjectperformance/{classId}/{sessionYearId}/{termId}/{examTypeId}");
        }
        public async Task<HttpResponseMessage> UpdateStudentResults(ClassPerformanceModel classPerformanceModel)
        {
            return await _httpClient.PutAsJsonAsync<ClassPerformanceModel>("api/classsubjectperformance/StudentResults", classPerformanceModel);
        }
    }
}
