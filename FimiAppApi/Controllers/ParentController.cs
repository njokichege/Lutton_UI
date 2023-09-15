using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/parent")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _parentRepository;

        public ParentController(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetParents()
        {
            try
            {
                var parents = await _parentRepository.GetParents();
                return Ok(parents);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentById(int id)
        {
            try
            {
                var parent = await _parentRepository.GetParentById(id);
                return Ok(parent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateParent([FromBody] ParentModel parent)
        {
            try
            {
                if (parent is not null)
                {
                    var doesParentExist = await _parentRepository.GetParentById(parent.NationalId);
                    if(doesParentExist is null)
                    {
                        var parentEntry = await _parentRepository.CreateParent(parent);
                        return CreatedAtAction(nameof(GetParentById),new {id = parentEntry.NationalId},parentEntry);
                        
                    }
                    else
                    {
                        return Conflict();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
