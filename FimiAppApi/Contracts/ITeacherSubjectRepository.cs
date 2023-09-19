namespace FimiAppApi.Contracts
{
    public interface ITeacherSubjectRepository
    {
        Task<TeacherSubjectModel> AddTeacherSubjectWithoutTeacherId(int subjectCode);
        Task<TeacherSubjectModel> CreateTeacherSubject(int teacherId, int subjectCode);
        Task<int> GetLastTeacher();
        Task<IEnumerable<TeacherSubjectModel>> GetSubjectsMultipleMapping();
        Task<IEnumerable<TeacherSubjectModel>> GetSubjectsMultipleMappingBySubject(int subjectCode);
        Task<IEnumerable<TeacherSubjectModel>> GetSubjectsMultipleMappingByTeacher(int teacherId);
        Task<TeacherSubjectModel> GetTeacherSubject(int teacherId, int subjectCode);
        Task<TeacherSubjectModel> GetTeacherSubjectById(int id);
    }
}
