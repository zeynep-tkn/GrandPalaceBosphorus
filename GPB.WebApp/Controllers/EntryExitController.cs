using GPB.Application.Dtos.EntryExitDto;
using GPB.Application.Services.EntryExitServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPB.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryExitController : ControllerBase
    {
        private readonly IEntryExitServices _entryExitServices;

        public EntryExitController(IEntryExitServices entryExitServices)
        {
            _entryExitServices = entryExitServices;
        }

        // GET api/entryexit
        [HttpGet]
        public async Task<IActionResult> GetAllEntryExits()
        {
            var entryExits = await _entryExitServices.GetAllEntryExitAsync();
            return Ok(entryExits);
        }

        // GET api/entryexit/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntryExitById(int id)
        {
            var entryExit = await _entryExitServices.GetEntryExitByIdAsync(id);
            if (entryExit == null)
            {
                return NotFound();
            }
            return Ok(entryExit);
        }

        // POST api/entryexit
        [HttpPost]
        public async Task<IActionResult> CreateEntryExit([FromBody] CreateEntryExitDto createEntryExitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _entryExitServices.CreateEntryExitAsync(createEntryExitDto);
            return CreatedAtAction(nameof(GetEntryExitById), new { id = createEntryExitDto.EntryExitId }, createEntryExitDto);
        }

        // PUT api/entryexit/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntryExit(int id, [FromBody] UpdateEntryExitDto updateEntryExitDto)
        {
            if (id != updateEntryExitDto.EntryExitId)
            {
                return BadRequest("EntryExit ID mismatch");
            }

            await _entryExitServices.UpdateEntryExitAsync(updateEntryExitDto);
            return NoContent();
        }

        // DELETE api/entryexit/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntryExit(int id)
        {
            await _entryExitServices.DeleteEntryExitAsync(id);
            return NoContent();
        }
    }
}

