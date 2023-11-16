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
        public async Task<HttpResponseMessage> UpdateEvent(EventModel eventModel)
        {
            return await httpClient.PutAsJsonAsync<EventModel>("api/event", eventModel);
        }
        public async Task<HttpResponseMessage> CreateEvent(EventModel eventModel)
        {
            return await httpClient.PostAsJsonAsync<EventModel>("api/event", eventModel);
        }
    }
}
