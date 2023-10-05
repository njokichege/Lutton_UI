namespace FimiAppUI.Contracts
{
    public interface ITimetableService
    {
        Task<HttpResponseMessage> AddTimetableEntry(TimetableModel timetableModel);
        Task<TimetableModel> GetLastEntry();
        Task<List<TimetableModel>> GetTimetableModels();
        Task<List<TimetableModel>> GetTimetableModelsByClass(int classId);
    }
}
