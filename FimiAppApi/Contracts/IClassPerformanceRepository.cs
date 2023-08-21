namespace FimiAppApi.Contracts
{
    public interface IClassPerformanceRepository
    {
        Task<ClassPerformanceModel> GetStudentResults(int studentNumber, int sessionYearId, int termId, int examTypeId);
        Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId);
        Task UpdateStudentResults(ClassPerformanceModel classPerformanceModel);
    }
}
