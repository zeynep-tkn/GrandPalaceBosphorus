using GPB.Application.Dtos.UserDto;
using GPB.Application.Interface;
using GPB.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPB.Application.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IRepository<User> repository)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(CreateUserDto model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, UserType = model.Role };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Kullanıcıya rol atama
                await _userManager.AddToRoleAsync(user, model.Role);

                // E-posta doğrulama token'i oluşturma
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                // Tokeni e-posta ile gönderme işlemi burada yapılmalı
                // Örnek: await _emailSender.SendEmailAsync(model.Email, "Hesabınızı Doğrulayın", $"Lütfen hesabınızı doğrulamak için <a href='{callbackUrl}'>buraya tıklayın</a>.");
            }

            return result;
        }

        public async Task<SignInResult> SignInUserAsync(CreateUserDto model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result;
        }

        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> PasswordSignInAsync(string email, string password, bool isPersistent, bool lockoutOnFailure)
        {
            throw new NotImplementedException();
        }



        public async Task CreateUserAsync(CreateUserDto model)
      {
      if (string.IsNullOrWhiteSpace(model.Role))
      {
        throw new ArgumentException("Role cannot be null or empty");
      }

    var user = new User
    {
        UserId = model.UserId,
        UserName = model.UserName,
        Role = model.Role,
        CreationDate = model.CreationDate,
        UpdateDate = model.UpdateDate,
        Guests = model.Guests?.Select(g => new Guest
        {
            GuestId = g.GuestId,
            TcNumber = g.TcNumber,
            Username = g.Username,
            Password = g.Password,
            Email = g.Email
            }).ToList(),
            Admins = model.Admins?.Select(a => new Admin
            {
            AdminId = a.AdminId,
            UserName = a.UserName,
            Password = a.Password,
            Mail = a.Mail
            }).ToList()
           };

             await _repository.CreateAsync(user);
           }

      public async Task<GetByIdUserDto> GetUserByIdAsync(int userId)
     {
       var user = await _repository.GetByIdAsync(userId);



       return new GetByIdUserDto
        {
        UserId = user.UserId,
        UserName = user.UserName,
        Role = user.Role,
        CreationDate = user.CreationDate,
        UpdateDate = user.UpdateDate,
        Guests = user.Guests?.Select(g => new Guest
        {
            GuestId = g.GuestId,
            TcNumber = g.TcNumber,
            Username = g.Username,
            Password = g.Password,
            Email = g.Email
        }).ToList(),
        Admins = user.Admins?.Select(a => new Admin
        {
            AdminId = a.AdminId,
            UserName = a.UserName,
            Password = a.Password,
            Mail = a.Mail
        }).ToList()
         };
        }

     public async Task<List<ResultUserDto>> GetAllUserAsync()
     {
       var users = await _repository.GetAllAsync();
       var result = new List<ResultUserDto>();

         foreach (var user in users)
          {
          result.Add(new ResultUserDto
          {
            UserId = user.UserId,
            UserName = user.UserName,
            Role = user.Role,
            CreationDate = user.CreationDate,
            UpdateDate = user.UpdateDate,
            Guests = user.Guests?.Select(g => new Guest
            {
                GuestId = g.GuestId,
                TcNumber = g.TcNumber,
                Username = g.Username,
                Password = g.Password,
                Email = g.Email
            }).ToList(),
            Admins = user.Admins?.Select(a => new Admin
            {
                AdminId = a.AdminId,
                UserName = a.UserName,
                Password = a.Password,
                Mail = a.Mail
            }).ToList()
           });
          }

        return result;
           }

public async Task<ResultUserDto> UpdateUserAsync(UpdateUserDto model)
{
    var user = await _repository.GetByIdAsync(model.UserId);


    user.UserName = model.UserName;
    user.Role = model.Role;
    user.CreationDate = model.CreationDate;
    user.UpdateDate = model.UpdateDate;

    user.Guests = model.Guests?.Select(g => new Guest
    {
        GuestId = g.GuestId,
        TcNumber = g.TcNumber,
        Username = g.Username,
        Password = g.Password,
        Email = g.Email
    }).ToList();
    user.Admins = model.Admins?.Select(a => new Admin
    {
        AdminId = a.AdminId,
        UserName = a.UserName,
        Password = a.Password,
        Mail = a.Mail
    }).ToList();

    await _repository.UpdateAsync(user);

    return new ResultUserDto
    {
        UserId = user.UserId,
        UserName = user.UserName,
        Role = user.Role,
        CreationDate = user.CreationDate,
        UpdateDate = user.UpdateDate,
        Guests = user.Guests?.Select(g => new Guest
        {
            GuestId = g.GuestId,
            TcNumber = g.TcNumber,
            Username = g.Username,
            Password = g.Password,
            Email = g.Email
        }).ToList(),
        Admins = user.Admins?.Select(a => new Admin
        {
            AdminId = a.AdminId,
            UserName = a.UserName,
            Password = a.Password,
            Mail = a.Mail
        }).ToList()
    };
}

public async Task DeleteUserAsync(int userId)
{
    var user = await _repository.GetByIdAsync(userId);

    {
        await _repository.DeleteAsync(user);
    }
}

        
    }
} 