namespace FimiAppUI.Contracts
{
    public interface ITeacherSubjectService
    {
        Task<HttpResponseMessage> CreateTeacherSubject(TeacherSubjectModel teacherSubjectModel);
        Task<IEnumerable<TeacherSubjectModel>> GetMultipleMapping();
        Task<IEnumerable<TeacherSubjectModel>> GetMultipleMappingByTeacher(int teacherId);
    }
}
