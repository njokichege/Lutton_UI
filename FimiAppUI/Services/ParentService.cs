namespace FimiAppUI.Services
{
    public class ParentService : IParentService
    {
        private readonly HttpClient _httpClient;

        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ParentModel> GetParentById(int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync<ParentModel>($"api/parent/{studentNumber}");
        }
    }
}
