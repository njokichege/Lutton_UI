namespace FimiAppUI.Contracts
{
    public interface ITimetableService
    {
        Task<HttpResponseMessage> AddTimetableEntry(TimetableModel timetableModel);
        Task<HttpResponseMessage> AddTimetableEntryWithLab(TimetableModel timetableModel);
        Task<int> GetLabAvailability(int timeslotId, string day);
        Task<TimetableModel> GetLastEntry();
        Task<List<LessonCountModel>> GetLessonCounts();
        Task<int> GetTimetableEntryByDayOfTheWeek(int classId, int subjectCode, string dayOfTheWeek);
        Task<int> GetTimetableEntryByTimeslot(int classId, int subjectCode, int timeslotId, string dayOfTheWeek);
        Task<List<TimetableModel>> GetTimetableModels();
        Task<List<TimetableModel>> GetTimetableModelsByClass(int classId);
        Task<List<TimetableModel>> GetTimetableModelsByTeacher(int teacherId);
    }
}
