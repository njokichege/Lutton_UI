using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            try
            {
                var subjects = await _subjectRepository.GetSubjects();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
