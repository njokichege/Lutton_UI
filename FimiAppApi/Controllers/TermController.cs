using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/term")]
    [ApiController]
    public class TermController : Controller
    {
        private readonly ITermRepository _termRepository;

        public TermController(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTerms()
        {
            try
            {
                var terms = await _termRepository.GetAllTerms();
                return Ok(terms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
