namespace FimiAppApi.Contracts
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<SubjectModel>> GetSubjects();
    }
}
