namespace FimiAppApi.Contracts
{
    public interface IGradeRepository
    {
        Task<int> AddGrades(GradeModel grade);
        Task<IEnumerable<GradeModel>> GetAllGrades();
    }
}
