namespace FimiAppUI.Contracts
{
    public interface IGradeService
    {
        Task<HttpResponseMessage> AddGrades(GradeModel grade);
        Task<IEnumerable<GradeModel>> GetAllGrades();
    }
}
