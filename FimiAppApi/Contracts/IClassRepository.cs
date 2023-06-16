namespace FimiAppApi.Contracts
{
    public interface IClassRepository
    {
        Task<IEnumerable<ClassModel>> GetClasses();
        Task<ClassModel> GetClass(int id);
        Task InsertClass(ClassModel student);
    }
}
