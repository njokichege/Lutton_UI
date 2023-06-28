using FimiAppUI.Services;

namespace FimiAppUI.Pages
{
    public class ClassDetailsBase: ComponentBase
    {
        [Inject]
        public IClassService ClassService { get; set; }
        [Parameter]
        public string Id { get; set; }
        public ClassModel Class { get; set; } = new ClassModel();
        protected async override Task OnInitializedAsync()
        {
           Class = await  ClassService.GetClassById(int.Parse(Id));
        }
    }
}
