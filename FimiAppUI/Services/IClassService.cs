namespace FimiAppUI.Services
{
    public interface IClassService
    {
        Task<HttpResponseMessage> CreateClass(ClassModel classDetails);
        Task<IEnumerable<ClassModel>> GetClasses();
        Task<IEnumerable<ClassModel>> GetMultipleMapping();
        Task<HttpResponseMessage> UpdateClass(ClassModel classDetails);
    }
}
