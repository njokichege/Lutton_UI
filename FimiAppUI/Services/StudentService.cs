using FimiAppUI.Contracts;
using System.IO;

namespace FimiAppUI.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StudentModel>> MapClassOnStudent(int classId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<StudentModel>>($"api/student/");
        }
    }
}
