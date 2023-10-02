namespace FimiAppApi.Contracts
{
    public interface ITimetableTeacherSubjectRepository
    {
        Task<TimetableTeacherSubjectModel> AddTimetableEntry(TimetableTeacherSubjectModel timetableTeacherSubjectModel);
        Task<TimetableTeacherSubjectModel> GetTimetableTeacherSubjectEntryById(int id);
    }
}