﻿namespace FimiAppApi.Repository
{
    public class TeacherSubjectRepository : ITeacherSubjectRepository
    {
        private readonly DapperContext _dapperContext;

        public TeacherSubjectRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<TeacherSubjectModel> GetTeacherSubject(int teacherId, int subjectCode)
        {
            string sql = "SELECT " +
                            "* " +
                         "FROM TeacherSubject " +
                         "WHERE " +
                            "TeacherSubject.TeacherId = @TeacherId AND " +
                            "TeacherSubject.Code = @Code ";
            var parameteres = new DynamicParameters();
            parameteres.Add("TeacherId", teacherId);
            parameteres.Add("Code", subjectCode);
            return await _dapperContext.LoadSingleData<TeacherSubjectModel, dynamic>(sql, parameteres);
        }
        public async Task<int> CreateTeacherSubject(int teacherId, int subjectCode)
        {
            string sql = "INSERT INTO TeacherSubject " +
                                "(TeacherId,Code) " +
                         "VALUES(@TeacherId,@Code)";
            var parameters = new DynamicParameters();
            parameters.Add("TeacherId", teacherId, DbType.Int32);
            parameters.Add("Code", subjectCode, DbType.Int32);

            var id = await _dapperContext.CreateData<TeacherSubjectModel, dynamic>(sql, parameters);
            return id;
        }
        public async Task<int> AddTeacherSubjectWithoutTeacherId(int subjectCode)
        {
            string sql = "DECLARE @stnum INT; " +
                         "SELECT @stnum = MAX(TeacherId) FROM Teacher " +
                         "INSERT INTO TeacherSubject " +
                            "(TeacherId,Code) " +
                         "VALUES    " +
                            "(@stnum,@Code)";
            var parameters = new DynamicParameters();
            parameters.Add("Code", subjectCode, DbType.Int32);

            var id = await _dapperContext.CreateData<TeacherSubjectModel, dynamic>(sql, parameters);
            return id;
        }
        public async Task<IEnumerable<TeacherSubjectModel>> GetSubjectsMultipleMapping()
        {
            string query = "SELECT " +
                                "TeacherSubject.Code, " +
                                "TeacherSubject.TeacherSubjectId, " +
                                "TeacherSubject.TeacherId, " +
                                "Subjects.Code, " +
                                "Subjects.SubjectName, " +
                                "Subjects.SubjectCategoryId, " +
                                "SubjectCategory.SubjectCategoryId, " +
                                "SubjectCategory.SubjectCategoryName, " +
                                "Teacher.TeacherId, " +
                                "Teacher.NationalId, " +
                                "Teacher.TeacherType, " +
                                "Teacher.TSCNumber, " +
                                "Staff.NationalId, " +
                                "Staff.FirstName, " +
                                "Staff.MiddleName, " +
                                "Staff.Surname, " +
                                "Staff.PhoneNumber, " +
                                "Staff.Gender, " +
                                "Staff.EmploymentDate, " +
                                "Staff.Designation " +
                          "FROM TeacherSubject " +
                          "INNER JOIN Subjects ON Subjects.Code = TeacherSubject.Code " +
                          "INNER JOIN SubjectCategory ON Subjects.SubjectCategoryId = SubjectCategory.SubjectCategoryId " +
                          "LEFT JOIN Teacher ON TeacherSubject.TeacherId = Teacher.TeacherId " +
                          "INNER JOIN Staff ON Teacher.NationalId = Staff.NationalId ";
            Type[] types =
            {
                 typeof(TeacherSubjectModel),
                 typeof(SubjectModel),
                 typeof(SubjectCategoryModel),
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], TeacherSubjectModel> map = delegate (object[] obj)
            {
                TeacherSubjectModel teacherSubjectModel = obj[0] as TeacherSubjectModel;
                SubjectModel subject = obj[1] as SubjectModel;
                SubjectCategoryModel subjectCategory = obj[2] as SubjectCategoryModel;
                TeacherModel teacher = obj[3] as TeacherModel;
                StaffModel staff = obj[4] as StaffModel;

                teacherSubjectModel.Subject = subject;
                teacherSubjectModel.Teacher = teacher;
                subject.SubjectCategory = subjectCategory;
                teacher.Staff = staff;

                return teacherSubjectModel;
            };
            string splitOn = "Code,SubjectCategoryId,TeacherId,NationalId";
            return await _dapperContext.MapMultipleObjects<TeacherSubjectModel, dynamic>(query, types, map, splitOn, new { });
        }
        public async Task<IEnumerable<TeacherSubjectModel>> GetSubjectsMultipleMappingByTeacher(int teacherId)
        {
            string query = "SELECT " +
                                "TeacherSubject.Code, " +
                                "TeacherSubject.TeacherSubjectId, " +
                                "TeacherSubject.TeacherId, " +
                                "Subjects.Code, " +
                                "Subjects.SubjectName, " +
                                "Subjects.SubjectCategoryId, " +
                                "SubjectCategory.SubjectCategoryId, " +
                                "SubjectCategory.SubjectCategoryName, " +
                                "Teacher.TeacherId, " +
                                "Teacher.NationalId, " +
                                "Teacher.TeacherType, " +
                                "Teacher.TSCNumber, " +
                                "Staff.NationalId, " +
                                "Staff.FirstName, " +
                                "Staff.MiddleName, " +
                                "Staff.Surname, " +
                                "Staff.PhoneNumber, " +
                                "Staff.Gender, " +
                                "Staff.EmploymentDate, " +
                                "Staff.Designation " +
                          "FROM TeacherSubject " +
                          "INNER JOIN Subjects ON Subjects.Code = TeacherSubject.Code " +
                          "INNER JOIN SubjectCategory ON Subjects.SubjectCategoryId = SubjectCategory.SubjectCategoryId " +
                          "LEFT JOIN Teacher ON TeacherSubject.TeacherId = Teacher.TeacherId " +
                          "INNER JOIN Staff ON Teacher.NationalId = Staff.NationalId " +
                          "WHERE Teacher.TeacherId = @TeacherId ";

            var parameters = new DynamicParameters();
            parameters.Add("TeacherId", teacherId);
            Type[] types =
            {
                 typeof(TeacherSubjectModel),
                 typeof(SubjectModel),
                 typeof(SubjectCategoryModel),
                 typeof(TeacherModel),
                 typeof(StaffModel)
            };
            Func<object[], TeacherSubjectModel> map = delegate (object[] obj)
            {
                TeacherSubjectModel teacherSubjectModel = obj[0] as TeacherSubjectModel;
                SubjectModel subject = obj[1] as SubjectModel;
                SubjectCategoryModel subjectCategory = obj[2] as SubjectCategoryModel;
                TeacherModel teacher = obj[3] as TeacherModel;
                StaffModel staff = obj[4] as StaffModel;

                teacherSubjectModel.Subject = subject;
                teacherSubjectModel.Teacher = teacher;
                subject.SubjectCategory = subjectCategory;
                teacher.Staff = staff;

                return teacherSubjectModel;
            };
            string splitOn = "Code,SubjectCategoryId,TeacherId,NationalId";
            return await _dapperContext.MapMultipleObjects<TeacherSubjectModel, dynamic>(query, types, map, splitOn, parameters);
        }
    }
}