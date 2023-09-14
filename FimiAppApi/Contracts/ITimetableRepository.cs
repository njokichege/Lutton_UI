namespace FimiAppApi.Contracts
{
    public interface ITimetableRepository
    {
        Task<int> AddTimetableEntry(TimetableModel timetable);
    }
}
