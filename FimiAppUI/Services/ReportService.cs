using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace FimiAppUI.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AllStudentReportCards([FromBody] List<int> studentNumbers, string sessionYearId, string termId, string examTypeId)
        {
            return await _httpClient.PostAsJsonAsync<List<int>>($"api/report/allstudentsreportform/{sessionYearId}/{termId}/{examTypeId}", studentNumbers);
        }
    }
}
