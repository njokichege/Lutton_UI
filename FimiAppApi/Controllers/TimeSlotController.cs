using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/timeslot")]
    [ApiController]
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotRepository _timeSlotRepository;

        public TimeSlotController(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTimeSlots()
        {
            try
            {
                var times = await _timeSlotRepository.GetAllTimaSlots();
                return Ok(times);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
