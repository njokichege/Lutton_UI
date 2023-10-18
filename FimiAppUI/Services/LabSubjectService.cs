namespace FimiAppUI.Services
{
    public class LabSubjectService : ILabSubjectService
    {
        private readonly HttpClient _httpClient;

        public LabSubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<LabSubjectModel>> GetAllLabSubjects()
        {
            return await _httpClient.GetFromJsonAsync<LabSubjectModel[]>("api/labsubject");
        }
    }
}
