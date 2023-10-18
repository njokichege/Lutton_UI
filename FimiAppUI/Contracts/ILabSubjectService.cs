namespace FimiAppUI.Contracts
{
    public interface ILabSubjectService
    {
        Task<IEnumerable<LabSubjectModel>> GetAllLabSubjects();
    }
}