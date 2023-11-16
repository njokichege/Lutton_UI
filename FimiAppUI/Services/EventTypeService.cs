using System.Net.Http;

namespace FimiAppUI.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly HttpClient httpClient;

        public EventTypeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<EventTypeModel>> GetAllEventTypes()
        {
            return await httpClient.GetFromJsonAsync<EventTypeModel[]>("api/eventtype");
        }
        public async Task<EventTypeModel> GetEventTypeByName(string eventType)
        {
            return await httpClient.GetFromJsonAsync<EventTypeModel>($"api/eventtype/{eventType}");
        }
    }
}
