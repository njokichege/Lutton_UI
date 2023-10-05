namespace FimiAppUI.Contracts
{
    public interface ITimeSlotService
    {
        Task<List<TimeSlotModel>> GetTimeSlots();
    }
}
