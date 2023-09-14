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
        public async Task<int> AddTimetableEntry(TimetableModel timetable)
        {
            string sql = "INSERT INTO TimeTable(\n    Code,\n    ClassId,\n    TimeslotId,\n    TeacherId\n)\nVALUES\n(@Code,@ClassId,@TimeslotId,@TeacherId);";
            var parameters = new DynamicParameters();
            parameters.Add("Code", timetable.Subject.Code);
            parameters.Add("ClassId", timetable.ClassModel.ClassId);
            parameters.Add("TimeslotId", timetable.TimeSlot.TimeslotId);
            parameters.Add("TeacherId", timetable.Teacher.TeacherId);

            var id = await _dapperContext.CreateData<TimetableModel, dynamic>(sql, parameters);
            return id;
        }
    }
}
