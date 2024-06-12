
namespace FimiAppUI.Contracts
{
    public interface IExamService
    {
        Task<HttpResponseMessage> AddExam(ExamModel examModel);
        Task<ExamModel> GetExamByTermAndExamType(int termId, int examTypeId, int schoolYear);
        Task<IEnumerable<ExamModel>> GetExamsBySchoolYear(int schoolYear);
    }
}