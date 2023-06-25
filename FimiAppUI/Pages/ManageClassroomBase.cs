using FimiAppUI.Services;
using static MudBlazor.CategoryTypes;
using System.Net.Http;
using static MudBlazor.Colors;
using Microsoft.AspNetCore.Http;

namespace FimiAppUI.Pages
{
    public class ManageClassroomBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IClassService ClassService { get; set; }
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public ITeacherService TeacherService { get; set; }
        [Inject] public ISessionYearService SessionYearService { get; set; }
        public IEnumerable<ClassModel> Classes { get; set; }
        public FormModel SelectedFormOnClassCard { get; set; }
        public FormModel SelectedFormOnTeacherCard { get; set; }
        public TeacherModel SelectedTeacherOnTeacherCard { get; set; }
        public StreamModel SelectedStreamOnClassCard { get; set; }
        public StreamModel SelectedStreamOnTeacherCard { get; set; }
        public SessionYearModel SelectedSessionYearOnClassCard { get; set; }
        public SessionYearModel SelectedSessionYearOnSessionYearCard { get; set; }
        public IEnumerable<SessionYearModel> SessionYearTiltle { get; set; }
        public string SessionYearModelTitle { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Classes = (await ClassService.GetMultipleMapping()).ToList();

            SessionYearTiltle = (await SessionYearService.GetSessionYear()).ToList();
            foreach (var session in SessionYearTiltle)
            {
                if (session.SessionYear.Contains("2023"))
                {
                    SessionYearModelTitle = session.SessionYear;
                }
            }
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
            return (await TeacherService.GetTeachers()).ToList();
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
            return (await SessionYearService.GetSessionYear()).ToList();
        }
        public async Task<IEnumerable<SessionYearModel>> SessionYearSearchOnSessionYearCard(string value)
        {
            return (await SessionYearService.GetSessionYear()).ToList();
        }
    }
}
