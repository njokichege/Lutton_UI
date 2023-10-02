namespace FimiAppUI.Contracts
{
    public interface ITimetableService
    {
        Task<HttpResponseMessage> AddTimetableEntry(TimetableModel timetableModel);
        Task<TimetableModel> GetLastEntry();
        Task<IEnumerable<TimetableModel>> GetTimetableModels();
    }
}
