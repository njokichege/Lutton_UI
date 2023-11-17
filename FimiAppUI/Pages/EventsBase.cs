using Radzen;
using Radzen.Blazor;
using Radzen.Blazor.Rendering;
using System;

namespace FimiAppUI.Pages
{
    public class EventsBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IEventService EventService { get; set; }
        [Inject] public Radzen.DialogService RadzenDialog { get; set; }
        [Inject] public IEventTypeService EventTypeService { get; set; }
        public IList<EventModel> Events { get; set; } 
        public RadzenScheduler<EventModel> scheduler;
        public Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();
        public IEnumerable<EventTypeModel> EventTypeModels { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Events = await EventService.GetAllEvents();
            EventTypeModels = await EventTypeService.GetAllEventTypes();
        }
        public void OnSlotRender(SchedulerSlotRenderEventArgs args)
        {
            // Highlight today in month view
            if (args.View.Text == "Month" && args.Start.Date == DateTime.Today)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }

            // Highlight working hours (9-18)
            if ((args.View.Text == "Week" || args.View.Text == "Day") && args.Start.Hour > 8 && args.Start.Hour < 19)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }
        }

        public async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
        {
            if (args.View.Text != "Year")
            {
                EventModel data = await RadzenDialog.OpenAsync<AddEvent>("Add Event",
                    new Dictionary<string, object> { { "Start", args.Start }, { "End", args.End }, { "EventTypes", EventTypeModels } });

                if (data != null)
                {
                    // Either call the Reload method or reassign the Data property of the Scheduler
                    Events = await EventService.GetAllEvents();
                    scheduler.Data = Events;
                    await scheduler.Reload();
                }
            }
        }

        public async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<EventModel> args)
        {
            var copy = new EventModel
            {
                EventId = args.Data.EventId,
                Start = args.Data.Start,
                End = args.Data.End,
                Text = args.Data.Text,
                EventType = args.Data.EventType
            };

            var data = await RadzenDialog.OpenAsync<EditEvent>("Edit Event", new Dictionary<string, object> { { "Event", copy },{ "EventTypes", EventTypeModels } });

            if (data != null)
            {
                // Update the appointment
                args.Data.Start = data.Start;
                args.Data.End = data.End;
                args.Data.Text = data.Text;
                args.Data.EventType.EventType = data.EventType.EventType;
            }

            Events = await EventService.GetAllEvents();
            scheduler.Data = Events;
            await scheduler.Reload();
        }

        public void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<EventModel> args)
        {
            // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

            if (args.Data.EventType.EventType.Equals("Term Dates"))
            {
                args.Attributes["style"] = "background: #DA4167";
            }
            else if (args.Data.EventType.EventType.Equals("Exam"))
            {
                args.Attributes["style"] = "background: #78CDD7";
            }
            else if (args.Data.EventType.EventType.Equals("Student Event"))
            {
                args.Attributes["style"] = "background: #D36135";
            }
            else if (args.Data.EventType.EventType.Equals("Parent Event"))
            {
                args.Attributes["style"] = "background: #006494";
            }
        }
    }
}
