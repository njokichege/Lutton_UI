
namespace FimiAppApi.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IClassPerformanceRepository _subjectPerformanceRepository;
        private readonly ISessionYearRepository _sessionYearRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITermRepository _termRepository;
        private readonly IClassRepository _classRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;

        public ReportController(IClassPerformanceRepository subjectPerformanceRepository, IWebHostEnvironment webHostEnvironment,
            ISessionYearRepository sessionYearRepository, ITermRepository termRepository, IClassRepository classRepository, IGradeRepository gradeRepository,
            IStudentRepository studentRepository)
        {
            _subjectPerformanceRepository = subjectPerformanceRepository;
            _webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _sessionYearRepository = sessionYearRepository;
            _termRepository = termRepository;
            _classRepository = classRepository;
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
        }
        [HttpGet("studentreportform/{studentNumber}/{sessionYearId}/{termId}/{examTypeId}")]
        public async Task<IActionResult> StudentReportCard(int studentNumber, string sessionYearId, string termId, string examTypeId)
        {
            string mimeType = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.ContentRootPath}\\Reports\\StudentReportForm.rdlc";

            IEnumerable<GradeModel> Grades = new List<GradeModel>();
            Grades = await _gradeRepository.GetAllGrades();

            //-------------------------------------Get the current term-------------------------------------------------------//
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
            //-----------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------Get a student's performance-------------------------------------------------------//
            IEnumerable<ClassPerformanceModel> performanceModels = await _subjectPerformanceRepository.GetStudentResults(studentNumber);
            ClassPerformanceModel MidTermPerformance = new ClassPerformanceModel();
            ClassPerformanceModel EndTermPerformance = new ClassPerformanceModel();
            ClassModel StudentClass = new ClassModel();
            foreach (var item in performanceModels)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
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
            //-----------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------Get the current school year-------------------------------------------------------//
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
            //-----------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------Get the current student's Mean and Mean Grade-------------------------------------//
            double Mean = (MidTermPerformance.Average + EndTermPerformance.Average) / 2;
            GradeModel MeanGrade = new GradeModel();
            foreach (GradeModel grade in Grades)
            {
                if (Mean >= grade.EndGrade)
                {
                    MeanGrade = grade;
                    break;
                }
            }
            //------------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------Get the current student's position relative to the class---------------------------//
            ClassPerformanceModel CurrentStudentTotalPerformance = new ClassPerformanceModel();
            IEnumerable<ClassPerformanceModel> OtherStudentPerformance = new List<ClassPerformanceModel>();
            IEnumerable<StudentModel> Students = new List<StudentModel>();
            Students = await _studentRepository.MapClassOnStudent(StudentClass.ClassId);
            foreach (var student in Students)
            {
                if (student.StudentNumber == studentNumber) { continue; }
                OtherStudentPerformance = await _subjectPerformanceRepository.GetClassPerformancePerTerm(int.Parse(sessionYearId), CurrentTerm.TermId, StudentClass.ClassId, student.StudentNumber);
                ClassPerformanceModel midTermPerformance = new ClassPerformanceModel();
                ClassPerformanceModel endTermPerformance = new ClassPerformanceModel();
                foreach (var studentPerformance in OtherStudentPerformance)
                {
                    if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 1 && studentPerformance.SessionYearId == int.Parse(sessionYearId))
                    {
                        midTermPerformance = studentPerformance;
                    }
                    else if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 2 && studentPerformance.SessionYearId == int.Parse(sessionYearId))
                    {
                        endTermPerformance = studentPerformance;
                    }
                }
                CurrentStudentTotalPerformance = await _subjectPerformanceRepository.GetTotalPerformanceAsync(EndTermPerformance, MidTermPerformance);
                ClassPerformanceModel totalper = await _subjectPerformanceRepository.GetTotalPerformanceAsync(endTermPerformance, midTermPerformance);

                CurrentStudentTotalPerformance.englishPosition = 1;
                CurrentStudentTotalPerformance.kiswhiliPosition = 1;
                CurrentStudentTotalPerformance.mathematicsPosition = 1;
                CurrentStudentTotalPerformance.physicsPosition = 1;
                CurrentStudentTotalPerformance.chemistryPosition = 1;
                CurrentStudentTotalPerformance.biologyPosition = 1;
                CurrentStudentTotalPerformance.historyPosition = 1;
                CurrentStudentTotalPerformance.geographyPosition = 1;
                CurrentStudentTotalPerformance.crePosition = 1;
                CurrentStudentTotalPerformance.homesciencePosition = 1;
                CurrentStudentTotalPerformance.agriculturePosition = 1;
                CurrentStudentTotalPerformance.businessPosition = 1;
                CurrentStudentTotalPerformance.classPosition = 1;

                if (totalper.English > CurrentStudentTotalPerformance.English)
                {
                    CurrentStudentTotalPerformance.englishPosition++;
                }
                if (totalper.Kiswahili > CurrentStudentTotalPerformance.Kiswahili)
                {
                    CurrentStudentTotalPerformance.kiswhiliPosition++;
                }
                if (totalper.Mathematics > CurrentStudentTotalPerformance.Mathematics)
                {
                    CurrentStudentTotalPerformance.mathematicsPosition++;
                }
                if (totalper.Physics > CurrentStudentTotalPerformance.Physics)
                {
                    CurrentStudentTotalPerformance.physicsPosition++;
                }
                if (totalper.Chemistry > CurrentStudentTotalPerformance.Chemistry)
                {
                    CurrentStudentTotalPerformance.chemistryPosition++;
                }
                if (totalper.Biology > CurrentStudentTotalPerformance.Biology)
                {
                    CurrentStudentTotalPerformance.biologyPosition++;
                }
                if (totalper.HistoryAndGoverment > CurrentStudentTotalPerformance.HistoryAndGoverment)
                {
                    CurrentStudentTotalPerformance.historyPosition++;
                }
                if (totalper.Geography > CurrentStudentTotalPerformance.Geography)
                {
                    CurrentStudentTotalPerformance.geographyPosition++;
                }
                if (totalper.ChristianReligion > CurrentStudentTotalPerformance.ChristianReligion)
                {
                    CurrentStudentTotalPerformance.crePosition++;
                }
                if (totalper.HomeScience > CurrentStudentTotalPerformance.HomeScience)
                {
                    CurrentStudentTotalPerformance.homesciencePosition++;
                }
                if (totalper.Agriculture > CurrentStudentTotalPerformance.Agriculture)
                {
                    CurrentStudentTotalPerformance.agriculturePosition++;
                }
                if (totalper.BusinessStudies > CurrentStudentTotalPerformance.BusinessStudies)
                {
                    CurrentStudentTotalPerformance.businessPosition++;
                }
                if (totalper.Average > CurrentStudentTotalPerformance.Average)
                {
                    CurrentStudentTotalPerformance.classPosition++;
                }
            }
            //--------------------------------------------------------------------------------------------------------------------------------//

            //----------------------------------------Get Total points----------------------------------------------------
            int TotalPoints = 0;
            if (CurrentStudentTotalPerformance.English != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.EnglishGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Kiswahili != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.KiswahiliGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Mathematics != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.MathematicsGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Physics != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.PhysicsGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Chemistry != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.ChemistryGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Biology != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.BiologyGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.HistoryAndGoverment != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.HistoryAndGovermentGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Geography != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.GeographyGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.ChristianReligion != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.ChristianReligionGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.HomeScience != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.HomeScienceGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.Agriculture != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.AgricultureGrade.Points + TotalPoints;
            }
            if (CurrentStudentTotalPerformance.BusinessStudies != 0)
            {
                TotalPoints = CurrentStudentTotalPerformance.BusinessStudiesGrade.Points + TotalPoints;
            }
            //------------------------------------------------------------------------------------------------------------

            var performanceTable = new DataTable();
            performanceTable.Columns.Add("Subject",typeof(string));
            performanceTable.Columns.Add("MidTerm", typeof(int));
            performanceTable.Columns.Add("EndTerm", typeof(int));
            performanceTable.Columns.Add("Total", typeof(int));
            performanceTable.Columns.Add("Grade", typeof(string));
            performanceTable.Columns.Add("Points", typeof(int));
            performanceTable.Columns.Add("Position", typeof(int));
            performanceTable.Columns.Add("Remarks", typeof(string));
            performanceTable.Columns.Add("Initials", typeof(string));
            performanceTable.Rows.Add(CurrentStudentTotalPerformance.AgricultureName, Math.Round(MidTermPerformance.Agriculture), Math.Round(EndTermPerformance.Agriculture), 
                Math.Round(CurrentStudentTotalPerformance.Agriculture), CurrentStudentTotalPerformance.AgricultureGrade.Grade, CurrentStudentTotalPerformance.AgricultureGrade.Points, 
                CurrentStudentTotalPerformance.agriculturePosition, CurrentStudentTotalPerformance.AgricultureGrade.Remarks);
            performanceTable.Rows.Add(CurrentStudentTotalPerformance.EnglishName, Math.Round(MidTermPerformance.English), Math.Round(EndTermPerformance.English),
                Math.Round(CurrentStudentTotalPerformance.English), CurrentStudentTotalPerformance.EnglishGrade.Grade, CurrentStudentTotalPerformance.EnglishGrade.Points,
                CurrentStudentTotalPerformance.englishPosition, CurrentStudentTotalPerformance.EnglishGrade.Remarks);

            string classPosition = $"{CurrentStudentTotalPerformance.classPosition}";
            string studentName = $"{performanceModels.First().FirstName} {performanceModels.First().MiddleName} {performanceModels.First().Surname}";
            string admNumber = $"{performanceModels.First().StudentNumber}";
            string className = $"{StudentClass.Form.Form}{StudentClass.Stream.Stream}";

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = path;
            localReport.DataSources.Add(new ReportDataSource("StudentReportForm", performanceTable));
            localReport.SetParameters(new[]
            {
                new ReportParameter("prm", "RDLC Report"),
                new ReportParameter("currentSessionYear",CurrentSchoolYear.StartDate.Year.ToString()),
                new ReportParameter("currentTerm", CurrentTerm.TermName),
                new ReportParameter("studentName", studentName),
                new ReportParameter("admNumber", admNumber),
                new ReportParameter("className", className),
                new ReportParameter("mean",Mean.ToString()),
                new ReportParameter("meanGrade", MeanGrade.Grade),
                new ReportParameter("midtermEnglish", MidTermPerformance.English.ToString()),
                new ReportParameter("midtermPhysics", MidTermPerformance.Physics.ToString()),
            });
            byte[] pdf = localReport.Render("PDF");

            return File(pdf, "application/pdf");
        }
    }
}
