namespace FimiAppApi.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DapperContext dapperContext;

        public EventRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }
        public async Task<IList<EventModel>> GetAllEvents()
        {
            string sql = "SELECT * FROM Events;";
            return await dapperContext.LoadData<EventModel, dynamic>(sql, new { });
        }
    }
}
