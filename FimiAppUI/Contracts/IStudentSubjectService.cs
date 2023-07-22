namespace FimiAppUI.Contracts
{
    public interface IStudentSubjectService
    {
        Task<IEnumerable<StudentSubjectModel>> MapStudentOnSubject(int classId);
    }
}
