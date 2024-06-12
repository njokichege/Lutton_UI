namespace FimiAppUI.Contracts
{
    public interface IExamTypeService
    {
        Task<IEnumerable<ExamTypeModel>> GetAllExamTypes();
        Task<ExamTypeModel> GetExamTypeIdByName(string examName);
    }
}
