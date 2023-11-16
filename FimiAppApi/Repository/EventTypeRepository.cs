using FimiAppApi.Context;
using Microsoft.Extensions.Logging;

namespace FimiAppApi.Repository
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly DapperContext dapperContext;

        public EventTypeRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }
        public async Task<IEnumerable<EventTypeModel>> GetAllEventTypes()
        {
            string sql = "SELECT * FROM eventtypes;";
            return await dapperContext.LoadData<EventTypeModel, dynamic>(sql, new { });
        }
        public async Task<EventTypeModel> GetEventTypeByName(string eventType)
        {
            string sql = "SELECT * FROM eventtypes where eventtypes.EventType = @EventType; ";

            var parameters = new DynamicParameters();
            parameters.Add("EventType", eventType);

            return await dapperContext.LoadSingleData<EventTypeModel, dynamic>(sql, parameters);
        }
    }
}
