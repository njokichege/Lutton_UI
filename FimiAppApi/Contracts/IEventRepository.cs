namespace FimiAppApi.Contracts
{
    public interface IEventRepository
    {
        Task<EventModel> CreateEvent(EventModel eventModel);
        Task<IList<EventModel>> GetAllEvents();
        Task<EventModel> GetEventById(int eventId);
        Task<int> UpdateEvent(EventModel eventModel);
    }
}