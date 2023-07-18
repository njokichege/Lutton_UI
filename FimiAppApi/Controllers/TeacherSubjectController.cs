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
        [HttpPost]
        public async Task<IActionResult> CreateTeacherSubject(TeacherSubjectModel teacherSubjectModel)
        {
            try
            {
                var dbClassExists = await _teacherSubjectRepository.GetTeacherSubject(teacherSubjectModel.TeacherId, teacherSubjectModel.Code);
                if (dbClassExists is null)
                {
                    var createdTeacherSubject = await _teacherSubjectRepository.CreateTeacherSubject(teacherSubjectModel.TeacherId, teacherSubjectModel.Code);
                    return Ok(createdTeacherSubject);
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
        [HttpGet("MultipleMapping")]
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
        [HttpGet("{teacherId}")]
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
    }
}
