using FimiAppApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var classes = await _classRepository.GetClasses();
            return Ok(classes);
        }
        [HttpGet("{id}", Name = "ClassById")]
        public async Task<IActionResult> GetClass(int id)
        {
            var oneclass = await _classRepository.GetClass(id);
            if(oneclass is null)
            {
                return NotFound();
            }
            return Ok(oneclass);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody]ClassForCreationDto classForCreation)
        {
            var createdClass = await _classRepository.CreateClass(classForCreation);
            return CreatedAtRoute("ClassById", new { id = createdClass.ClassId},createdClass);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateClassGrade(int id, [FromBody] ClassForUpdateGradesDto classForUpdateDto)
        {
            var dbClass = await _classRepository.GetClass(id);
            if(dbClass is null)
            {
                return NotFound();
            }

            await _classRepository.UpdateClassGrade(id, classForUpdateDto);
            return NoContent();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var dbClass = await _classRepository.GetClass(id);
            if (dbClass is null)
            {
                return NotFound();
            }

            await _classRepository.DeleteClass(id);
            return NoContent();
        }
    }
}
