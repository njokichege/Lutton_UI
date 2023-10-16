namespace FimiAppUI.Contracts
{
    public interface IStudentSubjectService
    {
        Task<List<StudentSubjectModel>> GetSubjectsByStudentNumber(int studentNumber);
        Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId);
    }
}
