using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/form")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormRepository _formRepository;

        public FormController(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            try
            {
                var forms = await _formRepository.GetForms();
                return Ok(forms);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{FormId}")]
        public async Task<IActionResult> GetFormById(int formId)
        {
            try
            {
                var form = await _formRepository.GetFormById(formId);
                return Ok(form);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
    }
}
