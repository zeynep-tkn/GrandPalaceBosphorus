using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GPB.Application.Dtos.UserDto;
using GPB.Application.Interface;
using GPB.Application.Services;

namespace GPB.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // Kullanıcı oluşturma
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto model)
        {
            if (model == null)
            {
                return BadRequest("Kullanıcı verisi boş olamaz.");
            }

            await _userServices.CreateUserAsync(model);

            // Kullanıcı oluşturulduktan sonra başarılı bir yanıt döner
            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }

        // Kullanıcıyı ID'ye göre alma
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Tüm kullanıcıları listeleme
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userServices.GetAllUserAsync();
            return Ok(users);
        }

        // Kullanıcıyı güncelleme
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserDto model)
        {
            if (model == null)
            {
                return BadRequest("Güncellenmek üzere sağlanan veri boş olamaz.");
            }

            var updatedUser = await _userServices.UpdateUserAsync(model);
            if (updatedUser == null)
            {
                return NotFound("Kullanıcı bulunamadı veya güncellenemedi.");
            }

            return Ok(updatedUser);
        }

        // Kullanıcıyı silme
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            await _userServices.DeleteUserAsync(id);

            // İşlem başarılı ise NoContent döndür
            return NoContent();
        }
    }
}
