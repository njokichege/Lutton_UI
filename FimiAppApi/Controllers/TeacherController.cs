using FimiAppLibrary.Models;
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
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeacherById(int nationalId)
        {
            try
            {
                var teacher = await _teacherRepository.GetTeacherById(nationalId);
                return Ok(teacher);
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
        [HttpGet("mapstaffonteacherbyid/{teacherId}")]
        public async Task<IActionResult> MapStaffOnTeacherById(int teacherId)
        {
            try
            {
                var teacher = await _teacherRepository.MapStaffOnTeacherById(teacherId);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TeacherModel>> AddTeacher([FromBody] TeacherModel teacher)
        {
            try
            {
                var dbTeacherExists = await _teacherRepository.GetTeacherById(teacher.Staff.NationalId);
                if (dbTeacherExists is null)
                {
                    var teacherEntry = await _teacherRepository.AddTeacher(teacher);
                    return CreatedAtAction(nameof(GetTeacherById), new { id = teacherEntry.TeacherId}, teacherEntry);
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
