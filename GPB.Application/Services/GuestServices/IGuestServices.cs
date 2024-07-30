using GPB.Application.Dtos.EntryExitDto;
using GPB.Application.Dtos.GuestDto;
using System.Collections.Generic;

namespace GPB.Application.Services.GuestServices
{
    public interface IGuestServices
    {
        Task CreateGuestAsync(CreateGuestDto model);
        Task<GetByIdGuestDto> GetGuestByIdAsync(int guestId);
        Task<List<ResultGuestDto>> GetAllGuestAsync();
        Task UpdateGuestAsync(UpdateGuestDto model);
        Task DeleteGuestAsync(int guestId);
    }
}