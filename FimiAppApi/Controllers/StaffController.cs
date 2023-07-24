using Microsoft.AspNetCore.Mvc;

namespace FimiAppApi.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffModel staff)
        {
            try
            {
                var dbStaffExists = await _staffRepository.GetStaff(staff.NationalId);
                if (dbStaffExists is null)
                {
                    var createdStaff = await _staffRepository.AddStaff(staff);
                    return Ok(createdStaff);
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
    }
}
