
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
        [HttpGet("{StreamId}")]
        public async Task<IActionResult> GetStreamById(int streamId)
        {
            try
            {
                var stream = await _streamRepository.GetStreamById(streamId);
                return Ok(stream);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
    }
}
