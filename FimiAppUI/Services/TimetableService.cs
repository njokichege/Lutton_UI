namespace FimiAppUI.Services
{
    public class TimetableService : ITimetableService
    {
        private readonly HttpClient _httpClient;

        public TimetableService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddTimetableEntry(TimetableModel timetableModel)
        {
            return await _httpClient.PostAsJsonAsync<TimetableModel>("api/timetable", timetableModel);
        }
    }
}
