using GPB.Application.Dtos.GuestDto;
using GPB.Application.Interface;
using GPB.Application.Services.GuestServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPB.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestServices _guestServices;

        public GuestController(IGuestServices guestServices)
        {
            _guestServices = guestServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest(CreateGuestDto model)
        {
            if (model == null)
            {
                return BadRequest("Invalid guest data.");
            }

            await _guestServices.CreateGuestAsync(model);
            return Ok("Guest created successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGuest(int guestId)
        {
            var guest = await _guestServices.GetGuestByIdAsync(guestId);
            if (guest == null)
            {
                return NotFound("Guest not found.");
            }

            await _guestServices.DeleteGuestAsync(guestId);
            return Ok("Guest deleted successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestServices.GetAllGuestAsync();
            return Ok(guests);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGuestById(int guestId)
        {
            var guest = await _guestServices.GetGuestByIdAsync(guestId);
            if (guest == null)
            {
                return NotFound("Guest not found.");
            }

            return Ok(guest);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGuest([FromBody] UpdateGuestDto model)
        {
            if (model == null)
            {
                return BadRequest("Invalid guest data.");
            }

            var existingGuest = await _guestServices.GetGuestByIdAsync(model.GuestId);
            if (existingGuest == null)
            {
                return NotFound("Guest not found.");
            }

            await _guestServices.UpdateGuestAsync(model);
            return Ok("Guest updated successfully.");
        }
    }
}

