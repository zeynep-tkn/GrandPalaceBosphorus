using GPB.Application.Dtos.GuestDto;
using GPB.Application.Interface;
using GPB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GPB.Application.Services.GuestServices
{
    public class GuestServices : IGuestServices
    {
        private readonly IRepository<Guest> _repository;

        public GuestServices(IRepository<Guest> repository)
        {
            _repository = repository;
        }

        public async Task CreateGuestAsync(CreateGuestDto model)
        {
            var guest = new Guest
            {
                GuestId = model.GuestId,
                TcNumber = model.TcNumber,
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
            };

            await _repository.CreateAsync(guest);
        }


        public async Task DeleteGuestAsync(int guestId)
        {
            // Assuming there's a way to get a Guest by its TcNumber directly from the repository
            var guest = await _repository.GetByIdAsync(guestId); // Ensure this method exists
            await _repository.DeleteAsync(guest);
        }


        public async Task<List<ResultGuestDto>> GetAllGuestAsync()
        {
            var guests = await _repository.GetAllAsync();

            var guestDtos = guests.Select(guest => new ResultGuestDto
            {
                GuestId = guest.GuestId,
                TcNumber = guest.TcNumber,
                Username = guest.Username,
                Password = guest.Password,
                Email = guest.Email,
            }).ToList();

            return guestDtos;
        }

        public async Task<GetByIdGuestDto> GetGuestByIdAsync(int guestId)
        {
            var guest = await _repository.GetByIdAsync(guestId); // Ensure this method exists

            if (guest == null)
            {
                return null; // Or you can throw an exception depending on your use case
            }

            return new GetByIdGuestDto
            {
                GuestId = guest.GuestId,
                TcNumber = guest.TcNumber,
                Username = guest.Username,
                Password = guest.Password,
                Email = guest.Email,
            };
        }



        public async Task UpdateGuestAsync(UpdateGuestDto model)
        {
            var guest = await _repository.GetByIdAsync(model.GuestId);

            guest.TcNumber = model.TcNumber;
            guest.Username = model.Username;
            guest.Password = model.Password;
            guest.Email = model.Email;

            await _repository.UpdateAsync(guest);

        }
    }
}