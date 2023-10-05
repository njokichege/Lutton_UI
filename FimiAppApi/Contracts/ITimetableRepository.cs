namespace FimiAppApi.Contracts
{
    public interface ITimetableRepository
    {
        Task<TimetableModel> AddTimetableEntry(TimetableModel timetable);
        Task<TimetableModel> GetLastEntry();
        Task<TimetableModel> GetTimetableEntryById(int timetableId);
        Task<List<TimetableModel>> GetTimetableModels();
        Task<List<TimetableModel>> GetTimetableModelsByClass(int classId);
    }
}
