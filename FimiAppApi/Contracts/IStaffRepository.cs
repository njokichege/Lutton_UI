namespace FimiAppApi.Contracts
{
    public interface IStaffRepository
    {
        Task<StaffModel> AddStaff(StaffModel staff);
        Task<StaffModel> GetStaffById(int nationalId);
    }
}
