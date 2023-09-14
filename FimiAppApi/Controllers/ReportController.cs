
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
        private List<ClassPerformanceModel> Form1Performance { get; set; } = new List<ClassPerformanceModel>();
        private List<ClassPerformanceModel> Form2Performance { get; set; } = new List<ClassPerformanceModel>();
        private List<ClassPerformanceModel> Form3Performance { get; set; } = new List<ClassPerformanceModel>();
        private List<ClassPerformanceModel> Form4Performance { get; set; } = new List<ClassPerformanceModel>();
        private double F1T1M = 0;
        private double F1T1E = 0;
        private double F1T2M = 0;
        private double F1T2E = 0;
        private double F1T3M = 0;
        private double F1T3E = 0;
        private double F2T1M = 0;
        private double F2T1E = 0;
        private double F2T2M = 0;
        private double F2T2E = 0;
        private double F2T3M = 0;
        private double F2T3E = 0;
        private double F3T1M = 0;
        private double F3T1E = 0;
        private double F3T2M = 0;
        private double F3T2E = 0;
        private double F3T3M = 0;
        private double F3T3E = 0;
        private double F4T1M = 0;
        private double F4T1E = 0;
        private double F4T2M = 0;
        private double F4T2E = 0;
        private double F4T3M = 0;
        private double F4T3E = 0;

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
            var path = $"{this._webHostEnvironment.ContentRootPath}\\Reports\\StudentReportForm.rdlc";

            IEnumerable<GradeModel> Grades = await _gradeRepository.GetAllGrades();

            //-------------------------------------Get the current term-------------------------------------------------------//
            IEnumerable<TermModel> Terms = await _termRepository.GetAllTerms();
            TermModel CurrentTerm = new();
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
            ClassPerformanceModel MidTermPerformance = new();
            ClassPerformanceModel EndTermPerformance = new();
            ClassModel StudentClass = new();
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
            SessionYearModel CurrentSchoolYear = new();
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
            double Mean = @Math.Round((MidTermPerformance.Average + EndTermPerformance.Average) / 2);
            GradeModel MeanGrade = new();
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
            ClassPerformanceModel CurrentStudentTotalPerformance = new();
            IEnumerable<StudentModel> Students = await _studentRepository.MapClassOnStudent(StudentClass.ClassId);
            foreach (var student in Students)
            {
                if (student.StudentNumber == studentNumber) { continue; }
                IEnumerable<ClassPerformanceModel> OtherStudentPerformance = await _subjectPerformanceRepository.GetClassPerformancePerTerm(int.Parse(sessionYearId), CurrentTerm.TermId, StudentClass.ClassId, student.StudentNumber);
                ClassPerformanceModel midTermPerformance = new();
                ClassPerformanceModel endTermPerformance = new();
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

                CurrentStudentTotalPerformance.EnglishPosition = 1;
                CurrentStudentTotalPerformance.KiswhiliPosition = 1;
                CurrentStudentTotalPerformance.MathematicsPosition = 1;
                CurrentStudentTotalPerformance.PhysicsPosition = 1;
                CurrentStudentTotalPerformance.ChemistryPosition = 1;
                CurrentStudentTotalPerformance.BiologyPosition = 1;
                CurrentStudentTotalPerformance.HistoryPosition = 1;
                CurrentStudentTotalPerformance.GeographyPosition = 1;
                CurrentStudentTotalPerformance.ChristianReligionPosition = 1;
                CurrentStudentTotalPerformance.HomesciencePosition = 1;
                CurrentStudentTotalPerformance.AgriculturePosition = 1;
                CurrentStudentTotalPerformance.BusinessPosition = 1;
                CurrentStudentTotalPerformance.ClassPosition = 1;

                if (totalper.English > CurrentStudentTotalPerformance.English)
                {
                    CurrentStudentTotalPerformance.EnglishPosition++;
                }
                if (totalper.Kiswahili > CurrentStudentTotalPerformance.Kiswahili)
                {
                    CurrentStudentTotalPerformance.KiswhiliPosition++;
                }
                if (totalper.Mathematics > CurrentStudentTotalPerformance.Mathematics)
                {
                    CurrentStudentTotalPerformance.MathematicsPosition++;
                }
                if (totalper.Physics > CurrentStudentTotalPerformance.Physics)
                {
                    CurrentStudentTotalPerformance.PhysicsPosition++;
                }
                if (totalper.Chemistry > CurrentStudentTotalPerformance.Chemistry)
                {
                    CurrentStudentTotalPerformance.ChemistryPosition++;
                }
                if (totalper.Biology > CurrentStudentTotalPerformance.Biology)
                {
                    CurrentStudentTotalPerformance.BiologyPosition++;
                }
                if (totalper.HistoryAndGoverment > CurrentStudentTotalPerformance.HistoryAndGoverment)
                {
                    CurrentStudentTotalPerformance.HistoryPosition++;
                }
                if (totalper.Geography > CurrentStudentTotalPerformance.Geography)
                {
                    CurrentStudentTotalPerformance.GeographyPosition++;
                }
                if (totalper.ChristianReligion > CurrentStudentTotalPerformance.ChristianReligion)
                {
                    CurrentStudentTotalPerformance.ChristianReligionPosition++;
                }
                if (totalper.HomeScience > CurrentStudentTotalPerformance.HomeScience)
                {
                    CurrentStudentTotalPerformance.HomesciencePosition++;
                }
                if (totalper.Agriculture > CurrentStudentTotalPerformance.Agriculture)
                {
                    CurrentStudentTotalPerformance.AgriculturePosition++;
                }
                if (totalper.BusinessStudies > CurrentStudentTotalPerformance.BusinessStudies)
                {
                    CurrentStudentTotalPerformance.BusinessPosition++;
                }
                if (totalper.Average > CurrentStudentTotalPerformance.Average)
                {
                    CurrentStudentTotalPerformance.ClassPosition++;
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
            //----------------------------------------Create DtaTables----------------------------------------------------
            Dictionary<int, List<ClassPerformanceModel>> resultsByClass = performanceModels.GroupBy(c => c.ClassId).ToDictionary(g => g.Key, g => g.ToList());
            var keys = resultsByClass.Keys;
            foreach (var key in keys)
            {
                var classPer = await _classRepository.GetClassMultipleMappingById(key);
                if (classPer.Form.Form.Equals("1"))
                {
                    Form1Performance = resultsByClass[key];
                    foreach (var result in Form1Performance)
                    {
                        if (result.TermId == 1 && result.ExamTypeId == 1)
                        {
                            F1T1M = result.Average;
                        }
                        else if (result.TermId == 1 && result.ExamTypeId == 2)
                        {
                            F1T1E = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 1)
                        {
                            F1T1M = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 2)
                        {
                            F1T2E = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 1)
                        {
                            F1T3M = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 2)
                        {
                            F1T3E = result.Average;
                        }
                    }
                }
                else if (classPer.Form.Form.Equals("2"))
                {
                    Form2Performance = resultsByClass[key];
                    foreach (var result in Form2Performance)
                    {
                        if (result.TermId == 1 && result.ExamTypeId == 1)
                        {
                            F2T1M = result.Average;
                        }
                        else if (result.TermId == 1 && result.ExamTypeId == 2)
                        {
                            F2T1E = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 1)
                        {
                            F2T2M = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 2)
                        {
                            F2T2E = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 1)
                        {
                            F2T3M = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 2)
                        {
                            F2T3E = result.Average;
                        }
                    }
                }
                else if (classPer.Form.Form.Equals("3"))
                {
                    Form3Performance = resultsByClass[key];
                    foreach (var result in Form3Performance)
                    {
                        if (result.TermId == 1 && result.ExamTypeId == 1)
                        {
                            F3T1M = result.Average;
                        }
                        else if (result.TermId == 1 && result.ExamTypeId == 2)
                        {
                            F3T1E = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 1)
                        {
                            F3T2M = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 2)
                        {
                            F3T2E = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 1)
                        {
                            F3T3M = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 2)
                        {
                            F3T3E = result.Average;
                        }
                    }
                }
                else if (classPer.Form.Form.Equals("4"))
                {
                    Form4Performance = resultsByClass[key];
                    foreach (var result in Form4Performance)
                    {
                        if (result.TermId == 1 && result.ExamTypeId == 1)
                        {
                            F4T1M = result.Average;
                        }
                        else if (result.TermId == 1 && result.ExamTypeId == 2)
                        {
                            F4T1E = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 1)
                        {
                            F4T2M = result.Average;
                        }
                        else if (result.TermId == 2 && result.ExamTypeId == 2)
                        {
                            F4T2E = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 1)
                        {
                            F4T3M = result.Average;
                        }
                        else if (result.TermId == 3 && result.ExamTypeId == 2)
                        {
                            F4T3E = result.Average;
                        }
                    }
                }
            }

            var allPerformance = new DataTable();
            allPerformance.Columns.Add("Num", typeof(int));
            allPerformance.Columns.Add("ClassAndTerm", typeof(string));
            allPerformance.Columns.Add("MidTerm", typeof(int));
            allPerformance.Columns.Add("EndTerm", typeof(int));
            allPerformance.Rows.Add(1,"F1TI", F1T1M, F1T1E);
            allPerformance.Rows.Add(2,"F1T2", F1T2M, F1T2E);
            allPerformance.Rows.Add(3,"F1T3", F1T3M, F1T3E);
            allPerformance.Rows.Add(4,"F2TI", F2T1M, F2T1E);
            allPerformance.Rows.Add(5,"F2T2", F2T2M, F2T2E);
            allPerformance.Rows.Add(6,"F2T3", F2T3M, F2T3E);
            allPerformance.Rows.Add(7,"F3TI", F3T1M, F3T1E);
            allPerformance.Rows.Add(8,"F3T2", F3T2M, F3T2E);
            allPerformance.Rows.Add(9,"F3T3", F3T3M, F3T3E);
            allPerformance.Rows.Add(10,"F4TI", F4T1M, F4T1E);
            allPerformance.Rows.Add(11,"F4T2", F4T2M, F4T2E);
            allPerformance.Rows.Add(12,"F4T3", F4T3M, F4T3E);

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
            performanceTable.Rows.Add(ClassPerformanceModel.AgricultureName, Math.Round(MidTermPerformance.Agriculture), Math.Round(EndTermPerformance.Agriculture),
                Math.Round(CurrentStudentTotalPerformance.Agriculture), CurrentStudentTotalPerformance.AgricultureGrade.Grade, CurrentStudentTotalPerformance.AgricultureGrade.Points, 
                CurrentStudentTotalPerformance.AgriculturePosition, CurrentStudentTotalPerformance.AgricultureGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.BiologyName, Math.Round(MidTermPerformance.Biology), Math.Round(EndTermPerformance.Biology),
                Math.Round(CurrentStudentTotalPerformance.Biology), CurrentStudentTotalPerformance.BiologyGrade.Grade, CurrentStudentTotalPerformance.BiologyGrade.Points,
                CurrentStudentTotalPerformance.BiologyPosition, CurrentStudentTotalPerformance.BiologyGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.BusinessStudiesName, Math.Round(MidTermPerformance.BusinessStudies), Math.Round(EndTermPerformance.BusinessStudies),
                Math.Round(CurrentStudentTotalPerformance.BusinessStudies), CurrentStudentTotalPerformance.BusinessStudiesGrade.Grade, CurrentStudentTotalPerformance.BusinessStudiesGrade.Points,
                CurrentStudentTotalPerformance.BusinessPosition, CurrentStudentTotalPerformance.BusinessStudiesGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.ChemistryName, Math.Round(MidTermPerformance.Chemistry), Math.Round(EndTermPerformance.Chemistry),
                Math.Round(CurrentStudentTotalPerformance.Chemistry), CurrentStudentTotalPerformance.ChemistryGrade.Grade, CurrentStudentTotalPerformance.ChemistryGrade.Points,
                CurrentStudentTotalPerformance.ChemistryPosition, CurrentStudentTotalPerformance.ChemistryGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.ChristianReligionName, Math.Round(MidTermPerformance.ChristianReligion), Math.Round(EndTermPerformance.ChristianReligion),
                Math.Round(CurrentStudentTotalPerformance.ChristianReligion), CurrentStudentTotalPerformance.ChristianReligionGrade.Grade, CurrentStudentTotalPerformance.ChristianReligionGrade.Points,
                CurrentStudentTotalPerformance.ChristianReligionPosition, CurrentStudentTotalPerformance.ChristianReligionGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.EnglishName, Math.Round(MidTermPerformance.English), Math.Round(EndTermPerformance.English),
                Math.Round(CurrentStudentTotalPerformance.English), CurrentStudentTotalPerformance.EnglishGrade.Grade, CurrentStudentTotalPerformance.EnglishGrade.Points,
                CurrentStudentTotalPerformance.EnglishPosition, CurrentStudentTotalPerformance.EnglishGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.GeographyName, Math.Round(MidTermPerformance.Geography), Math.Round(EndTermPerformance.Geography),
                Math.Round(CurrentStudentTotalPerformance.Geography), CurrentStudentTotalPerformance.GeographyGrade.Grade, CurrentStudentTotalPerformance.GeographyGrade.Points,
                CurrentStudentTotalPerformance.GeographyPosition, CurrentStudentTotalPerformance.GeographyGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.HistoryAndGovermentName, Math.Round(MidTermPerformance.HistoryAndGoverment), Math.Round(EndTermPerformance.HistoryAndGoverment),
                Math.Round(CurrentStudentTotalPerformance.HistoryAndGoverment), CurrentStudentTotalPerformance.HistoryAndGovermentGrade.Grade, CurrentStudentTotalPerformance.HistoryAndGovermentGrade.Points,
                CurrentStudentTotalPerformance.HistoryPosition, CurrentStudentTotalPerformance.HistoryAndGovermentGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.HomeScienceName, Math.Round(MidTermPerformance.HomeScience), Math.Round(EndTermPerformance.HomeScience),
                Math.Round(CurrentStudentTotalPerformance.HomeScience), CurrentStudentTotalPerformance.HomeScienceGrade.Grade, CurrentStudentTotalPerformance.HomeScienceGrade.Points,
                CurrentStudentTotalPerformance.HomesciencePosition, CurrentStudentTotalPerformance.HomeScienceGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.KiswahiliName, Math.Round(MidTermPerformance.Kiswahili), Math.Round(EndTermPerformance.Kiswahili),
                Math.Round(CurrentStudentTotalPerformance.Kiswahili), CurrentStudentTotalPerformance.KiswahiliGrade.Grade, CurrentStudentTotalPerformance.KiswahiliGrade.Points,
                CurrentStudentTotalPerformance.KiswhiliPosition, CurrentStudentTotalPerformance.KiswahiliGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.MathematicsName, Math.Round(MidTermPerformance.Mathematics), Math.Round(EndTermPerformance.Mathematics),
                Math.Round(CurrentStudentTotalPerformance.Mathematics), CurrentStudentTotalPerformance.MathematicsGrade.Grade, CurrentStudentTotalPerformance.MathematicsGrade.Points,
                CurrentStudentTotalPerformance.MathematicsPosition, CurrentStudentTotalPerformance.MathematicsGrade.Remarks);
            performanceTable.Rows.Add(ClassPerformanceModel.PhysicsName, Math.Round(MidTermPerformance.Physics), Math.Round(EndTermPerformance.Physics),
                Math.Round(CurrentStudentTotalPerformance.Physics), CurrentStudentTotalPerformance.PhysicsGrade.Grade, CurrentStudentTotalPerformance.PhysicsGrade.Points,
                CurrentStudentTotalPerformance.PhysicsPosition, CurrentStudentTotalPerformance.PhysicsGrade.Remarks);

            LocalReport localReport = new() 
            {
                ReportPath = path
            };
            localReport.DataSources.Add(new ReportDataSource("StudentReportForm", performanceTable));
            localReport.DataSources.Add(new ReportDataSource("AllPerformance", allPerformance));
            localReport.SetParameters(new[]
            {
                new ReportParameter("prm", "RDLC Report"),
                new ReportParameter("currentSessionYear",CurrentSchoolYear.StartDate.Year.ToString()),
                new ReportParameter("currentTerm", CurrentTerm.TermName),
                new ReportParameter("classPosition", $"{CurrentStudentTotalPerformance.ClassPosition}"),
                new ReportParameter("studentName", $"{performanceModels.First().FirstName} {performanceModels.First().MiddleName} {performanceModels.First().Surname}"),
                new ReportParameter("admNumber", $"{performanceModels.First().StudentNumber}"),
                new ReportParameter("className", $"{StudentClass.Form.Form}{StudentClass.Stream.Stream}"),
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
