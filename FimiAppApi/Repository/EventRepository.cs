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
            string query = "select " +
                                "events.*," +
                                "EventTypes.* " +
                           "FROM events " +
                           "INNER JOIN EventTypes ON EventTypes.EventTypeId = events.EventTypeId";
            Type[] types =
            {
                 typeof(EventModel),
                 typeof(EventTypeModel)
            };
            Func<object[], EventModel> map = delegate (object[] obj)
            {
                EventModel eventModel = obj[0] as EventModel;
                EventTypeModel eventTypeModel = obj[1] as EventTypeModel;

                eventModel.EventType = eventTypeModel;

                return eventModel;
            };
            string splitOn = "EventTypeId";
            var data = await dapperContext.MapMultipleObjects<EventModel, dynamic>(query, types, map, splitOn, new { });

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
        public async Task<int> UpdateEvent(EventModel eventModel)
        {
            string sql = "UPDATE events \r\nSET \r\n\tText=@Text,\r\n    Start=@Start,\r\n    End=@End,\r\n    EventTypeId=@EventTypeId\r\nWHERE \r\n\tEventId=@EventId";

            var parameters = new DynamicParameters();
            parameters.Add("Text", eventModel.Text);
            parameters.Add("Start", eventModel.Start);
            parameters.Add("End", eventModel.End);
            parameters.Add("EventTypeId", eventModel.EventType.EventTypeId);
            parameters.Add("EventId", eventModel.EventId);

            return await dapperContext.UpdateData<EventModel, dynamic>(sql, parameters);
        }
        public async Task<EventModel> GetEventById(int eventId)
        {
            string sql = "SELECT * FROM Events WHERE EventId=@EventId";

            var parameters = new DynamicParameters();
            parameters.Add("EventId", eventId, DbType.Int32);

            return await dapperContext.LoadSingleData<EventModel, dynamic>(sql, parameters);
        }
        public async Task<EventModel> CreateEvent(EventModel eventModel)
        {
            string sql = "INSERT INTO Events" +
                            "(Text,EventTypeId,Start,End) " +
                         "VALUES " +
                            "(@Text,@EventTypeId,@Start,@End); " +
                         "SELECT LAST_INSERT_ID();";

            var parameters = new DynamicParameters();
            parameters.Add("Text", eventModel.Text);
            parameters.Add("EventTypeId", eventModel.EventType.EventTypeId);
            parameters.Add("Start", eventModel.Start);
            parameters.Add("End", eventModel.End);

            int id = await dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new EventModel
            {
                EventId = id,
                Text = eventModel.Text,
                EventType = eventModel.EventType,
                Start = eventModel.Start,
                End = eventModel.End
            };
            return createdModel;
        }
    }
}
