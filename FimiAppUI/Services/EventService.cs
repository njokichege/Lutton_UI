using System.Net.Http;

namespace FimiAppUI.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient httpClient;

        public EventService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IList<EventModel>> GetAllEvents()
        {
            return await httpClient.GetFromJsonAsync<EventModel[]>("api/event");
        }
    }
}
