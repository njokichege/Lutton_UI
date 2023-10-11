
using FimiAppUI.Contracts;
using System.Net.Http;

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
        public async Task<StreamModel> GetStreamById(int streamId)
        {
            return await _httpClient.GetFromJsonAsync<StreamModel>($"api/stream/{streamId}");
        }
        public async Task<int> GetStreamByName(string streamName)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/stream/streambyname/{streamName}");
        }
    }
}
