using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FimiAppApi.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var models = await eventRepository.GetAllEvents();
                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            try
            {
                var model = await eventRepository.GetEventById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(EventModel eventModel)
        {
            try
            {
                var model = await eventRepository.GetEventById(eventModel.EventId);
                if (model is null)
                {
                    return NotFound();
                }
                var rowsAffected = await eventRepository.UpdateEvent(eventModel);
                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EventModel>> CreateEvent([FromBody]EventModel eventModel)
        {
            try
            {
                if (eventModel is not null)
                {
                    var createdModel = await eventRepository.CreateEvent(eventModel);
                    return CreatedAtAction(nameof(GetEventById), new { id = eventModel.EventId }, createdModel);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
