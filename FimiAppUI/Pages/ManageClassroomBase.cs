
using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ManageClassroomBase : ComponentBase
    {
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public ISessionYearService SessionYearService { get; set; }
        [Parameter] public string PageTitle { get; set; }
        public IEnumerable<ClassModel> Classes { get; set; }
        public ClassModel SelectedDataRow { get; set; }
        public FormModel SelectedFormOnClassCard { get; set; }
        public FormModel SelectedFormOnTeacherCard { get; set; }
        public TeacherModel SelectedTeacherOnTeacherCard { get; set; }
        public StreamModel SelectedStreamOnClassCard { get; set; }
        public StreamModel SelectedStreamOnTeacherCard { get; set; }
        public SessionYearModel SelectedSessionYearOnClassCard { get; set; }
        public SessionYearModel SelectedSessionYearOnSessionYearCard { get; set; }
        public SessionYearModel SelectedSessionYearOnTeacherCard { get; set; }
        public IEnumerable<SessionYearModel> SessionYearTiltle { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        public string SessionYearModelTitle { get; set; }
        public DateTime? startDate = DateTime.Today;
        public DateTime? endDate = DateTime.Today;
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public MudTable<ClassModel> mudTable;
        protected override async Task OnInitializedAsync()
        {
            Classes = (await ClassService.GetMultipleMapping()).ToList();

            PageTitle = "Manage Classroom";

            SessionYearTiltle = (await SessionYearService.GetSessionYears()).ToList();
            foreach (var session in SessionYearTiltle)
            {
                if (session.StartDate.Year == 2023)
                {
                    SessionYearModelTitle = session.SessionString();
                }
            }
        }
        public void ChangeSchoolYear()
        {
            SessionYearModelTitle = SelectedSessionYearOnSessionYearCard.SessionString();
        }
        public async Task<IEnumerable<FormModel>> FormSearchOnClassCard(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<FormModel>> FormSearchOnTeacherCard(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<TeacherModel>> TeacherSearchOnTeacherCard(string value)
        {
            return (await TeacherService.GetMultipleMapping()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> StreamSearchOnClassCard(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> StreamSearchOnTeacherCard(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async Task<IEnumerable<SessionYearModel>> SessionYearSearchOnClassCard(string value)
        {
            return (await SessionYearService.GetSessionYears()).ToList();
        }
        public async Task<IEnumerable<SessionYearModel>> SessionYearSearchOnSessionYearCard(string value)
        {
            return (await SessionYearService.GetSessionYears()).ToList();
        }
        public async Task<IEnumerable<SessionYearModel>> SessionYearSearchOnTeacherCard(string value)
        {
            return (await SessionYearService.GetSessionYears()).ToList();
        }
        public async Task<HttpResponseMessage> CreateClass()
        {
            var classModel = new ClassModel
            {
                FormId = SelectedFormOnClassCard.FormId,
                StreamId = SelectedStreamOnClassCard.StreamId,
                SessionYearId = SelectedSessionYearOnClassCard.SessionYearId
            };

            var response = await ClassService.CreateClass(classModel).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ShowSuccessAlert($"Class {SelectedFormOnClassCard.Form}{SelectedStreamOnClassCard.Stream} year {SelectedSessionYearOnClassCard.StartDate.Year} was created");
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                
                ShowFailAlert($"Class {SelectedFormOnClassCard.Form}{SelectedStreamOnClassCard.Stream} year {SelectedSessionYearOnClassCard.StartDate.Year} already exists");
            }
            return response;
        }
        public async Task<HttpResponseMessage> AssignClassTeacher()
        {
            var classModel = new ClassModel
            {
                FormId = SelectedFormOnTeacherCard.FormId,
                StreamId = SelectedStreamOnTeacherCard.StreamId,
                SessionYearId = SelectedSessionYearOnTeacherCard.SessionYearId,
                TeacherId = SelectedTeacherOnTeacherCard.TeacherId
            };
            var response = await ClassService.UpdateClass(classModel).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ShowSuccessAlert($"Class Teacher added for class {SelectedFormOnTeacherCard.Form}{SelectedStreamOnTeacherCard.Stream} year {SelectedSessionYearOnTeacherCard.SessionString()}");
            }
            else  
            {

                ShowFailAlert($"Class {SelectedFormOnTeacherCard.Form}{SelectedStreamOnTeacherCard.Stream} year {SelectedSessionYearOnTeacherCard.StartDate.Year} doesn't exists");
            }
            return response;
        }
        public async Task CreateNewSchoolYear()
        {
            var sessionYear = new SessionYearModel
            {
                StartDate = (DateTime)startDate,
                EndDate = (DateTime)endDate
            };
            var response = await SessionYearService.CreateSessionYear(sessionYear).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ShowSuccessAlert($"School year : {startDate} - {endDate} has been created");
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {

                ShowFailAlert($"School year : {startDate} - {endDate} already exists");
            }
        }
        public void ShowSuccessAlert(string modelType)
        {
            ModelSuccess = modelType;
            showSuccessAlert = true;
        }
        public void ShowFailAlert(string modelType)
        {
            ModelFail = modelType;
            showFailAlert = true;
        }
        public void CloseMe(bool value)
        {
            if (value)
            {
                showSuccessAlert = false;
                showFailAlert = false;
            }
            else
            {
                showSuccessAlert = false;
                showFailAlert = false;
            }
        }
    }
}
