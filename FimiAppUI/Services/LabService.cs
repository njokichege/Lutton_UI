namespace FimiAppUI.Services
{
    public class LabService : ILabService
    {
        private readonly HttpClient _httpClient;

        public LabService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<LabModel>> GetAllLabs()
        {
            return await _httpClient.GetFromJsonAsync<LabModel[]>("api/lab");
        }
    }
}
