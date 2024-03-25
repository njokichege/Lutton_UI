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
            return await _httpClient.GetFromJsonAsync<HttpResponseMessage>($"api/report/allstudentsreportform/{studentNumbers}/{sessionYearId}/{termId}/{examTypeId}");
        }
        public async Task<byte[]> StudentReportCardBytes(int studentNumber, string sessionYearId, string termId, string examTypeId)
        {
            return await _httpClient.GetFromJsonAsync<byte[]>($"api/report/studentreportformbytes/{studentNumber}/{sessionYearId}/{termId}/{examTypeId}");
        }
    }
}
