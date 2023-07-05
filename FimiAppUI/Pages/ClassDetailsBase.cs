using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ClassDetailsBase: ComponentBase
    {
        [Inject] public IClassService ClassService { get; set; }
        [Parameter] public string Id { get; set; }
        public IEnumerable<ClassModel> ClassSelected { get; set; } = new List<ClassModel>();
        protected async override Task OnInitializedAsync()
        {
            ClassSelected = await ClassService.GetClassById(int.Parse(Id));
        }
    }
}
