using FimiAppLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/sessionyear")]
    [ApiController]
    public class SessionYearController : ControllerBase
    {
        private readonly ISessionYearRepository _sessionYearRepository;
        public SessionYearController(ISessionYearRepository sessionYearRepository)
        {
            _sessionYearRepository = sessionYearRepository;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSessionYearById(int id)
        {
            try
            {
                var session = await _sessionYearRepository.GetSessionYearById(id);
                return Ok(session);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("SessionYearByDates")]
        public async Task<IActionResult> GetSessionYearByDates(SessionYearModel sessionYear)
        {
            try
            {
                var oneSession = await _sessionYearRepository.GetSessionYearByDates(sessionYear);
                if (oneSession is null)
                {
                    return NotFound();
                }
                return Ok(oneSession);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSessionYears()
        {
            try
            {
                var sessions = await _sessionYearRepository.GetSessionYears();
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateSessionYear(int id, [FromBody] SessionYearModel sessionYear)
        {
            try
            {
                var dbSessionExists = await _sessionYearRepository.GetSessionYearByDates(sessionYear);
                if (dbSessionExists is null)
                {
                    if (sessionYear is null)
                    {
                        return BadRequest();
                    }
                    var timetableEntry = await _sessionYearRepository.CreateSessionYear(sessionYear);
                    return CreatedAtAction(nameof(GetSessionYearById), new { id = sessionYear.SessionYearId }, sessionYear);
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
