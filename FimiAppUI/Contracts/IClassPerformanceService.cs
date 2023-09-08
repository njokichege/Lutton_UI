namespace FimiAppUI.Contracts
{
    public interface IClassPerformanceService
    {
        Task<IEnumerable<ClassPerformanceModel>> GetClassPerformancePerTerm(int sessionId, int termId, int classId, int studentNumber);
        Task<IEnumerable<ClassPerformanceModel>> GetStudentResults(int studentNumber);
        Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId);
        Task<HttpWebResponse> Print(int studentNumber);
        Task<HttpResponseMessage> UpdateStudentResults(ClassPerformanceModel classPerformanceModel);
    }
}
