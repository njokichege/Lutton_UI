namespace FimiAppApi.Contracts
{
    public interface IParentStudentRepository
    {
        Task<int> AddParentStudent(int parentNationalId);
        Task<StudentModel> GetHighestStudentNumber();
    }
}
