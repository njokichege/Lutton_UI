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
        [Inject] public ISessionYearService SessionYearService { get; set; }
        public IEnumerable<ClassModel> Classes { get; set; }
        public FormModel SelectedForm { get; set; }
        public FormModel SelectedForm2 { get; set; }
        public StreamModel SelectedStream { get; set; }
        public SessionYearModel SelectedSessionYear { get; set; }
        public ClassModel SelectedClass { get; set; }
        public SessionYearModel SessionYear2 { get; set; }
        public IEnumerable<SessionYearModel> SessionYearTiltle { get; set; }
        public string SessionYearModelTitle { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Classes = (await ClassService.GetClasses()).ToList();
            SessionYearTiltle = (await SessionYearService.GetSessionYear()).ToList();
            foreach (var session in SessionYearTiltle)
            {
                if (session.SessionYear.Contains("2023"))
                {
                    SessionYearModelTitle = session.SessionYear;
                }
            }
        }
        public async Task<IEnumerable<FormModel>> FormSearch(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> StreamSearch(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async Task<IEnumerable<SessionYearModel>> SessionYearSearch(string value)
        {
            return (await SessionYearService.GetSessionYear()).ToList();
        }
        public async Task<IEnumerable<SessionYearModel>> SessionYearSearch2(string value)
        {
            return (await SessionYearService.GetSessionYear()).ToList();
        }
        public async Task<IEnumerable<FormModel>> FormSearch2(string value)
        {
            return (await FormService.GetClassFormMapping()).ToList();
        }
    }
}
