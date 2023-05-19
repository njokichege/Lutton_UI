namespace FimiAppLibrary.DataAccess
{
    public interface IClassData
    {
        Task<List<ClassModel>> GetClass();
        Task InsertClass(ClassModel student);
        Task InsertStudent(ClassModel student);
    }
}