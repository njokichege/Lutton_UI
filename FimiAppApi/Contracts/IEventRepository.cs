namespace FimiAppApi.Contracts
{
    public interface IEventRepository
    {
        Task<IList<EventModel>> GetAllEvents();
    }
}