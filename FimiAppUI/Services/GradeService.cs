namespace FimiAppUI.Services
{
    public class GradeService : IGradeService
    {
        private readonly HttpClient _httpClient;

        public GradeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<GradeModel>> GetAllGrades()
        {
            return await _httpClient.GetFromJsonAsync<GradeModel[]>("api/grade");
        }
        public async Task<HttpResponseMessage> AddGrades(GradeModel grade)
        {
            return await _httpClient.PostAsJsonAsync<GradeModel>("api/grade", grade);
        }
    }
}
