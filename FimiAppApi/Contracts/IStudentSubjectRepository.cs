namespace FimiAppApi.Contracts
{
    public interface IStudentSubjectRepository
    {
        Task<IEnumerable<StudentSubjectModel>> MapStudentfOnSubject(int classId);
    }
}
