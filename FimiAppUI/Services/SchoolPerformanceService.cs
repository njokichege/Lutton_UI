namespace FimiAppUI.Services
{
    public class SchoolPerformanceService : ISchoolPerformanceService
    {
        private readonly HttpClient _httpClient;

        public SchoolPerformanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SchoolPerformanceModel>> GetSchoolPerformances(int sessionYearId, int termId, int examTypeId)
        {
            return await _httpClient.GetFromJsonAsync<SchoolPerformanceModel[]>($"api/schoolperformance/{sessionYearId}/{termId}/{examTypeId}");
        }
    }
}
