namespace FimiAppApi.Contracts
{
    public interface ITeacherSubjectRepository
    {
        Task<int> CreateTeacherSubject(int teacherId, int subjectCode);
        Task<IEnumerable<TeacherSubjectModel>> GetSubjectsMultipleMapping();
        Task<IEnumerable<TeacherSubjectModel>> GetSubjectsMultipleMappingByTeacher(int teacherId);
        Task<TeacherSubjectModel> GetTeacherSubject(int teacherId, int subjectCode);
    }
}
