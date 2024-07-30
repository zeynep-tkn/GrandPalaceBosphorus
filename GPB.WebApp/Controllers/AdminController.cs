using GPB.Application.Dtos.AdminDto;
using GPB.Application.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPB.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        // GET api/admin
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminServices.GetAllAdminAsync();
            return Ok(admins);
        }

        // GET api/admin/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminServices.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        // POST api/admin
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminDto createAdminDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _adminServices.CreateAdminAsync(createAdminDto);
            return CreatedAtAction(nameof(GetAdminById), new { id = createAdminDto.AdminId }, createAdminDto);
        }

        // PUT api/admin/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] UpdateAdminDto updateAdminDto)
        {
            if (id != updateAdminDto.AdminId)
            {
                return BadRequest("Admin ID mismatch");
            }

            await _adminServices.UpdateAdminAsync(updateAdminDto);
            return NoContent();
        }

        // DELETE api/admin/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminServices.DeleteAdminAsync(id);
            return NoContent();
        }
    }
}
