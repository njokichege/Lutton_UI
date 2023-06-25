using System.Net.Http;

namespace FimiAppUI.Services
{
    public class ClassService : IClassService
    {
        private readonly HttpClient _httpClient;

        public ClassService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ClassModel>> GetClasses()
        {
            return await _httpClient.GetFromJsonAsync<ClassModel[]>("api/class");
        }
        public async Task<IEnumerable<ClassModel>> GetMultipleMapping()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClassModel>>("api/class/MultipleMapping");
        }
    }
}
