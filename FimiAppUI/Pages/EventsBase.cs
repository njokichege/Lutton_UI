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
        public IList<EventModel> Events { get; set; } 
        public RadzenScheduler<EventModel> scheduler;
        public Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();

        protected override async Task OnInitializedAsync()
        {
            Events = await EventService.GetAllEvents();
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
                EventModel data = await RadzenDialog.OpenAsync<AddEvent>("Add Appointment",
                    new Dictionary<string, object> { { "Start", args.Start }, { "End", args.End } });

                if (data != null)
                {
                    Events.Add(data);
                    // Either call the Reload method or reassign the Data property of the Scheduler
                    await scheduler.Reload();
                }
            }
        }

        public async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<EventModel> args)
        {
            var copy = new EventModel
            {
                Start = args.Data.Start,
                End = args.Data.End,
                Text = args.Data.Text
            };

            var data = await RadzenDialog.OpenAsync<EditEvent>("Edit Appointment", new Dictionary<string, object> { { "Appointment", copy } });

            if (data != null)
            {
                // Update the appointment
                args.Data.Start = data.Start;
                args.Data.End = data.End;
                args.Data.Text = data.Text;
            }

            await scheduler.Reload();
        }

        public void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<EventModel> args)
        {
            // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

            if (args.Data.EventType.Equals("Term Dates"))
            {
                args.Attributes["style"] = "background: #44AF69";
            }
            else if(args.Data.EventType.Equals("Exam"))
            {
                args.Attributes["style"] = "background: #D64550";
            }
            else if (args.Data.EventType.Equals("Student Event"))
            {
                args.Attributes["style"] = "background: #A6808C";
            }
            else if (args.Data.EventType.Equals("Parent Event"))
            {
                args.Attributes["style"] = "background: #FFBC42";
            }
        }
        public TableGroupDefinition<EventModel> GroupDefinition()
        {
            TableGroupDefinition<EventModel> tableGroup = new
            {
                GroupName = "Group",
                Indentation = false,
                Expandable = false,
                Selector = (e) => e.
            };
            tableGroup.Selector = (e) => { e.EventType = e.EventType.ToString(); };
            return tableGroup;
        }
    }
}
