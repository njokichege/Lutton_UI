using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/parentstudent")]
    [ApiController]
    public class ParentStudentController : ControllerBase
    {
        private readonly IParentStudentRepository _parentStudentRepository;

        public ParentStudentController(IParentStudentRepository parentStudentRepository)
        {
            _parentStudentRepository = parentStudentRepository;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetParentStudentById(int id)
        {
            try
            {
                var parentStudent = await _parentStudentRepository.GetParentStudentById(id);
                return Ok(parentStudent);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddParentStudent(ParentModel parent)
        {
            try
            {
                if (parent is not null)
                {
                    var parentStudent = await _parentStudentRepository.AddParentStudent(parent.NationalId);
                    return CreatedAtAction(nameof(GetParentStudentById), new { id = parentStudent.ParentStudentId}, parentStudent);
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
