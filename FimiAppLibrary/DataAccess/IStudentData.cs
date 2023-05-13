namespace FimiAppLibrary.DataAccess
{
    public interface IStudentData
    {
        Task<List<StudentModel>> GetStudent();
        Task InsertStudent(StudentModel student);
    }
}