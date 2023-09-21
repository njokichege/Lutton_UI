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
                                "(Code,ClassId,TimeslotId,TeacherId,DayOfTheWeek) " +
                            "VALUES " +
                                "(@Code,@ClassId,@TimeslotId,@TeacherId,@DayOfTheWeek); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("Code", timetable.Subject.Code);
            parameters.Add("ClassId", timetable.ClassModel.ClassId);
            parameters.Add("TimeslotId", timetable.TimeSlot.TimeslotId);
            parameters.Add("TeacherId", timetable.Teacher.TeacherId);
            parameters.Add("DayOfTheWeek", timetable.DayOfTheWeek);

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
        public async Task<IEnumerable<TimetableModel>> GetTimetableModels()
        {
            string sql = "select " +
                            "timetable.Code," +
                            "timetable.DayOfTheWeek," +
                            "subjects.Code," +
                            "subjects.SubjectName," +
                            "subjectcategory.SubjectCategoryId," +
                            "subjectcategory.SubjectCategoryName," +
                            "class.ClassId," +
                            "class.FormId," +
                            "class.StreamId," +
                            "class.SessionYearId," +
                            "form.*," +
                            "stream.*," +
                            "sessionyear.*," +
                            "timeslot.TimeslotId," +
                            "timeslot.StartTime," +
                            "timeslot.EndTime," +
                            "timeslot.IsAfterBreak," +
                            "timeslot.IsBeforeBreak," +
                            "teacher.TeacherId," +
                            "teacher.NationalId," +
                            "teacher.TeacherType," +
                            "teacher.TSCNumber," +
                            "staff.NationalId," +
                            "staff.FirstName," +
                            "staff.MiddleName," +
                            "staff.Surname " +
                        "from timetable " +
                        "inner join subjects on timetable.Code = subjects.Code " +
                            "inner join subjectcategory on subjects.SubjectCategoryId = subjectcategory.SubjectCategoryId " +
                        "inner join class on timetable.ClassId = class.ClassId " +
                            "inner join form on class.FormId = form.FormId " +
                            "inner join stream on class.StreamId = stream.StreamId " +
                            "inner join sessionyear on class.SessionYearId = sessionyear.SessionYearId " +
                        "inner join timeslot on timetable.TimeslotId = timeslot.TimeslotId " +
                        "inner join teacher on timetable.TeacherId = teacher.TeacherId " +
                            "inner join staff on teacher.NationalId = staff.NationalId;";

            Type[] types =
            {
                 typeof(TimetableModel),
                 typeof(SubjectModel),
                 typeof(SubjectCategoryModel),
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel),
                 typeof(SessionYearModel),
                 typeof(TimeSlotModel),
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], TimetableModel> map = delegate (object[] obj)
            {
                TimetableModel timetableModel = obj[0] as TimetableModel;
                SubjectModel subjectModel = obj[1] as SubjectModel;
                SubjectCategoryModel subjectCategoryModel = obj[2] as SubjectCategoryModel;
                ClassModel classModel = obj[3] as ClassModel;
                FormModel formModel = obj[4] as FormModel;
                StreamModel streamModel = obj[5] as StreamModel;
                SessionYearModel sessionYearModel = obj[6] as SessionYearModel;
                TimeSlotModel timeSlotModel = obj[7] as TimeSlotModel;
                TeacherModel teacherModel = obj[8] as TeacherModel;
                StaffModel staffModel = obj[9] as StaffModel;

                timetableModel.Subject = subjectModel;
                timetableModel.ClassModel = classModel;
                timetableModel.TimeSlot = timeSlotModel;
                timetableModel.Teacher = teacherModel;
                subjectModel.SubjectCategory = subjectCategoryModel;
                classModel.Form = formModel;
                classModel.Stream = streamModel;
                classModel.SessionYear = sessionYearModel;
                teacherModel.Staff = staffModel;

                return timetableModel;
            };
            string splitOn = "Code,SubjectCategoryId,ClassId,FormId,StreamId,SessionYearId,TimeslotId,TeacherId,NationalId";
            return await _dapperContext.MapMultipleObjects<TimetableModel, dynamic>(sql, types, map, splitOn, new { });
        }
    }
}
