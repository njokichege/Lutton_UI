using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/examresult")]
    [ApiController]
    public class ExamResultController : Controller
    {
        private readonly IExamResultRepository _examResultRepository;

        public ExamResultController(IExamResultRepository examResultRepository)
        {
            _examResultRepository = examResultRepository;
        }
        [HttpGet("{sessionYearId}")]
        public async Task<IActionResult> GetYearlySchoolResults(int sessionYearId)
        {
            try
            {
                var models = await _examResultRepository.GetYearlySchoolResults(sessionYearId);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
