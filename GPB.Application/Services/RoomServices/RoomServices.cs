using GPB.Application.Dtos.RoomDto;
using GPB.Application.Interface;
using GPB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPB.Application.Services.RoomServices
{
    public class RoomServices : IRoomServices
    {
        private readonly IRepository<Room> _repository;

        public RoomServices(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public async Task<ResultRoomDto> CreateRoomAsync(CreateRoomDto model)
        {
            var room = new Room
            {
                RoomId = model.RoomId,
                RoomNumber = model.RoomNumber,
                RoomType = model.RoomType,
                Price = model.Price,
                Status = model.Status,
                CreationDate = model.CreationDate,
                UpdateDate = model.UpdateDate,
            };

            await _repository.CreateAsync(room);

            return new ResultRoomDto
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomType=room.RoomType,
                Price = room.Price,
                Status = room.Status,
                CreationDate = room.CreationDate,
                UpdateDate = room.UpdateDate,
            };
        }

        public async Task<bool> DeleteRoomAsync(int roomId)
        {
            var room = await _repository.GetByIdAsync(roomId);
            if (room == null)
            {
                return false;
            }

            await _repository.DeleteAsync(room);
            return true;
        }

        public async Task<List<ResultRoomDto>> GetAllRoomAsync()
        {
            var rooms = await _repository.GetAllAsync();
            var result = new List<ResultRoomDto>();

            foreach (var room in rooms)
            {
                result.Add(new ResultRoomDto
                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    RoomType = room.RoomType,
                    Price = room.Price,
                    Status = room.Status,
                    CreationDate = room.CreationDate,
                    UpdateDate = room.UpdateDate,
                });
            }

            return result;
        }

        public async Task<ResultRoomDto> GetRoomByIdAsync(int roomId)
        {
            var room = await _repository.GetByIdAsync(roomId);
            if (room == null)
            {
                return null;
            }

            return new ResultRoomDto
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomType= room.RoomType,
                Price = room.Price,
                Status = room.Status,
                CreationDate = room.CreationDate,
                UpdateDate = room.UpdateDate,
            };
        }

        public async Task<ResultRoomDto> UpdateRoomAsync(UpdateRoomDto model)
        {
            var room = await _repository.GetByIdAsync(model.RoomId);
            if (room == null)
            {
                return null;
            }

            room.RoomNumber = model.RoomNumber;
            room.RoomType = model.RoomType;
            room.Price = model.Price;
            room.Status = model.Status;
            room.UpdateDate = model.UpdateDate;

            await _repository.UpdateAsync(room);

            return new ResultRoomDto
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomType = room.RoomType,
                Price = room.Price,
                Status = room.Status,
                CreationDate = room.CreationDate,
                UpdateDate = room.UpdateDate,
            };
        }
    }
}
