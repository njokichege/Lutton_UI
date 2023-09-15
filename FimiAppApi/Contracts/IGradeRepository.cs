namespace FimiAppApi.Contracts
{
    public interface IGradeRepository
    {
        Task<GradeModel> AddGrades(GradeModel grade);
        Task<IEnumerable<GradeModel>> GetAllGrades();
        Task<GradeModel> GetGradeById(int gradeId);
    }
}
