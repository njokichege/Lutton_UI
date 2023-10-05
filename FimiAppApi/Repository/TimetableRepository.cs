using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Diagnostics;
using System.Xml;

namespace FimiAppApi.Repository
{
    public class TimetableRepository : ITimetableRepository
    {
        private readonly DapperContext _dapperContext;

        public TimetableRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<TimetableModel> GetLastEntry()
        {
            string sql = "select max(TimeTableId) from timetable;";
            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, new {});
            var createdModel = new TimetableModel
            {
                TimetableId = id
            };
            return createdModel;
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
                                "(ClassId,TimeslotId,DayOfTheWeek) " +
                            "VALUES " +
                                "(@ClassId,@TimeslotId,@DayOfTheWeek); SELECT LAST_INSERT_ID();";
            var parameters = new DynamicParameters();
            parameters.Add("ClassId", timetable.ClassModel.ClassId);
            parameters.Add("TimeslotId", timetable.TimeSlot.TimeslotId);
            parameters.Add("DayOfTheWeek", timetable.DayOfTheWeek);

            int id = await _dapperContext.LoadSingleData<int, dynamic>(sql, parameters);
            var createdModel = new TimetableModel 
            { 
                TimetableId = id,
                ClassModel = timetable.ClassModel,
                TimeSlot = timetable.TimeSlot,
            };
            return createdModel;
        }
        public async Task<List<TimetableModel>> GetTimetableModels()
        {
            string sql = "SELECT " +
                            "timetable.TimeTableId, " +
                            "timetable.DayOfTheWeek," +
                            "teacherSubject.TeacherSubjectId," +
                            "subjects.Code," +
                            "subjects.SubjectName," +
                            "subjectcategory.SubjectCategoryId," +
                            "subjectcategory.SubjectCategoryName," +
                            "teacher.TeacherId," +
                            "teacher.TeacherType," +
                            "teacher.TSCNumber," +
                            "staff.NationalId," +
                            "staff.FirstName," +
                            "staff.MiddleName," +
                            "staff.Surname," +
                            "staff.PhoneNumber," +
                            "staff.Gender," +
                            "staff.EmploymentDate," +
                            "staff.Designation," +
                            "staff.DateOfBirth," +
                            "class.ClassId," +
                            "form.FormId," +
                            "form.Form," +
                            "stream.StreamId," +
                            "stream.Stream," +
                            "sessionyear.SessionYearId," +
                            "sessionyear.StartDate," +
                            "sessionyear.EndDate," +
                            "timeslot.TimeslotId," +
                            "timeslot.StartTime," +
                            "timeslot.EndTime," +
                            "timeslot.IsBeforeBreak," +
                            "timeslot.IsAfterBreak " +
                         "FROM timetable " +
                         "INNER JOIN timetableTeacherSubject ON timetableTeacherSubject.TimeTableId = timetable.TimeTableId " +
                         "INNER JOIN teacherSubject ON teacherSubject.TeacherSubjectId = timetableTeacherSubject.TeacherSubjectId " +
                         "INNER JOIN subjects ON subjects.Code = teacherSubject.Code " +
                         "inner join subjectcategory on subjects.SubjectCategoryId = subjectcategory.SubjectCategoryId  " +
                         "INNER JOIN teacher ON teacher.TeacherId = teacherSubject.TeacherId " +
                         "inner join staff on teacher.NationalId = staff.NationalId "+
                         "inner join class on timetable.ClassId = class.ClassId " +
                         "inner join form on class.FormId = form.FormId " +
                         "inner join stream on class.StreamId = stream.StreamId " +
                         "inner join sessionyear on class.SessionYearId = sessionyear.SessionYearId " +
                         "inner join timeslot on timetable.TimeslotId = timeslot.TimeslotId; ";
            
            Type[] types =
            {
                 typeof(TimetableModel),
                 typeof(TeacherSubjectModel),
                 typeof(SubjectModel),
                 typeof(SubjectCategoryModel),
                 typeof(TeacherModel),
                 typeof(StaffModel),
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel),
                 typeof(SessionYearModel),
                 typeof(TimeSlotModel)
            };
            Func<object[], TimetableModel> map = delegate (object[] obj)
            {
                TimetableModel timetableModel = obj[0] as TimetableModel;
                TeacherSubjectModel teacherSubjectModel = obj[1] as TeacherSubjectModel;
                SubjectModel subjectModel = obj[2] as SubjectModel;
                SubjectCategoryModel subjectCategoryModel = obj[3] as SubjectCategoryModel;
                TeacherModel teacherModel = obj[4] as TeacherModel;
                StaffModel staffModel = obj[5] as StaffModel;
                ClassModel classModel = obj[6] as ClassModel;
                FormModel formModel = obj[7] as FormModel;
                StreamModel streamModel = obj[8] as StreamModel;
                SessionYearModel sessionYearModel = obj[9] as SessionYearModel;
                TimeSlotModel timeSlotModel = obj[10] as TimeSlotModel;
                
                timetableModel.TeacherSubjects.Add(teacherSubjectModel);
                teacherSubjectModel.Subject = subjectModel;
                teacherSubjectModel.Teacher = teacherModel;
                timetableModel.ClassModel = classModel;
                timetableModel.TimeSlot = timeSlotModel;     
                subjectModel.SubjectCategory = subjectCategoryModel;
                classModel.Form = formModel;
                classModel.Stream = streamModel;
                classModel.SessionYear = sessionYearModel;
                teacherModel.Staff = staffModel;

                return timetableModel;
            };
            string splitOn = "TimeTableId,TeacherSubjectId,Code,SubjectCategoryId,TeacherId,NationalId,ClassId,FormId,StreamId,SessionYearId,TimeslotId";

