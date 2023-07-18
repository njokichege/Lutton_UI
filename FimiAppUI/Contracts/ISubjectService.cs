namespace FimiAppUI.Contracts
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectModel>> GetSubjects();
    }
}
