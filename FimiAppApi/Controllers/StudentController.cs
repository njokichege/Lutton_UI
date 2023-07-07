
namespace FimiAppApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet("{classId}")]
        public async Task<IActionResult> GetMultipleMapping(int classId)
        {
            try
            {
                var students = await _studentRepository.MapClassOnStudent(classId);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{studentNumber}")]
        public async Task<IActionResult> GetStudentByStudentNumber(int studentNumber)
        {
            try
            {
                var studentModel = await _studentRepository.GetStudent(studentNumber);
                return Ok(studentModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
