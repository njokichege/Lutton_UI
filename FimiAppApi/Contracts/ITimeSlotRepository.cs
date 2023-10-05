namespace FimiAppApi.Contracts
{
    public interface ITimeSlotRepository
    {
        Task<List<TimeSlotModel>> GetAllTimaSlots();
    }
}
