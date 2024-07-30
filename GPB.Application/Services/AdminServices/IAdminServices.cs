using GPB.Application.Dtos.AdminDto;

namespace GPB.Application.Services.AdminServices
{
    public interface IAdminServices
    {
        Task CreateAdminAsync(CreateAdminDto model);
        Task<GetByIdAdminDto> GetAdminByIdAsync(int AdminId);
        Task<List<ResultAdminDto>> GetAllAdminAsync();
        Task UpdateAdminAsync(UpdateAdminDto model);
        Task DeleteAdminAsync(int AdminId);
    }
}
