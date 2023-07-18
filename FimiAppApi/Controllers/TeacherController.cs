using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var teachers = await _teacherRepository.GetTeachers();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("MapStaffOnTeacher")]
        public async Task<IActionResult> MapStaffOnTeacher()
        {
            try
            {
                var classes = await _teacherRepository.MapStaffOnTeacher();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
    }
}
