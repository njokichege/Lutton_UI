using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/lab")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly ILabRepository _labRepository;

        public LabController(ILabRepository labRepository)
        {
            _labRepository = labRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLabs()
        {
            try
            {
                var labModels = await _labRepository.GetAllLabs();
                return Ok(labModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
