namespace FimiAppApi.Contracts
{
    public interface IStudentSubjectRepository
    {
        Task<List<StudentSubjectModel>> GetSubjectsByStudentNumber(int studentNumber);
        Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId);
    }
}
