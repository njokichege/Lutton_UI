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
    }
}
