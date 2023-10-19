
using FimiAppLibrary.Models;

namespace FimiAppApi.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGradeById(int gradeId)
        {
            try
            {
                var grade = await _gradeRepository.GetGradeById(gradeId);
                return Ok(grade);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            try
            {
                var grades = await _gradeRepository.GetAllGrades();
                return Ok(grades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<GradeModel>> AddGrade([FromBody]GradeModel grade)
        {
            if (grade is null)
            {
                return BadRequest(new ArgumentNullException());
            }
            else
            {
                try
                {
                    var createdGrade = await _gradeRepository.AddGrades(grade);
                    return CreatedAtAction(nameof(GetGradeById), new { id = createdGrade.GradeId }, createdGrade);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
