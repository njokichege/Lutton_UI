using FimiAppApi.Context;

namespace FimiAppApi.Repository
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly DapperContext _dapperContext;

        public TimeSlotRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<TimeSlotModel>> GetAllTimaSlots()
        {
            string sql = "SELECT * FROM TimeSlot";
            return await _dapperContext.LoadData<TimeSlotModel, dynamic>(sql, new { });
        }
    }
}
