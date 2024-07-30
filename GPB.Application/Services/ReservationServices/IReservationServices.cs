using GPB.Application.Dtos.GuestDto;
using GPB.Application.Dtos.ReservationDtos;

namespace GPB.Application.Services.ReservationServices
{
    public interface IReservationServices
    {
        Task CreateReservationAsync(CreateReservationDto model);
        Task<GetByIdReservationDto> GetReservationByIdAsync(int reservationId);
        Task<List<ResultReservationDto>> GetAllReservationAsync();
        Task UpdateReservationAsync(UpdateReservationDto model);
        Task DeleteReservationAsync(int reservationId);

    }
}