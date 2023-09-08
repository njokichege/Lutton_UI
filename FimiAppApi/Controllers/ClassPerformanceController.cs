using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using FimiAppApi.ReportDataSet;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace FimiAppApi.Controllers
{
    [Route("api/classsubjectperformance")]
    [ApiController]
    public class ClassPerformanceController : ControllerBase
    {
        private readonly IClassPerformanceRepository _subjectPerformanceRepository;
        private readonly ISessionYearRepository _sessionYearRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITermRepository _termRepository;
        private readonly IClassRepository _classRepository;
        private readonly IGradeRepository _gradeRepository;

        public ClassPerformanceController(IClassPerformanceRepository subjectPerformanceRepository, IWebHostEnvironment webHostEnvironment, 
            ISessionYearRepository sessionYearRepository, ITermRepository termRepository, IClassRepository classRepository, IGradeRepository gradeRepository)
        {
            _subjectPerformanceRepository = subjectPerformanceRepository;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _sessionYearRepository = sessionYearRepository;
            _termRepository = termRepository;
            _classRepository = classRepository;
            _gradeRepository = gradeRepository;
        }
        [HttpGet("classresult/{sessionId}/{termId}/{classId}/{studentNumber}")]
        public async Task<IActionResult> GetClassPerformancePerTerm(int sessionId, int termId, int classId, int studentNumber)
        {
            try
            {
                var classResult = await _subjectPerformanceRepository.GetClassPerformancePerTerm(sessionId, termId, classId,studentNumber);
                return Ok(classResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("studentresult/{studentNumber}")]
        public async Task<IActionResult> GetStudentResults(int studentNumber)
        {
            try
            {
                var studentResult = await _subjectPerformanceRepository.GetStudentResults(studentNumber);
                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{classId}/{sessionYearId}/{termId}/{examTypeId}")]
        public async Task<IActionResult> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId)
        {
            try
            {
                var examResult = await _subjectPerformanceRepository.GetStudentResultsByClass(classId,sessionYearId,termId,examTypeId);
                return Ok(examResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("studentresults")]
        public async Task<IActionResult> UpdateStudentResults(ClassPerformanceModel classPerformanceModel)
        {
            try
            {
                await _subjectPerformanceRepository.UpdateStudentResults(classPerformanceModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("printstudentreportform/{studentNumber}/{sessionYearId}/{termId}/{examTypeId}")]
        public async Task<IActionResult> PrintAsync(int studentNumber,string sessionYearId, string termId, string examTypeId)
        {
            IEnumerable<ClassPerformanceModel> performanceModels =  await _subjectPerformanceRepository.GetStudentResults(studentNumber);
            ClassModel StudentClass = new ClassModel();
            ClassPerformanceModel MidTermPerformance = new ClassPerformanceModel();
            ClassPerformanceModel EndTermPerformance = new ClassPerformanceModel();
            IEnumerable<GradeModel> Grades = new List<GradeModel>();
            GradeModel MeanGrade = new GradeModel();

            Grades = await _gradeRepository.GetAllGrades();

            IEnumerable<TermModel> Terms = await _termRepository.GetAllTerms();
            TermModel CurrentTerm = new TermModel();
            foreach (var term in Terms)
            {
                if (term.TermId == int.Parse(termId))
                {
                    CurrentTerm = term;
                    break;
                }
            }
            var dt = new DataTable();
            PropertyInfo[] props = typeof(ClassPerformanceModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (var item in performanceModels)
            {
                var values = new object[props.Length];
                for(var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
                if (item.TermId == CurrentTerm.TermId && item.ExamTypeId == int.Parse(examTypeId) && item.SessionYearId == int.Parse(sessionYearId))
                {
                    StudentClass = await _classRepository.GetClassMultipleMappingById(item.ClassId);
                }
                if (item.TermId == CurrentTerm.TermId && item.ExamTypeId == 1 && item.SessionYearId == int.Parse(sessionYearId))
                {
                    MidTermPerformance = item;
                }
                if (item.TermId == CurrentTerm.TermId && item.ExamTypeId == 2 && item.SessionYearId == int.Parse(sessionYearId))
                {
                    EndTermPerformance = item;
                }
            }

            string mimeType = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.ContentRootPath}\\Reports\\StudentReportForm.rdlc";

            IEnumerable<SessionYearModel> SessionYears = await _sessionYearRepository.GetSessionYears();
            SessionYearModel CurrentSchoolYear = new SessionYearModel();
            foreach (var sessionYear in SessionYears)
            {
                if (sessionYear.SessionYearId == int.Parse(sessionYearId))
                {
                    CurrentSchoolYear = sessionYear;
                    break;
                }
            }

            double Mean = (MidTermPerformance.Average + EndTermPerformance.Average) / 2;
            foreach (GradeModel grade in Grades)
            {
                if (Mean >= grade.EndGrade)
                {
                    MeanGrade = grade;
                    break;
                }
            }

            string studentName = $"{performanceModels.First().FirstName} {performanceModels.First().MiddleName} {performanceModels.First().Surname}";
            string admNumber = $"{performanceModels.First().StudentNumber}";
            string className = $"{StudentClass.Form.Form}{StudentClass.Stream.Stream}";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "RDLC Report");
            parameters.Add("currentSessionYear",CurrentSchoolYear.StartDate.Year.ToString());
            parameters.Add("currentTerm", CurrentTerm.TermName);
            parameters.Add("studentName", studentName);
            parameters.Add("admNumber", admNumber);
            parameters.Add("className", className);
            parameters.Add("mean",Mean.ToString());
            parameters.Add("meanGrade", MeanGrade.Grade);

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("StudentReportForm", dt);

            var result = localReport.Execute(RenderType.Pdf,extension,parameters,mimeType);

            return File(result.MainStream, "application/pdf");
        }
    }
}
