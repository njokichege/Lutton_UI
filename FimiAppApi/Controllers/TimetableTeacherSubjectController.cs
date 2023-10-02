using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/timetableteachersubject")]
    [ApiController]
    public class TimetableTeacherSubjectController : Controller
    {
        private readonly ITimetableTeacherSubjectRepository _timetableTeacherSubjectRepository;

        public TimetableTeacherSubjectController(ITimetableTeacherSubjectRepository timetableTeacherSubjectRepository)
        {
            _timetableTeacherSubjectRepository = timetableTeacherSubjectRepository;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTimetableEntryById(int id)
        {
            try
            {
                var timetable = await _timetableTeacherSubjectRepository.GetTimetableTeacherSubjectEntryById(id);
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
        public async Task<IActionResult> AddTimetableEntry(TimetableTeacherSubjectModel timetableTeacherSubjectModel)
        {
            if (timetableTeacherSubjectModel is null)
            {
                return BadRequest(new ArgumentNullException());
            }
            else
            {
                try
                {
                    var timetableEntry = await _timetableTeacherSubjectRepository.AddTimetableEntry(timetableTeacherSubjectModel);
                    return CreatedAtAction(nameof(GetTimetableEntryById), new { id = timetableEntry.TimetableSubjectId }, timetableEntry);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
