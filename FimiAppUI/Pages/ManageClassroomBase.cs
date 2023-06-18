using FimiAppUI.Services;

namespace FimiAppUI.Pages
{
    public class ManageClassroomBase : ComponentBase
    {
        [Inject]
        public IClassService ClassService { get; set; }
        [Inject]
        public IFormService FormService { get; set; }
        public IEnumerable<ClassModel> Classes { get; set; }
        public IEnumerable<FormModel> Forms { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Classes = (await ClassService.GetClasses()).ToList();
            Forms = (await FormService.GetForms()).ToList();
        }
    }
}
