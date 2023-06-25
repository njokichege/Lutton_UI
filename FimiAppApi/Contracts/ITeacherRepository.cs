namespace FimiAppApi.Contracts
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>> GetMapStaffOnTeacher();
        Task<IEnumerable<TeacherModel>> GetTeachers();
    }
}
