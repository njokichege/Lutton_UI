using Dapper;
using System.Data;

namespace FimiAppUI.Services
{
    public class SessionYearService : ISessionYearService
    {
        private readonly HttpClient _httpClient;

        public SessionYearService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SessionYearModel>> GetSessionYear()
        {
            return await _httpClient.GetFromJsonAsync<SessionYearModel[]>("api/sessionyear");
        }
        public async Task<HttpResponseMessage> CreateSessionYear(SessionYearModel sessionYear)
        {
            return await _httpClient.PostAsJsonAsync<SessionYearModel>("api/sessionyear", sessionYear);
        }
    }
}
