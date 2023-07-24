namespace FimiAppUI.Contracts
{
    public interface IStaffService
    {
        Task<HttpResponseMessage> AddStaff(StaffModel staff);
    }
}
