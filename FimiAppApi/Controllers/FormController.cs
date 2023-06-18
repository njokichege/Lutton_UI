using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/form")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormRepository formRepository;

        public FormController(IFormRepository formRepository)
        {
            this.formRepository = formRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            var forms = await formRepository.GetForms();
            return Ok(forms);
        }
    }
}
