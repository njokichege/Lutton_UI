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
    }
}
