namespace FimiAppApi.Contracts
{
    public interface IStudentSubjectRepository
    {
        Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId);
    }
}
