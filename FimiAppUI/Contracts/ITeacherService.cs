namespace FimiAppUI.Contracts
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherModel>> GetMultipleMapping();
        Task<IEnumerable<TeacherModel>> GetTeachers();
    }
}
