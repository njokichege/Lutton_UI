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
            parameters.Add("Code", timetable.Subject.FirstOrDefault().Code);
            parameters.Add("ClassId", timetable.ClassModel.ClassId);
            parameters.Add("TimeslotId", timetable.TimeSlot.TimeslotId);
            parameters.Add("TeacherId", timetable.Teacher.FirstOrDefault().TeacherId);
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
            string sql = "SELECT " +
                            "timetable.TimeTableId AS _SplitPoint_, " +
                            "timetable.*," +
                            "subjects.Code AS _SplitPoint_," +
                            "subjects.*," +
                            "subjectcategory.SubjectCategoryId AS _SplitPoint_," +
                            "subjectcategory.*," +
                            "teacher.TeacherId AS _SplitPoint_," +
                            "teacher.*," +
                            "staff.NationalId AS _SplitPoint_," +
                            "staff.*," +
                            "class.ClassId AS _SplitPoint_," +
                            "class.*," +
                            "form.FormId FormId," +
                            "form.*," +
                            "stream.StreamId AS _SplitPoint_," +
                            "stream.*," +
                            "sessionyear.SessionYearId AS _SplitPoint_," +
                            "sessionyear.*," +
                            "timeslot.TimeslotId AS _SplitPoint_," +
                            "timeslot.* " +
                         "FROM timetable " +
                         "INNER JOIN timetableSubject ON timetableSubject.TimeTableId = timetable.TimeTableId " +
                         "INNER JOIN subjects ON subjects.Code = timetableSubject.Code " +
                         "inner join subjectcategory on subjects.SubjectCategoryId = subjectcategory.SubjectCategoryId  " +
                         "INNER JOIN timetableTeacher ON timetableTeacher.TimeTableId = timetable.TimeTableId " +
                         "INNER JOIN teacher ON teacher.TeacherId = timetableTeacher.TeacherId " +
                         "inner join staff on teacher.NationalId = staff.NationalId " +
                         "inner join class on timetable.ClassId = class.ClassId " +
                         "inner join form on class.FormId = form.FormId " +
                         "inner join stream on class.StreamId = stream.StreamId " +
                         "inner join sessionyear on class.SessionYearId = sessionyear.SessionYearId " +
                         "inner join timeslot on timetable.TimeslotId = timeslot.TimeslotId; ";

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

                if(timetableModel.Subject is null) { timetableModel.Subject.Add(subjectModel); }
                if (timetableModel.Teacher is null) { timetableModel.Teacher.Add(teacherModel); }
                timetableModel.ClassModel = classModel;
                timetableModel.TimeSlot = timeSlotModel;     
                subjectModel.SubjectCategory = subjectCategoryModel;
                classModel.Form = formModel;
                classModel.Stream = streamModel;
                classModel.SessionYear = sessionYearModel;
                teacherModel.Staff = staffModel;

                return timetableModel;
            };
            string splitOn = "_SplitPoint_";
            return await _dapperContext.MapMultipleObjects<TimetableModel, dynamic>(sql, types, map, splitOn, new { });
        }
    }
}
