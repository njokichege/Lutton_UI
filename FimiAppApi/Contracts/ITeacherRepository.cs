namespace FimiAppApi.Contracts
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>> MapStaffOnTeacher();
        Task<IEnumerable<TeacherModel>> GetTeachers();
    }
}
