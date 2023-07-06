 
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
        [HttpGet("{classId}")]
        public async Task<IActionResult> GetClassById(int classId)
        {
            try
            {
                var classModel = await _classRepository.GetClassMultipleMappingById(classId);
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
        public async Task<IActionResult> CreateClass(int formId, int streamId, int sessionYearId)
        {
            try
            {
                var dbClassExists = await _classRepository.GetClassByForeignKeys(formId,streamId,sessionYearId);
                if (dbClassExists is null)
                {
                    var createdClass = await _classRepository.CreateClass(formId, streamId, sessionYearId);
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
                await _classRepository.UpdateClassTeacher(classModel.ClassId, classModel.TeacherId);
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