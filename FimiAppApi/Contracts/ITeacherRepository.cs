namespace FimiAppApi.Contracts
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>> MapStaffOnTeacher();
        Task<IEnumerable<TeacherModel>> GetTeachers();
        Task<TeacherModel> GetTeacherById(int nationalId);
        Task<IEnumerable<TeacherModel>> MapStaffOnTeacherById(int teacherId);
        Task<TeacherModel> AddTeacher(TeacherModel teacher);
    }
}
