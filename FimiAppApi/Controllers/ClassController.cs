 
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
                return StatusCode(500,ex.Message);
            }
            
        }
        [HttpGet("{ClassId}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            try
            {
                var classes = await _classRepository.GetClassById(id);
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{FormId}/{StreamId}/{SessionYearId}")]
        public async Task<IActionResult> GetClassByForeignKeys(ClassModel classModel)
        {
            try
            {
                var oneclass = await _classRepository.GetClassByForeignKeys(classModel);
                if (oneclass is null)
                {
                    return NotFound();
                }
                return Ok(oneclass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateClass(int id,[FromBody] ClassModel classDetails)
        {
            try
            {
                var dbClassExists = await _classRepository.GetClassByForeignKeys(classDetails);
                if (dbClassExists is null)
                {
                    if (classDetails is null)
                    {
                        return BadRequest();
                    }
                    var createdClass = await _classRepository.CreateClass(classDetails);
                    return Ok(createdClass);
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateClass(int id,[FromBody] ClassModel classDetails)
        {
            try
            {
                var dbClass = await _classRepository.GetClassByForeignKeys(classDetails);
                if (dbClass is null)
                {
                    return NotFound();
                }
                id = dbClass.ClassId;
                await _classRepository.UpdateClassTeacher(id, classDetails);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            try
            {
                var dbClass = await _classRepository.GetClassById(id);
                if (dbClass is null)
                {
                    return NotFound();
                }

                await _classRepository.DeleteClass(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("MultipleMapping")]
        public async Task<IActionResult> GetMultipleMapping()
        {
            try
            {
                var classes = await _classRepository.GetMultipleMapping();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}