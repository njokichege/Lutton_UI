namespace FimiAppUI.Services
{
    public class StaffService : IStaffService
    {
        private readonly HttpClient _httpClient;

        public StaffService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
