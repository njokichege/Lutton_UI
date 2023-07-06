using FimiAppUI.Contracts;

namespace FimiAppUI.Pages
{
    public class ClassDetailsBase: ComponentBase
    {
        [Inject] public IClassService ClassService { get; set; }
        [Parameter] public string Id { get; set; }
        public ClassModel ClassSelected { get; set; } = new ClassModel();
        public bool dataIsLoaded = false;
        protected async override Task OnInitializedAsync()
        {
            ClassSelected = await ClassService.GetClassById(int.Parse(Id));
            dataIsLoaded = true;
        }
    }
}
