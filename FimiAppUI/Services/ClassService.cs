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
        public async Task<HttpResponseMessage> CreateClass(ClassModel classDetails)
        {
           return await _httpClient.PostAsJsonAsync<ClassModel>("api/class",classDetails);
        }
        public async Task<HttpResponseMessage> UpdateClass(ClassModel classDetails)
        {
            return await _httpClient.PutAsJsonAsync<ClassModel>("api/class/id", classDetails);
        }
        public async Task<ClassModel> GetClassById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClassModel>($"api/class/{id}");
        }
    }
}
