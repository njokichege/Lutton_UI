using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/timetable")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableRepository _timetableRepository;

        public TimetableController(ITimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddTimetableEntry(TimetableModel timetableModel)
        {
            try
            {
                var timetable = await _timetableRepository.AddTimetableEntry(timetableModel);
                return Ok(timetable);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
