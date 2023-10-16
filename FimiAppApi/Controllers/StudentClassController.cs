using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/studentclass")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassRepository _studentClassRepository;

        public StudentClassController(IStudentClassRepository studentClassRepository)
        {
            _studentClassRepository = studentClassRepository;
        }
        [HttpGet("{studentClassId}")]
        public async Task<IActionResult> GetStudentClassById(int studentClassId)
        {
            try
            {
                var studentModel = await _studentClassRepository.GetStudentClassById(studentClassId);
                return Ok(studentModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateStudentClass([FromBody] StudentClassModel studentClassModel)
        {
            try
            {
                if (studentClassModel is not null)
                {
                    var model = await _studentClassRepository.AddStudentClass(studentClassModel);
                    return CreatedAtAction(nameof(GetStudentClassById), new { studentClassId = model.StudentClassId }, model);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
