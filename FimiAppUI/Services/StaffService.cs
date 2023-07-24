namespace FimiAppUI.Services
{
    public class StaffService : IStaffService
    {
        private readonly HttpClient _httpClient;

        public StaffService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddStaff(StaffModel staff)
        {
            return await _httpClient.PostAsJsonAsync<StaffModel>("api/staff", staff);
        }
    }
}
