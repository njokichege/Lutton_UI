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
        [HttpGet("mapstaffonteacher")]
        public async Task<IActionResult> MapStaffOnTeacher()
        {
            try
            {
                var teachers = await _teacherRepository.MapStaffOnTeacher();
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddTeacher(TeacherModel teacher)
        {
            try
            {
                var dbTeacherExists = await _teacherRepository.GetTeacher(teacher.Staff.NationalId);
                if (dbTeacherExists is null)
                {
                    var createdTeacher = await _teacherRepository.AddTeacher(teacher);
                    return Ok(createdTeacher);
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
    }
}
