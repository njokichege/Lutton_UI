﻿namespace FimiAppApi.Contracts
{
    public interface ITimetableRepository
    {
        Task<TimetableModel> AddTimetableEntry(TimetableModel timetable);
        Task<TimetableModel> GetLastEntry();
        Task<int> GetTimetableEntryByDayOfTheWeek(int classId, int subjectCode, string dayOfTheWeek);
        Task<TimetableModel> GetTimetableEntryById(int timetableId);
        Task<int> GetTimetableEntryByTimeslot(int classId, int subjectCode, int timeslotId, string dayOfTheWeek);
        Task<List<TimetableModel>> GetTimetableModels();
        Task<List<TimetableModel>> GetTimetableModelsByClass(int classId);
    }
}
