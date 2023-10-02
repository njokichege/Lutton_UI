namespace FimiAppApi.Contracts
{
    public interface ITimetableRepository
    {
        Task<TimetableModel> AddTimetableEntry(TimetableModel timetable);
        Task<TimetableModel> GetLastEntry();
        Task<TimetableModel> GetTimetableEntryById(int timetableId);
        Task<IEnumerable<TimetableModel>> GetTimetableModels();
    }
}
