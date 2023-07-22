namespace FimiAppApi.Contracts
{
    public interface ISubjectRepository
    {
        Task<int> CreateSubject(int code, string name, int category);
        Task<SubjectModel> GetSubject(int code);
        Task<IEnumerable<SubjectModel>> GetSubjects();
        Task<IEnumerable<SubjectModel>> MapSubjectOnCategory();
    }
}
