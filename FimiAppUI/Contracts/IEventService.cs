namespace FimiAppUI.Contracts
{
    public interface IEventService
    {
        Task<IList<EventModel>> GetAllEvents();
    }
}