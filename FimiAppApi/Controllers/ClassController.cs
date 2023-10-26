 
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
                var classModels = await _classRepository.GetClasses();
                return Ok(classModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            try
            {
                var classModel = await _classRepository.GetClassMultipleMappingById(id);
                return Ok(classModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{FormId}/{StreamId}/{SessionYearId}")]
        public async Task<IActionResult> GetClassByForeignKeys(int formId, int streamId, int sessionYearId)
        {
            try
            {
                var oneclass = await _classRepository.GetClassByForeignKeys(formId,streamId,sessionYearId);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ClassModel>> CreateClass([FromBody] ClassModel classModel)
        {
            try
            {
                var dbClassExists = await _classRepository.GetClassByForeignKeys(classModel.FormId,classModel.StreamId,classModel.SessionYearId);
                if (dbClassExists is null)
                {
                    var createdClass = await _classRepository.CreateClass(classModel);
                    return CreatedAtAction(nameof(GetClassById), new { id = createdClass.ClassId }, createdClass);
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
        [HttpPut("ClassTeacher")]
        public async Task<IActionResult> UpdateClassTeacher(ClassModel classModel)
        {
            try
            {
                var dbClass = await _classRepository.GetClassByForeignKeys(classModel.FormId, classModel.StreamId, classModel.SessionYearId);
                if (dbClass is null)
                {
                    return NotFound();
                }
                var rowsAffected = await _classRepository.UpdateClassTeacher(dbClass.ClassId, classModel.TeacherId);
                if(rowsAffected > 0)
                {
                    return Ok();
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
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            try
            {
                //var dbClass = await _classRepository.GetClassById(id);
                //if (dbClass is null)
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
                var classes = await _classRepository.GetClassMultipleMapping();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}