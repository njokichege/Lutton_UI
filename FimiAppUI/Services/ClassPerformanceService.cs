using System.Collections.Generic;

namespace FimiAppUI.Services
{
    public class ClassPerformanceService : IClassPerformanceService
    {
        private readonly HttpClient _httpClient;

        public ClassPerformanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetClassPerformancePerTerm(int sessionId, int termId, int classId, int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClassPerformanceModel>>($"api/classperformance/classresult/{sessionId}/{termId}/{classId}/{studentNumber}");
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResults(int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync <IEnumerable<ClassPerformanceModel>> ($"api/classperformance/studentresult/{studentNumber}");
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClassPerformanceModel>>($"api/classperformance/{classId}/{sessionYearId}/{termId}/{examTypeId}");
        }
        public async Task<HttpResponseMessage> UpdateStudentResults(ClassPerformanceModel classPerformanceModel)
        {
            return await _httpClient.PutAsJsonAsync<ClassPerformanceModel>("api/classperformance/StudentResults", classPerformanceModel);
        }
        public async Task<HttpResponseMessage> InitializeStudentResults()
        {
            return await _httpClient.PutAsJsonAsync<ClassPerformanceModel>("api/classperformance/createstudentresults", new ClassPerformanceModel());
        }
    }
}
