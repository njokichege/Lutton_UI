using FimiAppApi.Dto;

namespace FimiAppApi.Contracts
{
    public interface IClassRepository
    {
        Task<IEnumerable<ClassModel>> GetClasses();
        Task<ClassModel> GetClass(int id);
        Task<ClassModel> CreateClass(ClassForCreationDto classForCreation);
        Task UpdateClassGrade(int id, ClassForUpdateGradesDto classForUpdate);
        Task DeleteClass(int id);
    }
}
