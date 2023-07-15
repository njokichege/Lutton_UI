namespace FimiAppUI.Services
{
    public class ParentService : IParentService
    {
        private readonly HttpClient _httpClient;

        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ParentModel>> GetParents()
        {
            return await _httpClient.GetFromJsonAsync<ParentModel[]>("api/parent");
        }
        public async Task<ParentModel> GetParentById(int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync<ParentModel>($"api/parent/{studentNumber}");
        }
        public async Task<HttpResponseMessage> AddParent(ParentModel parent)
        {
            return await _httpClient.PostAsJsonAsync<ParentModel>("api/parent", parent);
        }
    }
}
