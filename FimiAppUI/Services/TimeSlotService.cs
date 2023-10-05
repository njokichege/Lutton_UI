namespace FimiAppUI.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly HttpClient _httpClient;

        public TimeSlotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<TimeSlotModel>> GetTimeSlots()
        {
            return await _httpClient.GetFromJsonAsync<List<TimeSlotModel>>("api/timeslot");
        }
    }
}
