namespace FimiAppUI.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherModel>> GetTeachers();
    }
}
