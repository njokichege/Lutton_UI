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
        public async Task<byte[]> StudentReportCardBytes(int studentNumber, string sessionYearId, string termId, string examTypeId)
        {
            return await _httpClient.GetFromJsonAsync<byte[]>($"api/report/studentreportformbytes/{studentNumber}/{sessionYearId}/{termId}/{examTypeId}");
        }
        public async Task<HttpResponseMessage> GenerateReportCard(int studentNumber, string sessionYearId, string termId, string examTypeId)
        {
            return await _httpClient.GetAsync($"api/report/studentreport/{studentNumber}/{sessionYearId}/{termId}/{examTypeId}");
        }
    }
}
