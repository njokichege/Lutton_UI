using FimiAppApi.Context;

namespace FimiAppApi.Repository
{
    public class TimetableTeacherSubjectRepository : ITimetableTeacherSubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public TimetableTeacherSubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<TimetableTeacherSubjectModel> GetTimetableTeacherSubjectEntryById(int id)
        {
            string sql = "SELECT * FROM TimetableTeacherSubject WHERE TimetableSubjectId = @TimetableSubjectId;";
            var parameteres = new DynamicParameters();
            parameteres.Add("TimetableSubjectId", id, DbType.Int32);
            return await _dapperContext.LoadSingleData<TimetableTeacherSubjectModel, dynamic>(sql, parameteres);
        }
        public async Task<TimetableTeacherSubjectModel> AddTimetableEntry(TimetableTeacherSubjectModel timetableTeacherSubjectModel)
        {
            string sql = "INSERT INTO TimetableTeacherSubject " +
                            "(TimeTableId,TeacherSubjectId) " +
                            "values " +
                            "(@TimeTableId,@TeacherSubjectId); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("TimeTableId", timetableTeacherSubjectModel.TimeTableId);
            parameters.Add("TeacherSubjectId", timetableTeacherSubjectModel.TeacherSubjectId);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new TimetableTeacherSubjectModel
            {
                TimetableSubjectId = id,
                TimeTableId = timetableTeacherSubjectModel.TimeTableId,
                TeacherSubjectId = timetableTeacherSubjectModel.TeacherSubjectId
            };
            return createdModel;
        }
    }
}
