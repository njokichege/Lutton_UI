using System.Reflection.Metadata;

namespace FimiAppApi.Repository
{
    public class ClassPerformanceRepository : IClassPerformanceRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly IGradeRepository _gradeRepository;

        public ClassPerformanceRepository(DapperContext dapperContext, IGradeRepository gradeRepository)
        {
            _dapperContext = dapperContext;
            _gradeRepository = gradeRepository;
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetClassPerformancePerTerm(int sessionId,int termId,int classId,int studentNumber)
        {
            string sql = "SELECT * from StudentResults WHERE SessionYearId = @SessionYearId AND TermId = @TermId AND ClassId = @ClassId AND StudentNumber = @StudentNumber";

            var parameters = new DynamicParameters();
            parameters.Add("SessionYearId", sessionId);
            parameters.Add("TermId", termId);
            parameters.Add("ClassId", classId);
            parameters.Add("StudentNumber", studentNumber);

            var studentPerformances = await _dapperContext.LoadData<ClassPerformanceModel, dynamic>(sql, parameters);
            foreach (var studentPerformance in studentPerformances)
            {
                int subjectCount = 0;
                double studentTotal = 0;
                if (studentPerformance.English != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.English; }
                if (studentPerformance.Kiswahili != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Kiswahili; }
                if (studentPerformance.Mathematics != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Mathematics; }
                if (studentPerformance.Agriculture != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Agriculture; }
                if (studentPerformance.Biology != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Biology; }
                if (studentPerformance.BusinessStudies != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.BusinessStudies; }
                if (studentPerformance.Chemistry != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Chemistry; }
                if (studentPerformance.HomeScience != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.HomeScience; }
                if (studentPerformance.ChristianReligion != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.ChristianReligion; }
                if (studentPerformance.Geography != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Geography; }
                if (studentPerformance.HistoryAndGoverment != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.HistoryAndGoverment; }
                if (studentPerformance.Physics != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Physics; }

                studentPerformance.Average = studentTotal / subjectCount;
            }
            return studentPerformances;
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResults(int studentNumber)
        {
            string sql = "SELECT * from StudentResults WHERE StudentNumber = @StudentNumber";
            
            var parameteres = new DynamicParameters();
            parameteres.Add("StudentNumber", studentNumber);

            var studentPerformances = await _dapperContext.LoadData<ClassPerformanceModel, dynamic>(sql, parameteres);
            foreach (var studentPerformance in studentPerformances)
            {
                int subjectCount = 0;
                double studentTotal = 0;
                if (studentPerformance.English != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.English; }
                if (studentPerformance.Kiswahili != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Kiswahili; }
                if (studentPerformance.Mathematics != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Mathematics; }
                if (studentPerformance.Agriculture != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Agriculture; }
                if (studentPerformance.Biology != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Biology; }
                if (studentPerformance.BusinessStudies != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.BusinessStudies; }
                if (studentPerformance.Chemistry != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Chemistry; }
                if (studentPerformance.HomeScience != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.HomeScience; }
                if (studentPerformance.ChristianReligion != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.ChristianReligion; }
                if (studentPerformance.Geography != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Geography; }
                if (studentPerformance.HistoryAndGoverment != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.HistoryAndGoverment; }
                if (studentPerformance.Physics != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Physics; }

                studentPerformance.Average = studentTotal / subjectCount;
            }

            return studentPerformances;
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId)
        {
            string sql = "SELECT * FROM StudentResults WHERE SessionYearId = @SessionYearId AND TermId = @TermId AND ExamTypeId = @ExamTypeId AND ClassId = @ClassId";

            var parameters = new DynamicParameters();
            parameters.Add("ClassId",classId);
            parameters.Add("SessionYearId", sessionYearId);
            parameters.Add("TermId", termId);
            parameters.Add("ExamTypeId", examTypeId);

            var studentPerformances =  await _dapperContext.LoadData<ClassPerformanceModel, dynamic>(sql, parameters);
            foreach (var studentPerformance in studentPerformances)
            {
                int subjectCount = 0;
                double studentTotal = 0;
                if (studentPerformance.English != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.English; }
                if(studentPerformance.Kiswahili != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Kiswahili; }
                if(studentPerformance.Mathematics != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Mathematics; }
                if(studentPerformance.Agriculture != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Agriculture; }
                if(studentPerformance.Biology != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Biology; }
                if(studentPerformance.BusinessStudies != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.BusinessStudies; }
                if(studentPerformance.Chemistry != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Chemistry; }
                if(studentPerformance.HomeScience != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.HomeScience; }
                if(studentPerformance.ChristianReligion != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.ChristianReligion; }
                if(studentPerformance.Geography != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Geography; }
                if(studentPerformance.HistoryAndGoverment != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.HistoryAndGoverment; }
                if(studentPerformance.Physics != 0) { subjectCount++; studentTotal = studentTotal + studentPerformance.Physics; }

                studentPerformance.Average = studentTotal / subjectCount;
            }
            return studentPerformances;
        }
        public async Task UpdateStudentResults(ClassPerformanceModel classPerformanceModel)
        {
            string sql = "UPDATE StudentResults " +
                         "SET " +
                            "English = @English," +
                            "Kiswahili = @Kiswahili," +
                            "Mathematics = @Mathematics," +
                            "Physics = @Physics," +
                            "Chemistry = @Chemistry," +
                            "Biology = @Biology," +
                            "HistoryandGovernment = @HistoryandGovernment," +
                            "Geography = @Geography," +
                            "ChristianReligion = @ChristianReligion," +
                            "HomeScience = @HomeScience," +
                            "Agriculture = @Agriculture," +
                            "BusinessStudies = @BusinessStudies " +
                         "WHERE " +
                            "SessionYearId = @SessionYearId AND " +
                            "ClassId = @ClassId AND " +
                            "TermId = @TermId AND " +
                            "ExamTypeId = @ExamTypeId AND " +
                            "StudentNumber = @StudentNumber";
            var parameters = new DynamicParameters();
            parameters.Add("English", classPerformanceModel.English);
            parameters.Add("Kiswahili", classPerformanceModel.Kiswahili);
            parameters.Add("Mathematics", classPerformanceModel.Mathematics);
            parameters.Add("Physics", classPerformanceModel.Physics);
            parameters.Add("Chemistry", classPerformanceModel.Chemistry);
            parameters.Add("Biology", classPerformanceModel.Biology);
            parameters.Add("HistoryandGovernment", classPerformanceModel.HistoryAndGoverment);
            parameters.Add("Geography", classPerformanceModel.Geography);
            parameters.Add("ChristianReligion", classPerformanceModel.ChristianReligion);
            parameters.Add("HomeScience", classPerformanceModel.HomeScience);
            parameters.Add("Agriculture", classPerformanceModel.Agriculture);
            parameters.Add("BusinessStudies", classPerformanceModel.BusinessStudies);
            parameters.Add("SessionYearId", classPerformanceModel.SessionYearId);
            parameters.Add("ClassId", classPerformanceModel.ClassId);
            parameters.Add("TermId", classPerformanceModel.TermId);
            parameters.Add("ExamTypeId", classPerformanceModel.ExamTypeId);
            parameters.Add("StudentNumber", classPerformanceModel.StudentNumber);

            await _dapperContext.UpdateData<ClassPerformanceModel, dynamic>(sql, parameters);
        }
        public async Task<ClassPerformanceModel> GetTotalPerformanceAsync(ClassPerformanceModel EndTermPerformance, ClassPerformanceModel MidTermPerformance)
        {
            IEnumerable<GradeModel> Grades = new List<GradeModel>();
            Grades = await _gradeRepository.GetAllGrades();
            ClassPerformanceModel TotalPerformance = new ClassPerformanceModel();
            TotalPerformance.Average = (MidTermPerformance.Average + EndTermPerformance.Average) / 2;
            TotalPerformance.English = (MidTermPerformance.English + EndTermPerformance.English) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.English >= grade.EndGrade)
                {
                    TotalPerformance.EnglishGrade = grade;
                    break;
                }
            }
            TotalPerformance.Kiswahili = (MidTermPerformance.Kiswahili + EndTermPerformance.Kiswahili) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Kiswahili >= grade.EndGrade)
                {
                    TotalPerformance.KiswahiliGrade = grade;
                    break;
                }
            }
            TotalPerformance.Mathematics = (MidTermPerformance.Mathematics + EndTermPerformance.Mathematics) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Mathematics >= grade.EndGrade)
                {
                    TotalPerformance.MathematicsGrade = grade;
                    break;
                }
            }
            TotalPerformance.Physics = (MidTermPerformance.Physics + EndTermPerformance.Physics) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Physics >= grade.EndGrade)
                {
                    TotalPerformance.PhysicsGrade = grade;
                    break;
                }
            }
            TotalPerformance.Chemistry = (MidTermPerformance.Chemistry + EndTermPerformance.Chemistry) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Chemistry >= grade.EndGrade)
                {
                    TotalPerformance.ChemistryGrade = grade;
                    break;
                }
            }
            TotalPerformance.Biology = (MidTermPerformance.Biology + EndTermPerformance.Biology) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Biology >= grade.EndGrade)
                {
                    TotalPerformance.BiologyGrade = grade;
                    break;
                }
            }
            TotalPerformance.HistoryAndGoverment = (MidTermPerformance.HistoryAndGoverment + EndTermPerformance.HistoryAndGoverment) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.HistoryAndGoverment >= grade.EndGrade)
                {
                    TotalPerformance.HistoryAndGovermentGrade = grade;
                    break;
                }
            }
            TotalPerformance.Geography = (MidTermPerformance.Geography + EndTermPerformance.Geography) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Geography >= grade.EndGrade)
                {
                    TotalPerformance.GeographyGrade = grade;
                    break;
                }
            }
            TotalPerformance.ChristianReligion = (MidTermPerformance.ChristianReligion + EndTermPerformance.ChristianReligion) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.ChristianReligion >= grade.EndGrade)
                {
                    TotalPerformance.ChristianReligionGrade = grade;
                    break;
                }
            }
            TotalPerformance.HomeScience = (MidTermPerformance.HomeScience + EndTermPerformance.HomeScience) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.HomeScience >= grade.EndGrade)
                {
                    TotalPerformance.HomeScienceGrade = grade;
                    break;
                }
            }
            TotalPerformance.Agriculture = (MidTermPerformance.Agriculture + EndTermPerformance.Agriculture) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.Agriculture >= grade.EndGrade)
                {
                    TotalPerformance.AgricultureGrade = grade;
                    break;
                }
            }
            TotalPerformance.BusinessStudies = (MidTermPerformance.BusinessStudies + EndTermPerformance.BusinessStudies) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (TotalPerformance.BusinessStudies >= grade.EndGrade)
                {
                    TotalPerformance.BusinessStudiesGrade = grade;
                    break;
                }
            }
            return TotalPerformance;
        }
    }
}
