using System.Net.Http;

namespace FimiAppUI.Services
{
    public class TimetableTeacherSubjectService : ITimetableTeacherSubjectService
    {
        private readonly HttpClient _httpClient;

        public TimetableTeacherSubjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddTimetableEntry(TimetableTeacherSubjectModel timetableTeacherSubjectModel)
        {
            return await _httpClient.PostAsJsonAsync<TimetableTeacherSubjectModel>("api/timetableteachersubject", timetableTeacherSubjectModel);
        }
    }
}
