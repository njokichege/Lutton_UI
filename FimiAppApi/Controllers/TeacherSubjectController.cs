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
            if (teacherSubjectModel.TeacherId == 0)
            {
                try
                {
                    var createdTeacherSubject = await _teacherSubjectRepository.AddTeacherSubjectWithoutTeacherId(teacherSubjectModel.Code);
                    return Ok(createdTeacherSubject);
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
