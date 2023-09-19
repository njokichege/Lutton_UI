namespace FimiAppApi.Contracts
{
    public interface ISubjectRepository
    {
        Task<SubjectModel> CreateSubject(int code, string name, int category);
        Task<SubjectModel> GetSubjectId(int code);
        Task<IEnumerable<SubjectModel>> GetSubjects();
        Task<IEnumerable<SubjectModel>> MapSubjectOnCategory();
    }
}
