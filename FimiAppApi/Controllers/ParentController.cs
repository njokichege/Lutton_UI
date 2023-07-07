using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/parent")]
    [ApiController]
    public class ParentController : Controller
    {
        private readonly IParentRepository _parentRepository;

        public ParentController(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }
        [HttpGet("{nationalId}")]
        public async Task<IActionResult> GetParentById(int nationalId)
        {
            try
            {
                var parent = await _parentRepository.GetParentById(nationalId);
                return Ok(parent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
