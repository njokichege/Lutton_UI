
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
        [HttpGet("MapStudentOnClass")]
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
    }
}
