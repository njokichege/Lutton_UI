namespace FimiAppUI.Contracts
{
    public interface IParentStudentService
    {
        Task<HttpResponseMessage> AddParentStudent(ParentStudentModel parentStudent);
    }
}
