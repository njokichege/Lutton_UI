namespace FimiAppUI.Contracts
{
    public interface IStudentSubjectService
    {
        Task<IEnumerable<ClassSubjectList>> MapStudentOnSubject(int classId);
    }
}
