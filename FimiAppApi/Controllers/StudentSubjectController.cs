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
        [HttpGet("findentry/{studentNumber}/{code}")]
        public async Task<IActionResult> FindEntry(int studentNumber, int code)
        {
            try
            {
                var subjects = await _studentSubjectRepository.FindEntry(studentNumber,code);
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
        [HttpGet("{studentSubjectModelId}")]
        public async Task<IActionResult> GetStudentSubjectById(int studentSubjectModelId)
        {
            try
            {
                var studentSubjectModel = await _studentSubjectRepository.GetStudentSubjectById(studentSubjectModelId);
                return Ok(studentSubjectModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<StudentSubjectModel>> AddStudentSubject([FromBody] StudentSubjectModel studentSubjectModel)
        {
            try
            {
                if (studentSubjectModel is not null)
                {
                    var exists = await _studentSubjectRepository.FindEntry(studentSubjectModel.StudentNumber, studentSubjectModel.Code);
                    if(exists is null)
                    {
                        var model = await _studentSubjectRepository.AddStudentSubject(studentSubjectModel);
                        return CreatedAtAction(nameof(GetStudentSubjectById), new { studentSubjectModelId = model.StudentSubjectId }, model);
                    }
                    else
                    {
                        return Conflict();
                    }
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
