namespace FimiAppApi.Contracts
{
    public interface IEventTypeRepository
    {
        Task<IEnumerable<EventTypeModel>> GetAllEventTypes();
        Task<EventTypeModel> GetEventTypeByName(string eventType);
    }
}