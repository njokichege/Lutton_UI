using Microsoft.JSInterop;
using MudBlazor;
using static MudBlazor.Colors;
using static MudBlazor.Defaults;
using Microsoft.AspNetCore.Components.RenderTree;

namespace FimiAppUI.Pages
{
    public class ReportFormBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] IClassPerformanceService ClassPerformanceService { get; set; }
        [Inject] ISessionYearService SessionYearService { get; set; }
        [Inject] IClassService ClassService { get; set; }
        [Inject] IGradeService GradeService { get; set; }
        [Inject] ITermService TermService { get; set; }
        [Inject] IStudentService StudentService { get; set; }
        [Parameter] public string StudentNumber { get; set; }
        [Parameter] public string SessionYearId { get; set; }
        [Parameter] public string ExamTypeId { get; set; }
        [Parameter] public string TermId { get; set; }
        public IEnumerable<ClassPerformanceModel> StudentPerformance { get; set; } = new List<ClassPerformanceModel>();
        public IEnumerable<ClassPerformanceModel> OtherStudentPerformance{ get; set; } = new List<ClassPerformanceModel>();
        public IEnumerable<SessionYearModel> SessionYears { get; set; } = new List<SessionYearModel>();
        public IEnumerable<StudentModel> Students { get; set; } = new List<StudentModel>();
        public IEnumerable<GradeModel> Grades { get; set; } =  new List<GradeModel>();
        public IEnumerable<TermModel> Terms { get; set; } = new List<TermModel>();
        public TermModel CurrentTerm { get; set; } = new TermModel();
        public ClassModel StudentClass { get; set; } = new ClassModel();
        public SessionYearModel CurrentSchoolYear { get; set; } = new SessionYearModel();
        public List<ClassPerformanceModel> Form1Performance { get; set; } = new List<ClassPerformanceModel>();
        public List<ClassPerformanceModel> Form2Performance { get; set; } = new List<ClassPerformanceModel>();
        public List<ClassPerformanceModel> Form3Performance { get; set; } = new List<ClassPerformanceModel>();
        public List<ClassPerformanceModel> Form4Performance { get; set; } = new List<ClassPerformanceModel>();
        public List<ChartSeries> Series { get; set; } = new List<ChartSeries>();
        public ClassPerformanceModel MidTermPerformance { get; set; } = new ClassPerformanceModel();
        public ClassPerformanceModel EndTermPerformance { get; set; } = new ClassPerformanceModel();
        public ClassPerformanceModel CurrentStudentTotalPerformance { get; set; } = new ClassPerformanceModel();
        public string[] XAxisLabels = { "F1T1", "F1T2", "F1T3", "F2T1", "F2T2", "F2T3", "F3T1", "F3T2", "F3T3", "F4T1", "F4T2", "F4T3" };
        public GradeModel MeanGrade { get; set; } = new GradeModel();
        public double Form4Average = 0;
        public bool dataIsLoaded = false;
        public double Mean;
        public int TotalPoints;
        public int Index = -1;
        public double F1T1M = 0;
        public double F1T1E = 0;
        public double F1T2M = 0;
        public double F1T2E = 0;
        public double F1T3M = 0;
        public double F1T3E = 0;
        public double F2T1M = 0;
        public double F2T1E = 0;
        public double F2T2M = 0;
        public double F2T2E = 0;
        public double F2T3M = 0;
        public double F2T3E = 0;
        public double F3T1M = 0;
        public double F3T1E = 0;
        public double F3T2M = 0;
        public double F3T2E = 0;
        public double F3T3M = 0;
        public double F3T3E = 0;
        public double F4T1M = 0;
        public double F4T1E = 0;
        public double F4T2M = 0;
        public double F4T2E = 0;
        public double F4T3M = 0;
        public double F4T3E = 0;
        protected override async Task OnInitializedAsync()
        {
            StudentPerformance = await ClassPerformanceService.GetStudentResults(int.Parse(StudentNumber));

            Dictionary<int,List<ClassPerformanceModel>> resultsByClass = StudentPerformance.GroupBy(c => c.ClassId).ToDictionary(g => g.Key, g=>g.ToList());
            var keys = resultsByClass.Keys;
            foreach ( var key in keys)
            {
                var classPer = await ClassService.GetClassById(key);
                if(classPer.Form.Form.Equals("1"))
                {
                    Form1Performance = resultsByClass[key];
                    foreach (var result in Form1Performance)
                    {
                        if(result.TermId == 1 && result.ExamTypeId == 1)
                        {
                            F1T1M = result.Average;
                        }
                        else if(result.TermId == 1 && result.ExamTypeId == 2)
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

            Series = new List<ChartSeries>() 
            { 
                new ChartSeries() { Name = "MidTerm", Data = new double[] { F1T1M,F1T2M,F1T3M,F2T1M,F2T2M,F2T3M,F3T1M,F3T2M,F3T3M,F4T1M,F4T2M,F4T3M} },
                new ChartSeries() { Name = "EndTerm", Data = new double[] { F1T1E,F1T2E,F1T3E,F2T1E,F2T2E,F2T3E,F3T1E,F3T2E,F3T3E,F4T1E,F4T2E,F4T3E} }
            };

            Terms = await TermService.GetAllTerms();
            foreach (var term in Terms)
            {
                if (term.TermId == int.Parse(TermId))
                {
                    CurrentTerm = term;
                    break;
                }
            }
            SessionYears = await SessionYearService.GetSessionYears();
            foreach (var sessionYear in SessionYears)
            {
                if (sessionYear.SessionYearId == int.Parse(SessionYearId))
                {
                    CurrentSchoolYear = sessionYear;
                    break;
                }
            }
            Grades = await GradeService.GetAllGrades();
            foreach (var studentPerformance in StudentPerformance)
            {
                foreach (GradeModel grade in Grades)
                {
                    if (studentPerformance.Average >= grade.EndGrade)
                    {
                        studentPerformance.TotalGrade = grade;
                        break;
                    }
                }
                if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 1 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                {
                    MidTermPerformance = studentPerformance;
                    StudentClass = await ClassService.GetClassById(studentPerformance.ClassId);
                }
                else if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 2 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                {
                    EndTermPerformance = studentPerformance;
                }
            }

            //----------------------------------------Get the current student's total performance per term--------------------------------------------------------

            CurrentStudentTotalPerformance = GetTotalPerformance(EndTermPerformance, MidTermPerformance);

            //----------------------------------------------------------------------------------------------------------------------------------------------------

            //----------------------------------------Get the current student's position relative to the class----------------------------------------------------

            Students = await StudentService.MapClassOnStudent(StudentClass.ClassId);
            foreach (var student in Students)
            {
                if (student.StudentNumber == int.Parse(StudentNumber)) { continue; }
                OtherStudentPerformance = await ClassPerformanceService.GetClassPerformancePerTerm(int.Parse(SessionYearId), CurrentTerm.TermId, StudentClass.ClassId, student.StudentNumber);
                ClassPerformanceModel midTermPerformance = new ClassPerformanceModel();
                ClassPerformanceModel endTermPerformance = new ClassPerformanceModel();
                foreach (var studentPerformance in OtherStudentPerformance)
                {
                    if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 1 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                    {
                        midTermPerformance = studentPerformance;
                    }
                    else if (studentPerformance.TermId == CurrentTerm.TermId && studentPerformance.ExamTypeId == 2 && studentPerformance.SessionYearId == int.Parse(SessionYearId))
                    {
                        endTermPerformance = studentPerformance;
                    }
                }
                ClassPerformanceModel totalper = GetTotalPerformance(endTermPerformance, midTermPerformance);

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
                if(totalper.Average > CurrentStudentTotalPerformance.Average)
                {
                    CurrentStudentTotalPerformance.classPosition++;
                }
            }
            //------------------------------------------------------------------------------------------------------------
            //----------------------------------------Get Total points----------------------------------------------------
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

            Mean = (MidTermPerformance.Average + EndTermPerformance.Average)/ 2;
            foreach (GradeModel grade in Grades)
            {
                if (Mean >= grade.EndGrade)
                {
                   MeanGrade = grade;
                    break;
                }
            }

            //----------------------------------------Load report---------------------------------------------------------
            
            dataIsLoaded = true;
            StateHasChanged();
            //------------------------------------------------------------------------------------------------------------
        }
        private ClassPerformanceModel GetTotalPerformance(ClassPerformanceModel EndTermPerformance, ClassPerformanceModel MidTermPerformance)
        {
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
