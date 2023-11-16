using FimiAppApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/eventtype")]
    [ApiController]
    public class EventTypeController : Controller
    {
        private readonly IEventTypeRepository eventTypeRepository;

        public EventTypeController(IEventTypeRepository eventTypeRepository)
        {
            this.eventTypeRepository = eventTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventTypes()
        {
            try
            {
                var models = await eventTypeRepository.GetAllEventTypes();
                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{eventType}")]
        public async Task<IActionResult> GetEventTypeByName(string eventType)
        {
            try
            {
                var model = await eventTypeRepository.GetEventTypeByName(eventType);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
