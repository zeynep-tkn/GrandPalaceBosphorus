using GPB.Application.Dtos.AdminDto;
using GPB.Application.Interface;
using GPB.Domain.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPB.Application.Services.AdminServices
{
    public class AdminServices : IAdminServices
    {
        private readonly IRepository<Admin> _repository;

        public AdminServices(IRepository<Admin> repository)
        {
            _repository = repository;
        }
        public async Task CreateAdminAsync(CreateAdminDto model)
        {
            var Admin = new Admin
            {
                AdminId = model.AdminId,
                UserName = model.UserName,
                Password = model.Password,
                Mail = model.Mail,
              
            };

            await _repository.CreateAsync(Admin);

        }

        public async Task DeleteAdminAsync(int adminId)
        {
            var admin = await _repository.GetByIdAsync(adminId);
            await _repository.DeleteAsync(admin);
            
        }


        public async Task<List<ResultAdminDto>> GetAllAdminAsync()
        {
            var admins = await _repository.GetAllAsync();
            var result = new List<ResultAdminDto>();

            foreach (var admin in admins)
            {
                result.Add(new ResultAdminDto
                {
                    AdminId = admin.AdminId,
                    UserName = admin.UserName,
                    Password = admin.Password,
                    Mail = admin.Mail,
                });
            }

            return result;
        }


        public async Task<GetByIdAdminDto> GetAdminByIdAsync(int adminId)
        {
            var admin = await _repository.GetByIdAsync(adminId);
            var result = new GetByIdAdminDto
            {
                AdminId = admin.AdminId,
                UserName = admin.UserName,
                Password = admin.Password,
                Mail = admin.Mail,
            };

            return result;
            
            
        }

        public async Task UpdateAdminAsync(UpdateAdminDto model)
        {
            var admin = await _repository.GetByIdAsync(model.AdminId);

            admin.UserName = model.UserName;
            admin.Password = model.Password;
            admin.Mail = model.Mail;

            await _repository.UpdateAsync(admin);

        }
    }
}
