using System.Collections.Generic;

namespace FimiAppUI.Services
{
    public class TermService : ITermService
    {
        private readonly HttpClient _httpClient;

        public TermService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TermModel>> GetAllTerms()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TermModel>>("api/term");
        }
        public async Task<TermModel> GetTermIdByName(string termName)
        {
            return await _httpClient.GetFromJsonAsync<TermModel>($"api/term/{termName}");
        }
    }
}
