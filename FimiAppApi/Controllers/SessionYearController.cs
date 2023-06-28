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

        [HttpGet("{id}", Name = "SessionYearByDates")]
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
                    var createdSession = await _sessionYearRepository.CreateSessionYear(sessionYear);
                    return Ok(createdSession);
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
