namespace FimiAppUI.Contracts
{
    public interface IExamTypeService
    {
        Task<IEnumerable<ExamTypeModel>> GetAllExamTypes();
    }
}
