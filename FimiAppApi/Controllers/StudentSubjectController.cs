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
                var subjects = await _studentSubjectRepository.MapStudentOnSubject(classId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("subjectsbystudentnumber/{studentNumber}")]
        public async Task<IActionResult> GetSubjectsByStudentNumber(int studentNumber)
        {
            try
            {
                var subjects = await _studentSubjectRepository.GetSubjectsByStudentNumber(studentNumber);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
