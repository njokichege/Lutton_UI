namespace FimiAppApi.Contracts
{
    public interface ILabSubjectRepository
    {
        Task<List<LabSubjectModel>> GetAllLabSubjects();
    }
}