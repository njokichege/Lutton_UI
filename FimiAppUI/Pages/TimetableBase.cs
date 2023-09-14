using ComponentBase = Microsoft.AspNetCore.Components.ComponentBase;

namespace FimiAppUI.Pages
{
    public class TimetableBase : ComponentBase
    {
        [Inject] public ITimeSlotService TimeSlotService { get; set; }
        [Inject] public ISubjectService SubjectService { get; set; }
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        public FormModel SelectedForm { get; set; }
        public StreamModel SelectedStream { get; set; }
        public SubjectModel SelectedSubject { get; set; }
        public TimeSlotModel SelectedTimeSlot { get; set; }
        protected override async Task OnInitializedAsync()
        {
            IEnumerable<TimeSlotModel> slotModels = await TimeSlotService.GetTimeSlots();
        }
        public async Task<IEnumerable<FormModel>> SelectedFormSearch(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> SelectedStreamSearch(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async Task<IEnumerable<SubjectModel>> SelectedSubjectSearch(string value)
        {
            return (await SubjectService.GetSubjects()).ToList();
        }
        public async Task<IEnumerable<TimeSlotModel>> SelectedTimeSlotSearch(string value)
        {
            return (await TimeSlotService.GetTimeSlots()).ToList();
        }
        public async void FindClass()
        {
            
        }
    }
}
