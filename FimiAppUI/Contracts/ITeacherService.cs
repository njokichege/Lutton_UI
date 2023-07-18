namespace FimiAppUI.Contracts
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherModel>> MapStaffOnTeacher();
        Task<IEnumerable<TeacherModel>> GetTeachers();
    }
}
