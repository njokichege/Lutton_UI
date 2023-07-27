
using Microsoft.SqlServer.Server;
using System.IO;

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
        public async Task<IActionResult> AddGrade(GradeModel grade)
        {
            try
            {
                var createdGrade = await _gradeRepository.AddGrades(grade);
                return Ok(createdGrade);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
