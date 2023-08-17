namespace FimiAppApi.Contracts
{
    public interface IClassPerformanceRepository
    {
        Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId);
        Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClassAndSubject(int classId, int sessionYearId, int termId, int examTypeId, string subjectName);
    }
}
