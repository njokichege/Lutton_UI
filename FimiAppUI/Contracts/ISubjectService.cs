namespace FimiAppUI.Contracts
{
    public interface ISubjectService
    {
        Task<HttpResponseMessage> CreateSubject(SubjectModel subjectModel);
        Task<IEnumerable<SubjectModel>> GetSubjects();
        Task<IEnumerable<SubjectModel>> MapSubjectOnCategory();
    }
}
