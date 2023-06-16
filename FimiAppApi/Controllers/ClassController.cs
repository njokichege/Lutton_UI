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
    }
}
