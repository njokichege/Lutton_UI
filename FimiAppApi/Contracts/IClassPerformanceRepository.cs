namespace FimiAppApi.Contracts
{
    public interface IClassPerformanceRepository
    {
        Task<IEnumerable<ClassPerformanceModel>> GetClassPerformancePerTerm(int sessionId, int termId, int classId, int studentNumber);
        Task<IEnumerable<ClassPerformanceModel>> GetStudentResults(int studentNumber);
        Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId);
        Task<ClassPerformanceModel> GetTotalPerformanceAsync(ClassPerformanceModel EndTermPerformance, ClassPerformanceModel MidTermPerformance);
        Task UpdateStudentResults(ClassPerformanceModel classPerformanceModel);
    }
}
