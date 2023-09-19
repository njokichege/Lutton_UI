using FimiAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSubjectId(int id)
        {
            try
            {
                var subject = await _subjectRepository.GetSubjectId(id);
                return Ok(subject);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            try
            {
                var subjects = await _subjectRepository.GetSubjects();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateSubject(SubjectModel subjectModel)
        {
            try
            {
                var dbSubjectExists = await _subjectRepository.GetSubjectId(subjectModel.Code);
                if (dbSubjectExists is null)
                {
                    var createdSubject = await _subjectRepository.CreateSubject(subjectModel.Code, subjectModel.SubjectName, subjectModel.SubjectCategory.SubjectCategoryId);
                    return CreatedAtAction(nameof(GetSubjectId), new { id = createdSubject.Code }, createdSubject);
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
        [HttpGet("mapsubjectoncategory")]
        public async Task<IActionResult> MapSubjectOnCategory()
        {
            try
            {
                var subjects = await _subjectRepository.MapSubjectOnCategory();
                return Ok(subjects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
