namespace FimiAppUI.Contracts
{
    public interface ITimetableTeacherSubjectService
    {
        Task<HttpResponseMessage> AddTimetableEntry(TimetableTeacherSubjectModel timetableTeacherSubjectModel);
    }
}