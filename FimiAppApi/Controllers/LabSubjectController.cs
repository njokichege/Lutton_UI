using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/labsubject")]
    [ApiController]
    public class LabSubjectController : Controller
    {
        private readonly ILabSubjectRepository _labSubjectRepository;

        public LabSubjectController(ILabSubjectRepository labSubjectRepository)
        {
            _labSubjectRepository = labSubjectRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLabSubjects()
        {
            try
            {
                var labModels = await _labSubjectRepository.GetAllLabSubjects();
                return Ok(labModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
