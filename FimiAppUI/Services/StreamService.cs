
using FimiAppUI.Contracts;

namespace FimiAppUI.Services
{
    public class StreamService : IStreamService
    {
        private readonly HttpClient _httpClient;

        public StreamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StreamModel>> GetStreams()
        {
            return await _httpClient.GetFromJsonAsync<StreamModel[]>("api/stream");
        }
    }
}
