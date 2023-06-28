
using FimiAppLibrary.Models;

namespace FimiAppApi.Contracts
{
    public interface IClassRepository
    {
        Task<IEnumerable<ClassModel>> GetClasses();
        Task<ClassModel> GetClass(int id);
        Task<int> CreateClass(ClassModel classDetails);
        Task DeleteClass(int id);
        Task<IEnumerable<ClassModel>> GetMultipleMapping();
        Task<ClassModel> GetClassByForeignKeys(ClassModel classDetails);
        Task UpdateClassTeacher(int id, ClassModel classModel);
        Task UpdateClassGrade(int id, ClassModel classModel);
    }
}
