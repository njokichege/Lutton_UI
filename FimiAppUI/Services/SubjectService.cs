namespace FimiAppUI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly HttpClient _httpClient;

        public SubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<SubjectModel>> GetSubjects()
        {
            return await _httpClient.GetFromJsonAsync<SubjectModel[]>("api/subject");
        }
    }
}
