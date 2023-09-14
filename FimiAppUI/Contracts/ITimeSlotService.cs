namespace FimiAppUI.Contracts
{
    public interface ITimeSlotService
    {
        Task<IEnumerable<TimeSlotModel>> GetTimeSlots();
    }
}
