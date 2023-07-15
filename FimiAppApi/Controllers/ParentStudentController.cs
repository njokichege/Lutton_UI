using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/parentstudent")]
    [ApiController]
    public class ParentStudentController : ControllerBase
    {
        private readonly IParentStudentRepository _parentStudentRepository;

        public ParentStudentController(IParentStudentRepository parentStudentRepository)
        {
            _parentStudentRepository = parentStudentRepository;
        }
        [HttpPost]
        public async Task<ActionResult> AddParentStudent(ParentModel parent)
        {
            try
            {
                if (parent is not null)
                {
                    var rowChanged = await _parentStudentRepository.AddParentStudent(parent.NationalId);
                    if (rowChanged == 1)
                    {
                        return StatusCode(201);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
