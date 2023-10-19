namespace FimiAppApi.Contracts
{
    public interface IStudentSubjectRepository
    {
        Task<StudentSubjectModel> AddStudentSubject(StudentSubjectModel studentSubjectModel);
        Task<StudentSubjectModel> FindEntry(int studentNumber, int code);
        Task<StudentSubjectModel> GetStudentSubjectById(int studentSubjectModelId);
        Task<List<StudentSubjectModel>> GetSubjectsByStudentNumber(int studentNumber);
        Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId);
    }
}
