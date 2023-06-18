namespace FimiAppUI.Services
{
    public interface IClassService
    {
        Task<IEnumerable<ClassModel>> GetClasses();
    }
}
