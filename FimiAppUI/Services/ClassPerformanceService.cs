namespace FimiAppUI.Services
{
    public class ClassPerformanceService : IClassPerformanceService
    {
        private readonly HttpClient _httpClient;

        public ClassPerformanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClassPerformanceModel>>($"api/classsubjectperformance/{classId}/{sessionYearId}/{termId}/{examTypeId}");
        }
    }
}
