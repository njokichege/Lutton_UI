using FimiAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/teachersubject")]
    [ApiController]
    public class TeacherSubjectController : ControllerBase
    {
        private readonly ITeacherSubjectRepository _teacherSubjectRepository;

        public TeacherSubjectController(ITeacherSubjectRepository teacherSubjectRepository)
        {
            _teacherSubjectRepository = teacherSubjectRepository;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeacherSubjectById(int id)
        {
            try
            {
                var teacherSubject = await _teacherSubjectRepository.GetTeacherSubjectById(id);
                return Ok(teacherSubject);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TeacherSubjectModel>> CreateTeacherSubject([FromBody] TeacherSubjectModel teacherSubjectModel)
        {
            if (teacherSubjectModel.TeacherId == 0)
            {
                try
                {
                    var createdTeacherSubject = await _teacherSubjectRepository.AddTeacherSubjectWithoutTeacherId(teacherSubjectModel.Code);
                    return CreatedAtAction(nameof(GetTeacherSubjectById), new { id = teacherSubjectModel.TeacherSubjectId}, teacherSubjectModel);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            try
            {
                var dbClassExists = await _teacherSubjectRepository.GetTeacherSubject(teacherSubjectModel.TeacherId, teacherSubjectModel.Code);
                if (dbClassExists is null)
                {
                    var createdTeacherSubject = await _teacherSubjectRepository.CreateTeacherSubject(teacherSubjectModel.TeacherId, teacherSubjectModel.Code);
                    return CreatedAtAction(nameof(GetTeacherSubjectById), new { id = createdTeacherSubject.TeacherSubjectId}, createdTeacherSubject);
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
        [HttpGet("multiplemapping")]
        public async Task<IActionResult> GetMultipleMapping()
        {
            try
            {
                var subjects = await _teacherSubjectRepository.GetSubjectsMultipleMapping();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("subjectteacherbyteacherId/{teacherId}")]
        public async Task<IActionResult> GetMultipleMappingByTeacher(int teacherId)
        {
            try
            {
                var subjects = await _teacherSubjectRepository.GetSubjectsMultipleMappingByTeacher(teacherId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("subjectteacherbysubjectCode/{subjectCode}")]
        public async Task<IActionResult> GetMultipleMappingBySubject(int subjectCode)
        {
            try
            {
                var subjects = await _teacherSubjectRepository.GetSubjectsMultipleMappingBySubject(subjectCode);
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
