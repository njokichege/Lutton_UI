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

        public async Task<HttpResponseMessage> GetStudentListStudent(List<int> students)
        {
            return await _httpClient.PostAsJsonAsync<List<int>>("api/report", students);
        }
    }
}
