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
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTimetableEntryById(int id)
        {
            try
            {
                var timetable = await _timetableRepository.GetTimetableEntryById(id);
                return Ok(timetable);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddTimetableEntry(TimetableModel timetableModel)
        {
            if (timetableModel is null)
            {
                return BadRequest(new ArgumentNullException());
            }
            else
            {
                try
                {
                    var timetableEntry = await _timetableRepository.AddTimetableEntry(timetableModel);
                    return CreatedAtAction(nameof(GetTimetableEntryById),new {id = timetableEntry.TimetableId},timetableEntry);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
