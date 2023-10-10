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
        [HttpGet("getlastentry")]
        public async Task<IActionResult> GetLastEntry()
        {
            try
            {
                var timeModel = await _timetableRepository.GetLastEntry();
                return Ok(timeModel);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
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
        [HttpGet]
        public async Task<IActionResult> GetTimetableModels()
        {
            try
            {
                var times = await _timetableRepository.GetTimetableModels();
                return Ok(times);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("timetableentriesbyclass/{classId}")]
        public async Task<IActionResult> GetTimetableModelsByClass(int classId)
        {
            try
            {
                var times = await _timetableRepository.GetTimetableModelsByClass(classId);
                return Ok(times);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{classId}/{subjectCode}/{dayOfTheWeek}")]
        public async Task<IActionResult> GetTimetableEntryByDayOfTheWeek(int classId, int subjectCode, string dayOfTheWeek)
        {
            try
            {
                var times = await _timetableRepository.GetTimetableEntryByDayOfTheWeek(classId, subjectCode, dayOfTheWeek);
                return Ok(times);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{classId}/{subjectCode}/{timeslotId}/{dayOfTheWeek}")]
        public async Task<IActionResult> GetTimetableEntryByTimeslot(int classId, int subjectCode, int timeslotId, string dayOfTheWeek)
        {
            try
            {
                var times = await _timetableRepository.GetTimetableEntryByTimeslot(classId,subjectCode,timeslotId,dayOfTheWeek);
                return Ok(times);
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
