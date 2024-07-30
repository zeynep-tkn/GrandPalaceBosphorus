namespace GPB.Application.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public int ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string RoomType { get; set; }
        public int StayDuration { get; set; }
        public string PaymentMethod { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime CardExpiry { get; set; }
        public string CardCVV { get; set; }
        public string SpecialRequests { get; set; }
    }
}
