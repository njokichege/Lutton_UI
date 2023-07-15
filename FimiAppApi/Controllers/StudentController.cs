
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _studentRepository.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("class/{classId}")]
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
        [HttpGet("studentnumber/{studentnumber}")]
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
        [HttpPost]
        public async Task<ActionResult> CreateStudent([FromBody]StudentModel student)
        {
            try
            {
                if(student is not null)
                {
                    var rowChanged = await _studentRepository.CreateStudent(student);
                    if (rowChanged == 1)
                    {
                        return StatusCode(201,student);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
