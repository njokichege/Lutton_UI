namespace FimiAppUI.Contracts
{
    public interface IEventTypeService
    {
        Task<IEnumerable<EventTypeModel>> GetAllEventTypes();
        Task<EventTypeModel> GetEventTypeByName(string eventType);
    }
}