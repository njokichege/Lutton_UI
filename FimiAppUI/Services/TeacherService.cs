using FimiAppUI.Contracts;
using System.Net.Http;

namespace FimiAppUI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient _httpClient;

        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TeacherModel>> GetTeachers()
        {
            return await _httpClient.GetFromJsonAsync<TeacherModel[]>("api/teacher");
        }
        public async Task<IEnumerable<TeacherModel>> MapStaffOnTeacher()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TeacherModel>>("api/teacher/mapstaffonteacher");
        }
    }
}
