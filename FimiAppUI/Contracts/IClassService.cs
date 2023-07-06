namespace FimiAppUI.Contracts
{
    public interface IClassService
    {
        Task<HttpResponseMessage> CreateClass(ClassModel classDetails);
        Task<ClassModel> GetClassByForeignKeys(int formId, int streamId, int sessionYearId);
        Task<ClassModel> GetClassById(int id);
        Task<IEnumerable<ClassModel>> GetClasses();
        Task<IEnumerable<ClassModel>> GetMultipleMapping();
        Task<HttpResponseMessage> UpdateClass(ClassModel classDetails);
    }
}
