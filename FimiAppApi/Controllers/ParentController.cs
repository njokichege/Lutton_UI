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
        [HttpGet("{nationalId}")]
        public async Task<IActionResult> GetParentById(int nationalId)
        {
            try
            {
                var parent = await _parentRepository.GetParentById(nationalId);
                return Ok(parent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> CreateParent([FromBody] ParentModel parent)
        {
            try
            {
                if (parent is not null)
                {
                    var doesParentExist = await _parentRepository.GetParentById(parent.NationalId);
                    if(doesParentExist is null)
                    {
                        var rowChanged = await _parentRepository.CreateParent(parent);
                        if (rowChanged == 1)
                        {
                            return StatusCode(201, parent);
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    else
                    {
                        return Conflict();
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
