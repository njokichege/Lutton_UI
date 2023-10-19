namespace FimiAppApi.Contracts
{
    public interface IParentStudentRepository
    {
        Task<ParentStudentModel> AddParentStudent(ParentStudentModel parentStudent);
        Task<ParentStudentModel> GetParentStudentById(int id);
    }
}
