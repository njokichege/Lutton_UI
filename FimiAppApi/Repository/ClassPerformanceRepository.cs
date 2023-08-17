namespace FimiAppApi.Repository
{
    public class ClassPerformanceRepository : IClassPerformanceRepository
    {
        private readonly DapperContext _dapperContext;

        public ClassPerformanceRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId)
        {
            string sql = "SELECT * FROM StudentResults WHERE SessionYearId = @SessionYearId AND TermId = @TermId AND ExamTypeId = @ExamTypeId AND ClassId = @ClassId";

            var parameters = new DynamicParameters();
            parameters.Add("ClassId", classId);
            parameters.Add("SessionYearId", sessionYearId);
            parameters.Add("TermId", termId);
            parameters.Add("ExamTypeId", examTypeId);

            var studentPerformances =  await _dapperContext.LoadData<ClassPerformanceModel, dynamic>(sql, parameters);
            foreach (var studentPerformance in studentPerformances)
            {
                int subjectCount = 0;
                if (studentPerformance.English != 0) { subjectCount++; }
                if(studentPerformance.Kiswahili != 0) { subjectCount++; }
                if(studentPerformance.Mathematics != 0) { subjectCount++; }
                if(studentPerformance.Agriculture != 0) { subjectCount++; }
                if(studentPerformance.Biology != 0) { subjectCount++; }
                if(studentPerformance.BusinessStudies != 0) { subjectCount++; }
                if(studentPerformance.Chemistry != 0) { subjectCount++; }
                if(studentPerformance.HomeScience != 0) { subjectCount++; }
                if(studentPerformance.ChristianReligion != 0) { subjectCount++; }
                if(studentPerformance.Geography != 0) { subjectCount++; }
                if(studentPerformance.HistoryAndGoverment != 0) { subjectCount++; }
                if(studentPerformance.Physics != 0) { subjectCount++; }

                studentPerformance.Average = studentPerformance.Total / subjectCount;
            }
            return studentPerformances;
        }
        public async Task<IEnumerable<ClassPerformanceModel>> GetStudentResultsByClassAndSubject(int classId, int sessionYearId, int termId, int examTypeId, string subjectName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("SelectedSubject", subjectName);
            parameters.Add("SessionYearId", sessionYearId);
            parameters.Add("TermId", termId);
            parameters.Add("ExamTypeId", examTypeId);
            parameters.Add("ClassId", classId);
            
            return await _dapperContext.LoadDataStoredProcedure<ClassPerformanceModel, dynamic>("SingleSubjectResult", parameters);
        }
    }
}
