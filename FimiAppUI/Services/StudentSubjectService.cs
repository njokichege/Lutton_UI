namespace FimiAppUI.Services
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly HttpClient _httpClient;

        public StudentSubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StudentSubjectModel>> MapStudentOnSubject(int classId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<StudentSubjectModel>>($"api/class/mapstudentonsubject/{classId}");
        }
    }
}
