
namespace FimiAppApi.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            try
            {
                var classes = await _classRepository.GetClasses();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500,ex.Message);
            }
            
        }
        [HttpGet("{id}", Name = "ClassById")]
        public async Task<IActionResult> GetClass(int id)
        {
            try
            {
                var oneclass = await _classRepository.GetClass(id);
                if (oneclass is null)
                {
                    return NotFound();
                }
                return Ok(oneclass);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("MultipleMapping")]
        public async Task<IActionResult> GetMultipleMapping()
        {
            try
            {
                var classes = await _classRepository.GetClassFormStreamMultipleMapping();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] ClassForCreationDto classForCreation)
        {
            try
            {
                var createdClass = await _classRepository.CreateClass(classForCreation);
                return CreatedAtRoute("ClassById", new { id = createdClass.ClassId }, createdClass);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateClassGrade(int id, [FromBody] ClassForUpdateGradesDto classForUpdateDto)
        {
            try
            {
                var dbClass = await _classRepository.GetClass(id);
                if (dbClass is null)
                {
                    return NotFound();
                }

                await _classRepository.UpdateClassGrade(id, classForUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            try
            {
                var dbClass = await _classRepository.GetClass(id);
                if (dbClass is null)
                {
                    return NotFound();
                }

                await _classRepository.DeleteClass(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}