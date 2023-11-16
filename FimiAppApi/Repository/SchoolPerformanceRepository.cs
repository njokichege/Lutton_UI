namespace FimiAppApi.Repository
{
    public class SchoolPerformanceRepository : ISchoolPerformanceRepository
    {
        private readonly DapperContext _dapperContext;

        public SchoolPerformanceRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<IEnumerable<SchoolPerformanceModel>> GetSchoolPerformances(int sessionYearId, int termId,int examTypeId)
        {
            string sql = "SELECT ClassId,TermId, ExamTypeId, AVG(Marks) AS ClassAverage from StudentPerformance WHERE SessionYearId = @SessionYearId AND TermId = @TermId AND ExamTypeId = @ExamTypeId GROUP BY ClassId,TermId, ExamTypeId";

            var parameters = new DynamicParameters();
            parameters.Add("SessionYearId", sessionYearId);
            parameters.Add("TermId", termId);
            parameters.Add("ExamTypeId", examTypeId);

            var data = await _dapperContext.LoadData<SchoolPerformanceModel, dynamic>(sql, parameters);

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
        public async Task<IEnumerable<SchoolPerformanceModel>> GetSchoolPerformance(int sessionYearId, int termId, int examTypeId)
        {
            string sql = "SELECT * FROM StudentResults WHERE SessionYearId = @SessionYearId AND TermId = @TermId AND ExamTypeId = @ExamTypeId";

            var parameters = new DynamicParameters();
            parameters.Add("SessionYearId", sessionYearId);
            parameters.Add("TermId", termId);
            parameters.Add("ExamTypeId", examTypeId);

            var studentPerformances = await _dapperContext.LoadData<ClassPerformanceModel, dynamic>(sql, parameters);
            foreach (var studentPerformance in studentPerformances)
            {
                int subjectCount = 0;
                if (studentPerformance.English != 0) { subjectCount++; }
                if (studentPerformance.Kiswahili != 0) { subjectCount++; }
                if (studentPerformance.Mathematics != 0) { subjectCount++; }
                if (studentPerformance.Agriculture != 0) { subjectCount++; }
                if (studentPerformance.Biology != 0) { subjectCount++; }
                if (studentPerformance.BusinessStudies != 0) { subjectCount++; }
                if (studentPerformance.Chemistry != 0) { subjectCount++; }
                if (studentPerformance.HomeScience != 0) { subjectCount++; }
                if (studentPerformance.ChristianReligion != 0) { subjectCount++; }
                if (studentPerformance.Geography != 0) { subjectCount++; }
                if (studentPerformance.HistoryAndGoverment != 0) { subjectCount++; }
                if (studentPerformance.Physics != 0) { subjectCount++; }

                studentPerformance.Average = studentPerformance.Total / subjectCount;
            }
            IEnumerable<SchoolPerformanceModel> schoolPerformances = new List<SchoolPerformanceModel>();
            var data = schoolPerformances;

            int index = 0;
            foreach (var item in data)
            {
                index++;
                item.Index = index;
            }
            return data;
        }
    }
}
