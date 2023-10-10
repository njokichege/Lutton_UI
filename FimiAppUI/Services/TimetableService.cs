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
        public async Task<List<TimetableModel>> GetTimetableModels()
        {
            return await _httpClient.GetFromJsonAsync<List<TimetableModel>>("api/timetable");
        }
        public async Task<List<TimetableModel>> GetTimetableModelsByClass(int classId)
        {
            return await _httpClient.GetFromJsonAsync<List<TimetableModel>>($"api/timetable/timetableentriesbyclass/{classId}");
        }
        public async Task<int> GetTimetableEntryByDayOfTheWeek(int classId, int subjectCode, string dayOfTheWeek)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/timetable/{classId}/{subjectCode}/{dayOfTheWeek}");
        }
        public async Task<int> GetTimetableEntryByTimeslot(int classId, int subjectCode, int timeslotId, string dayOfTheWeek)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/timetable/{classId}/{subjectCode}/{timeslotId}/{dayOfTheWeek}");
        }
        public async Task<TimetableModel> GetLastEntry()
        {
            return await _httpClient.GetFromJsonAsync<TimetableModel>("api/timetable/getlastentry");
        }
    }
}
