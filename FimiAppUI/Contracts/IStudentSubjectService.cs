namespace FimiAppUI.Contracts
{
    public interface IStudentSubjectService
    {
        Task<HttpResponseMessage> AddStudentSubject(StudentSubjectModel studentSubjectModel);
        Task<StudentSubjectModel> FindEntry(int studentNumber, int code);
        Task<List<StudentSubjectModel>> GetSubjectsByStudentNumber(int studentNumber);
        Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId);
    }
}
