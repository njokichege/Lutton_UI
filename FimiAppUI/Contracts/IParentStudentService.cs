namespace FimiAppUI.Contracts
{
    public interface IParentStudentService
    {
        Task<HttpResponseMessage> AddParentStudent(ParentModel parent);
    }
}
