namespace FimiAppUI.Pages
{
    public class ManageResultsBase : ComponentBase
    {
        [Inject] public ITermService TermService { get; set; }
        [Inject] public IExamTypeService ExamTypeService { get; set; }
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        public IEnumerable<TermModel> Terms { get; set; }
        public IEnumerable<ExamTypeModel> ExamTypes { get; set; }
        public TermModel SelectedTerm { get; set; }
        public ExamTypeModel SelectedExamType { get; set; }
        public FormModel SelectedForm { get; set; }
        public StreamModel SelectedStream { get; set; }
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        public async Task<IEnumerable<TermModel>> SelectedTermSearch(string value)
        {
            return (await TermService.GetAllTerms()).ToList();
        }
        public async Task<IEnumerable<ExamTypeModel>> SelectedExamTypeSearch(string value)
        {
            return (await ExamTypeService.GetAllExamTypes()).ToList();
        }
        public async Task<IEnumerable<FormModel>> SelectedFormSearch(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> SelectedStreamSearch(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async void FindClass()
        {
            
        }
    }
}
