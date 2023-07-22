using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/subjectcategory")]
    [ApiController]
    public class SubjectCategoryController : ControllerBase
    {
        private readonly ISubjectCategoryRepository _subjectCategoryRepository;

        public SubjectCategoryController(ISubjectCategoryRepository subjectCategoryRepository)
        {
            _subjectCategoryRepository = subjectCategoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSubjectCategories()
        {
            try
            {
                var subjectCategories = await _subjectCategoryRepository.GetCategories();
                return Ok(subjectCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
