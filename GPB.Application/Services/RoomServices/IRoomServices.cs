using GPB.Application.Dtos.RoomDto;

namespace GPB.Application.Services.RoomServices
{
    public interface IRoomServices
    {
        Task<ResultRoomDto> CreateRoomAsync(CreateRoomDto model);
        Task<ResultRoomDto> GetRoomByIdAsync(int RoomId);
        Task<List<ResultRoomDto>> GetAllRoomAsync();
        Task<ResultRoomDto> UpdateRoomAsync(UpdateRoomDto model);
        Task<bool> DeleteRoomAsync(int RoomId);
    }
}