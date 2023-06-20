
namespace FimiAppApi.Controllers
{
    [Route("api/stream")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly IStreamRepository _streamRepository;

        public StreamController(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetStreams()
        {
            try
            {
                var streams = await _streamRepository.GetStreams();
                return Ok(streams);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
    }
}
