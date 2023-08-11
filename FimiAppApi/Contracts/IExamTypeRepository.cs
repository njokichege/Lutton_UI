namespace FimiAppApi.Contracts
{
    public interface IExamTypeRepository
    {
        Task<IEnumerable<ExamTypeModel>> GetAllExamTypes();
    }
}
