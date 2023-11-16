namespace FimiAppUI.Contracts
{
    public interface IEventService
    {
        Task<HttpResponseMessage> CreateEvent(EventModel eventModel);
        Task<IList<EventModel>> GetAllEvents();
        Task<HttpResponseMessage> UpdateEvent(EventModel eventModel);
    }
}