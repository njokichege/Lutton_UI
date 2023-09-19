using FimiAppLibrary.Models;
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
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            try
            {
                var staff = await _staffRepository.GetStaffById(id);
                return Ok(staff);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddStaff(StaffModel staff)
        {
            try
            {
                var dbStaffExists = await _staffRepository.GetStaffById(staff.NationalId);
                if (dbStaffExists is null)
                {
                    var createdStaff = await _staffRepository.AddStaff(staff);
                    return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.NationalId }, createdStaff);
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
