using System.Diagnostics;

namespace FimiAppApi.Repository
{
    public class TimetableRepository : ITimetableRepository
    {
        private readonly DapperContext _dapperContext;

        public TimetableRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<TimetableModel> GetTimetableEntryById(int timetableId)
        {
            string sql = "SELECT * FROM TimeTable WHERE TimeTableId = @TimeTableId;";
            var parameteres = new DynamicParameters();
            parameteres.Add("TimeTableId", timetableId, DbType.Int32);
            return await _dapperContext.LoadSingleData<TimetableModel, dynamic>(sql, parameteres);
        }
        public async Task<TimetableModel> AddTimetableEntry(TimetableModel timetable)
        {
            string sql = "INSERT INTO " +
                            "TimeTable " +
                                "(Code,ClassId,TimeslotId,TeacherId) " +
                            "VALUES " +
                                "(@Code,@ClassId,@TimeslotId,@TeacherId); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("Code", timetable.Subject.Code);
            parameters.Add("ClassId", timetable.ClassModel.ClassId);
            parameters.Add("TimeslotId", timetable.TimeSlot.TimeslotId);
            parameters.Add("TeacherId", timetable.Teacher.TeacherId);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new TimetableModel 
            { 
                TimetableId = id,
                Subject = timetable.Subject,
                ClassModel = timetable.ClassModel,
                TimeSlot = timetable.TimeSlot,
                Teacher = timetable.Teacher
            };
            return createdModel;
        }
    }
}
