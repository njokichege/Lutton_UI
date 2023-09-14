namespace FimiAppApi.Contracts
{
    public interface ITimeSlotRepository
    {
        Task<IEnumerable<TimeSlotModel>> GetAllTimaSlots();
    }
}
