using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/schoolperformance")]
    [ApiController]
    public class SchoolPerformanceController : ControllerBase
    {
        private readonly ISchoolPerformanceRepository _classPerformanceRepository;

        public SchoolPerformanceController(ISchoolPerformanceRepository classPerformanceRepository)
        {
            _classPerformanceRepository = classPerformanceRepository;
        }
        [HttpGet("{sessionYearId}/{termId}/{examTypeId}")]
        public async Task<IActionResult> GetClassePerformances(int sessionYearId, int termId, int examTypeId)
        {
            try
            {
                var classPerformances = await _classPerformanceRepository.GetSchoolPerformances(sessionYearId,termId,examTypeId);
                return Ok(classPerformances);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
