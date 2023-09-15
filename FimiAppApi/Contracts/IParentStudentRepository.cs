namespace FimiAppApi.Contracts
{
    public interface IParentStudentRepository
    {
        Task<ParentStudentModel> AddParentStudent(int parentNationalId);
        Task<int> GetHighestStudentNumber();
        Task<ParentStudentModel> GetParentStudentById(int id);
    }
}
