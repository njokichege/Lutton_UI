namespace FimiAppApi.Contracts
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherModel>> MapStaffOnTeacher();
        Task<IEnumerable<TeacherModel>> GetTeachers();
        Task<TeacherModel> GetTeacher(int nationalId);
        Task<int> AddTeacher(TeacherModel teacher);
        Task<IEnumerable<TeacherModel>> MapStaffOnTeacherById(int teacherId);
    }
}
