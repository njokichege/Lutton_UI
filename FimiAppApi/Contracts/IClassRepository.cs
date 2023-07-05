
using FimiAppLibrary.Models;

namespace FimiAppApi.Contracts
{
    public interface IClassRepository
    {
        Task<IEnumerable<ClassModel>> GetClasses();
        Task<int> CreateClass(int formId, int streamId, int sessionYearId);
        Task DeleteClass(int id);
        Task<ClassModel> GetClassByForeignKeys(int formId, int streamId, int sessionYearId);
        Task UpdateClassTeacher(int classId, int teacherId);
        Task UpdateClassGrade(int classId, int gradeId);
        Task<IEnumerable<ClassModel>> GetClassMultipleMappingById(int id);
        Task<IEnumerable<ClassModel>> GetClassMultipleMapping();
    }
}
