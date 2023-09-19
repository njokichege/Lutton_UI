namespace FimiAppUI.Contracts
{
    public interface ITimetableService
    {
        Task<HttpResponseMessage> AddTimetableEntry(TimetableModel timetableModel);
        Task<IEnumerable<TimetableModel>> GetTimetableModels();
    }
}
