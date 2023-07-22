using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/studentsubject")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IStudentSubjectRepository _studentSubjectRepository;

        public StudentSubjectController(IStudentSubjectRepository studentSubjectRepository)
        {
            
            _studentSubjectRepository = studentSubjectRepository;
        }
        [HttpGet("mapstudentonsubject/{classId}")]
        public async Task<IActionResult> MapStudentOnSubject(int classId)
        {
            try
            {
                var subjects = await _studentSubjectRepository.MapStudentfOnSubject(classId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
