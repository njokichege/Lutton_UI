namespace FimiAppApi.Contracts
{
    public interface IStaffRepository
    {
        Task<int> AddStaff(StaffModel staff);
        Task<StaffModel> GetStaff(int nationalId);
    }
}
