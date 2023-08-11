using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/classsubjectperformance")]
    [ApiController]
    public class ClassPerformanceController : ControllerBase
    {
        private readonly IClassPerformanceRepository _subjectPerformanceRepository;

        public ClassPerformanceController(IClassPerformanceRepository subjectPerformanceRepository)
        {
            _subjectPerformanceRepository = subjectPerformanceRepository;
        }
        [HttpGet("{classId}/{sessionYearId}/{termId}/{examTypeId}")]
        public async Task<IActionResult> GetStudentResultsByClass(int classId, int sessionYearId, int termId, int examTypeId)
        {
            try
            {
                var examResult = await _subjectPerformanceRepository.GetStudentResultsByClass(classId,sessionYearId,termId,examTypeId);
                return Ok(examResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
