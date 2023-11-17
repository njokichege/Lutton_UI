using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ManageSubjectsBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public ISubjectService SubjectService { get; set; }
        [Inject] public ISubjectCategoryService SubjectCategoryService { get; set; }
        [Inject] public ITeacherSubjectService TeacherSubjectService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public IStudentSubjectService StudentSubjectService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        public IEnumerable<TeacherSubjectModel> TeacherSubjectModel { get; set; }
        public IEnumerable<TeacherSubjectModel> TeacherSubjects { get; set; } = new List<TeacherSubjectModel>();
        public IEnumerable<SubjectModel> SubjectsWithCategories { get; set; } = new List<SubjectModel>();
        public IEnumerable<SubjectModel> ScienceSubjects { get; set; } = new List<SubjectModel>();
        public IEnumerable<SubjectModel> HumanitySubjects { get; set; } = new List<SubjectModel>();
        public IEnumerable<SubjectModel> TechnicalSubjects { get; set; } = new List<SubjectModel>();
        public List<StudentSubjectModel> StudentSubjects { get; set; } = new List<StudentSubjectModel>();
        public TeacherModel SelectedTeacherOnAssignTeacherTab { get; set; }
        public SubjectModel SelectedSubjectOnAssignTeacherTab { get; set; }
        public SubjectCategoryModel SelectedSubjectCategory { get; set; }
        public SubjectModel SelectedScience { get; set; }
        public SubjectModel SelectedHumanity { get; set; }
        public SubjectModel SelectedTechnical { get; set; }
        public StudentModel Student { get; set; }
        public bool fixed_header = true;
        public bool showTeacherSubject = false;
        private TeacherModel _selectedTeacherOnAssignTeacherTab;
        public int StudentNumber;
        public bool showTable = false;
        public bool showScienceSelection = false;
        public bool showHumanitySelection = false;
        public bool showTechnicalSelection = false;
        protected override async Task OnInitializedAsync()
        {
            TeacherSubjectModel = (await TeacherSubjectService.GetMultipleMapping()).ToList();
            SubjectsWithCategories = await SubjectService.MapSubjectOnCategory();
        }
        public async Task<IEnumerable<SubjectCategoryModel>> SubjectCategorySerach(string value)
        {
            return (await SubjectCategoryService.GetSubjectCategories()).Where(x => x.SubjectCategoryId == 2 || x.SubjectCategoryId == 3 || x.SubjectCategoryId == 4).ToList();
        }
        public async Task<IEnumerable<TeacherModel>> TeacherSearchOnAssignTeacherTab(string value)
        {
            return (await TeacherService.MapStaffOnTeacher()).ToList();
        }
        public async Task<IEnumerable<SubjectModel>> SubjectSearchOnAssignTeacherTab(string value)
        {
            return (await SubjectService.GetSubjects()).ToList();
        }
        public async Task<IEnumerable<SubjectModel>> ScienceSearchOnSelectionTab(string value)
        {
            ScienceSubjects = (await SubjectService.GetSubjects()).Where(x => x.Code == 232 || x.Code == 236).ToList();
            return ScienceSubjects;
        }
        public async Task<IEnumerable<SubjectModel>> HumanitySearchOnSelectionTab(string value)
        {
            HumanitySubjects = (await SubjectService.GetSubjects()).Where(x => x.Code == 311 || x.Code == 312).ToList();
            return HumanitySubjects;
        }
        public async Task<IEnumerable<SubjectModel>> TechnicalSearchOnSelectionTab(string value)
        {
            TechnicalSubjects = (await SubjectService.GetSubjects()).Where(x => x.Code == 565 || x.Code == 443).ToList();
            return TechnicalSubjects;
        }
        public async Task SubjectCategorySelection(SubjectCategoryModel subjectCategory)
        {
            SelectedSubjectCategory = subjectCategory;
            if (SelectedSubjectCategory.SubjectCategoryId == 2)
            {
                showScienceSelection = true;
                SelectedSubjectCategory = null;
            }
            else if (SelectedSubjectCategory.SubjectCategoryId == 3)
            {
                showHumanitySelection = true;
                SelectedSubjectCategory = null;
            }
            else if (SelectedSubjectCategory.SubjectCategoryId == 4)
            {
                showTechnicalSelection = true;
                SelectedSubjectCategory = null;
            }
        }
        public async Task GetStudent(int studentNumber)
        {
            StudentNumber = studentNumber;
            Student = await StudentService.GetStudentByStudentNumber(StudentNumber);
            StudentSubjects = await StudentSubjectService.GetSubjectsByStudentNumber(StudentNumber);
            showTable = true;
        }
        public async Task GetTeacher(TeacherModel teacher)
        {
            SelectedTeacherOnAssignTeacherTab = teacher;
            TeacherSubjects = (await TeacherSubjectService.GetMultipleMappingByTeacher(SelectedTeacherOnAssignTeacherTab.TeacherId)).ToList();
            showTeacherSubject = true;
        }
        public async Task ScienceSelection()
        {
            var notSelected = ScienceSubjects.First(x => x.Code != SelectedScience.Code);

            bool isFound = false;
            foreach(var s in StudentSubjects)
            {
                if(s.Code == notSelected.Code)
                {
                    isFound = true;
                }
            }
            if (isFound)
            {
                Snackbar.Add($"Student already takes {notSelected.SubjectName}", MudBlazor.Severity.Warning);
            }
            else
            {
                var studentSubject = new StudentSubjectModel
                {
                    StudentNumber = StudentNumber,
                    Code = SelectedScience.Code
                };

                var response = await StudentSubjectService.AddStudentSubject(studentSubject);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Snackbar.Add($"{SelectedScience.SubjectName} selected", MudBlazor.Severity.Success);
                    await GetStudent(StudentNumber);
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    Snackbar.Add($"Student already takes {SelectedScience.SubjectName}", MudBlazor.Severity.Warning);
                }
                else
                {
                    Snackbar.Add($"Subject selection failed", MudBlazor.Severity.Error);
                }
            }
            SelectedScience = null;
            showScienceSelection = false;
        }
        public async Task HumanitySelection()
        {
            var notSelected = HumanitySubjects.First(x => x.Code != SelectedHumanity.Code);

            bool isFound = false;
            foreach (var s in StudentSubjects)
            {
                if (s.Code == notSelected.Code)
                {
                    isFound = true;
                }
            }
            if (isFound)
            {
                Snackbar.Add($"Student already takes {notSelected.SubjectName}", MudBlazor.Severity.Warning);
            }
            else
            {
                var studentSubject = new StudentSubjectModel
                {
                    StudentNumber = StudentNumber,
                    Code = SelectedHumanity.Code
                };

                var response = await StudentSubjectService.AddStudentSubject(studentSubject);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Snackbar.Add($"{SelectedHumanity.SubjectName} selected", MudBlazor.Severity.Success);
                    await GetStudent(StudentNumber);
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    Snackbar.Add($"Student already takes {SelectedHumanity.SubjectName}", MudBlazor.Severity.Warning);
                }
                else
                {
                    Snackbar.Add($"Subject selection failed", MudBlazor.Severity.Error);
                }
            }
            SelectedHumanity = null;
            showHumanitySelection = false;
        }
        public async Task TechnicalSelection()
        {
            var notSelected = TechnicalSubjects.First(x => x.Code != SelectedTechnical.Code);

            bool isFound = false;
            foreach (var s in StudentSubjects)
            {
                if (s.Code == notSelected.Code)
                {
                    isFound = true;
                }
            }
            if (isFound)
            {
                Snackbar.Add($"Student already takes {notSelected.SubjectName}", MudBlazor.Severity.Warning);
            }
            else
            {
                var studentSubject = new StudentSubjectModel
                {
                    StudentNumber = StudentNumber,
                    Code = SelectedTechnical.Code
                };

                var response = await StudentSubjectService.AddStudentSubject(studentSubject);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Snackbar.Add($"{SelectedTechnical.SubjectName} selected", MudBlazor.Severity.Success);
                    await GetStudent(StudentNumber);
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    Snackbar.Add($"Student already takes {SelectedTechnical.SubjectName}", MudBlazor.Severity.Warning);
                }
                else
                {
                    Snackbar.Add($"Subject selection failed", MudBlazor.Severity.Error);
                }
            }
            SelectedTechnical = null;
            showTechnicalSelection = false;
        }
        public async Task AssignClassTeacher()
        {
            var teacherSubjectModel = new TeacherSubjectModel
            {
                TeacherId = SelectedTeacherOnAssignTeacherTab.TeacherId,
                Code = SelectedSubjectOnAssignTeacherTab.Code
            };
            var response = await TeacherSubjectService.CreateTeacherSubject(teacherSubjectModel);
            
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Snackbar.Add($"Successfully added {SelectedSubjectOnAssignTeacherTab.SubjectName}", MudBlazor.Severity.Success);
                await GetTeacher(SelectedTeacherOnAssignTeacherTab);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                Snackbar.Add($"{SelectedSubjectOnAssignTeacherTab.SubjectName} is already assigned to {SelectedTeacherOnAssignTeacherTab.Staff.FirstName}", MudBlazor.Severity.Warning);
            }
            else
            {
                Snackbar.Add($"Subject assignment failed!", MudBlazor.Severity.Error);
            }
            TeacherSubjectModel = (await TeacherSubjectService.GetMultipleMapping()).ToList();
        }
    }
}
