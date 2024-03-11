namespace FimiAppUI.Services
{
    public class StudentClassService : IStudentClassService
    {
        private readonly HttpClient _httpClient;

        public StudentClassService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddStudentClass(StudentClassModel studentClassModel)
        {
            return await _httpClient.PostAsJsonAsync<StudentClassModel>("api/studentclass", studentClassModel);
        }
        public async Task<StudentClassModel> GetStudentClass(int classId, int studentNumber)
        {
            return await _httpClient.GetFromJsonAsync<StudentClassModel>($"api/studentclass/{classId}/{studentNumber}");
        }
    }
}
