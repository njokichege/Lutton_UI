using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/examtype")]
    [ApiController]
    public class ExamTypeController : Controller
    {
        private readonly IExamTypeRepository _examTypeRepository;

        public ExamTypeController(IExamTypeRepository examTypeRepository)
        {
            _examTypeRepository = examTypeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExamTypes()
        {
            try
            {
                var examTypes = await _examTypeRepository.GetAllExamTypes();
                return Ok(examTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
