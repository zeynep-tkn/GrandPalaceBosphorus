using System.Collections.Generic;
using System.Threading.Tasks;
using GPB.Application.Dtos.UserDto;
using GPB.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace GPB.Application.Services
{
    public interface IUserServices
    {
        Task CreateUserAsync(CreateUserDto model);
        Task<GetByIdUserDto> GetUserByIdAsync(int userId);
        Task<List<ResultUserDto>> GetAllUserAsync();
        Task<ResultUserDto> UpdateUserAsync(UpdateUserDto model);
        Task DeleteUserAsync(int userId);


        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool isPersistent, bool lockoutOnFailure);
    }
}
