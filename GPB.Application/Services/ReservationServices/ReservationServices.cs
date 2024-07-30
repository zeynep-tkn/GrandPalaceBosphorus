using GPB.Application.Dtos.ReservationDtos;
using GPB.Application.Interface;
using GPB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace GPB.Application.Services.ReservationServices
{
    public class ReservationServices : IReservationServices
    {
        private readonly IRepository<Reservation> _repository;

        public ReservationServices(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task CreateReservationAsync(CreateReservationDto model)
        {
            var reservation = new Reservation
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                RoomType = model.RoomType,
                StayDuration = model.StayDuration,
                PaymentMethod = model.PaymentMethod,
                CreditCardNumber = model.CreditCardNumber,
                CardExpiry = model.CardExpiry,
                CardCVV = model.CardCVV,
                SpecialRequests = model.SpecialRequests
            };

            await _repository.CreateAsync(reservation);
        }

        public async Task<GetByIdReservationDto> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                return null; // veya bir hata fırlatabilirsiniz
            }

            return new GetByIdReservationDto
            {
                ReservationId = reservation.ReservationId,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Email = reservation.Email,
                Phone = reservation.Phone,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                RoomType = reservation.RoomType,
                StayDuration = reservation.StayDuration,
                PaymentMethod = reservation.PaymentMethod,
                CreditCardNumber = reservation.CreditCardNumber,
                CardExpiry = reservation.CardExpiry,
                CardCVV = reservation.CardCVV,
                SpecialRequests = reservation.SpecialRequests
            };
        }

        public async Task<List<ResultReservationDto>> GetAllReservationAsync()
        {
            var reservations = await _repository.GetAllAsync();
            var result = new List<ResultReservationDto>();

            foreach (var reservation in reservations)
            {
                result.Add(new ResultReservationDto
                {
                    FirstName = reservation.FirstName,
                    LastName = reservation.LastName,
                    Email = reservation.Email,
                    Phone = reservation.Phone,
                    CheckInDate = reservation.CheckInDate,
                    CheckOutDate = reservation.CheckOutDate,
                    RoomType = reservation.RoomType,
                    StayDuration = reservation.StayDuration,
                    PaymentMethod = reservation.PaymentMethod,
                    CreditCardNumber = reservation.CreditCardNumber,
                    CardExpiry = reservation.CardExpiry,
                    CardCVV = reservation.CardCVV,
                    SpecialRequests = reservation.SpecialRequests
                });
            }

            return result;
        }

        public async Task UpdateReservationAsync(UpdateReservationDto model)
        {
            var reservation = await _repository.GetByIdAsync(model.ReservationId);
            if (reservation == null)
            {
                return; // veya bir hata fırlatabilirsiniz
            }

            reservation.FirstName = model.FirstName;
            reservation.LastName = model.LastName;
            reservation.Email = model.Email;
            reservation.Phone = model.Phone;
            reservation.CheckInDate = model.CheckInDate;
            reservation.CheckOutDate = model.CheckOutDate;
            reservation.RoomType = model.RoomType;
            reservation.StayDuration = model.StayDuration;
            reservation.PaymentMethod = model.PaymentMethod;
            reservation.CreditCardNumber = model.CreditCardNumber;
            reservation.CardExpiry = model.CardExpiry;
            reservation.CardCVV = model.CardCVV;
            reservation.SpecialRequests = model.SpecialRequests;

            await _repository.UpdateAsync(reservation);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _repository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                return; // veya bir hata fırlatabilirsiniz
            }

            await _repository.DeleteAsync(reservation);
        }
    }
}
