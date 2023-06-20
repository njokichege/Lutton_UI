namespace FimiAppUI.Services
{
    public interface IClassService
    {
        Task<IEnumerable<ClassModel>> GetClasses();
        Task<IEnumerable<ClassModel>> GetClassFormStreamMultipleMapping();
    }
}