            var data =  await _dapperContext.MapMultipleObjects<TimetableModel, dynamic>(sql, types, map, splitOn, new { });
            IEnumerable<TimetableModel> results = data.GroupBy(x => x.TimetableId).Select(group =>
            {
                var timetableInstance = group.First();
                timetableInstance.TeacherSubjects = group.Select(tim => tim.TeacherSubjects.Single()).ToList();
                return timetableInstance;
            });
          
            return results.ToList();
        }
        public async Task<List<TimetableModel>> GetTimetableModelsByClass(int classId)
        {
            string sql = "SELECT " +
                            "timetable.TimeTableId, " +
                            "timetable.DayOfTheWeek," +
                            "teacherSubject.TeacherSubjectId," +
                            "subjects.Code," +
                            "subjects.SubjectName," +
                            "subjectcategory.SubjectCategoryId," +
                            "subjectcategory.SubjectCategoryName," +
                            "teacher.TeacherId," +
                            "teacher.TeacherType," +
                            "teacher.TSCNumber," +
                            "staff.NationalId," +
                            "staff.FirstName," +
                            "staff.MiddleName," +
                            "staff.Surname," +
                            "staff.PhoneNumber," +
                            "staff.Gender," +
                            "staff.EmploymentDate," +
                            "staff.Designation," +
                            "staff.DateOfBirth," +
                            "class.ClassId," +
                            "form.FormId," +
                            "form.Form," +
                            "stream.StreamId," +
                            "stream.Stream," +
                            "sessionyear.SessionYearId," +
                            "sessionyear.StartDate," +
                            "sessionyear.EndDate," +
                            "timeslot.TimeslotId," +
                            "timeslot.StartTime," +
                            "timeslot.EndTime," +
                            "timeslot.IsBeforeBreak," +
                            "timeslot.IsAfterBreak " +
                         "FROM timetable " +
                         "INNER JOIN timetableTeacherSubject ON timetableTeacherSubject.TimeTableId = timetable.TimeTableId " +
                         "INNER JOIN teacherSubject ON teacherSubject.TeacherSubjectId = timetableTeacherSubject.TeacherSubjectId " +
                         "INNER JOIN subjects ON subjects.Code = teacherSubject.Code " +
                         "inner join subjectcategory on subjects.SubjectCategoryId = subjectcategory.SubjectCategoryId  " +
                         "INNER JOIN teacher ON teacher.TeacherId = teacherSubject.TeacherId " +
                         "inner join staff on teacher.NationalId = staff.NationalId " +
                         "inner join class on timetable.ClassId = class.ClassId " +
                         "inner join form on class.FormId = form.FormId " +
                         "inner join stream on class.StreamId = stream.StreamId " +
                         "inner join sessionyear on class.SessionYearId = sessionyear.SessionYearId " +
                         "inner join timeslot on timetable.TimeslotId = timeslot.TimeslotId " +
                         "where class.ClassId = @ClassId; ";

            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId);

            Type[] types =
            {
                 typeof(TimetableModel),
                 typeof(TeacherSubjectModel),
                 typeof(SubjectModel),
                 typeof(SubjectCategoryModel),
                 typeof(TeacherModel),
                 typeof(StaffModel),
                 typeof(ClassModel),
                 typeof(FormModel),
                 typeof(StreamModel),
                 typeof(SessionYearModel),
                 typeof(TimeSlotModel)
            };
            Func<object[], TimetableModel> map = delegate (object[] obj)
            {
                TimetableModel timetableModel = obj[0] as TimetableModel;
                TeacherSubjectModel teacherSubjectModel = obj[1] as TeacherSubjectModel;
                SubjectModel subjectModel = obj[2] as SubjectModel;
                SubjectCategoryModel subjectCategoryModel = obj[3] as SubjectCategoryModel;
                TeacherModel teacherModel = obj[4] as TeacherModel;
                StaffModel staffModel = obj[5] as StaffModel;
                ClassModel classModel = obj[6] as ClassModel;
                FormModel formModel = obj[7] as FormModel;
                StreamModel streamModel = obj[8] as StreamModel;
                SessionYearModel sessionYearModel = obj[9] as SessionYearModel;
                TimeSlotModel timeSlotModel = obj[10] as TimeSlotModel;

                timetableModel.TeacherSubjects.Add(teacherSubjectModel);
                teacherSubjectModel.Subject = subjectModel;
                teacherSubjectModel.Teacher = teacherModel;
                timetableModel.ClassModel = classModel;
                timetableModel.TimeSlot = timeSlotModel;
                subjectModel.SubjectCategory = subjectCategoryModel;
                classModel.Form = formModel;
                classModel.Stream = streamModel;
                classModel.SessionYear = sessionYearModel;
                teacherModel.Staff = staffModel;

                return timetableModel;
            };
            string splitOn = "TimeTableId,TeacherSubjectId,Code,SubjectCategoryId,TeacherId,NationalId,ClassId,FormId,StreamId,SessionYearId,TimeslotId";

            var data = await _dapperContext.MapMultipleObjects<TimetableModel, dynamic>(sql, types, map, splitOn, parameters);
            IEnumerable<TimetableModel> results = data.GroupBy(x => x.TimetableId).Select(group =>
            {
                var timetableInstance = group.First();
                timetableInstance.TeacherSubjects = group.Select(tim => tim.TeacherSubjects.Single()).ToList();
                return timetableInstance;
            });

            return results.ToList();
        }
    }
}
