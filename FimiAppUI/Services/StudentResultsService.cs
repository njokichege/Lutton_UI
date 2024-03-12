namespace FimiAppUI.Services
{
    public class StudentResultsService : IStudentResultsService
    {
        private readonly HttpClient _httpClient;

        public StudentResultsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<StudentResultsModel>> GetStudentResultsByClass(int classId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<StudentResultsModel>>($"api/studentresults/{classId}");
        }
    }
}
