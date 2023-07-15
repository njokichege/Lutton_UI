namespace FimiAppUI.Services
{
    public class ParentStudentService : IParentStudentService
    {
        private readonly HttpClient _httpClient;

        public ParentStudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddParentStudent(ParentModel parent)
        {
            return await _httpClient.PostAsJsonAsync($"api/parentstudent",parent);
        }
    }
}
