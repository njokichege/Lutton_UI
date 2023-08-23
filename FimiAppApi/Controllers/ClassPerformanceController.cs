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
        [HttpGet("classresult/{sessionId}/{termId}/{classId}/{studentNumber}")]
        public async Task<IActionResult> GetClassPerformancePerTerm(int sessionId, int termId, int classId, int studentNumber)
        {
            try
            {
                var classResult = await _subjectPerformanceRepository.GetClassPerformancePerTerm(sessionId, termId, classId,studentNumber);
                return Ok(classResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("studentresult/{studentNumber}")]
        public async Task<IActionResult> GetStudentResults(int studentNumber)
        {
            try
            {
                var studentResult = await _subjectPerformanceRepository.GetStudentResults(studentNumber);
                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
        [HttpPut("StudentResults")]
        public async Task<IActionResult> UpdateStudentResults(ClassPerformanceModel classPerformanceModel)
        {
            try
            {
                await _subjectPerformanceRepository.UpdateStudentResults(classPerformanceModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
