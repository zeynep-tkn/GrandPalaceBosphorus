namespace GPB.Domain.Entity
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }

        public string RoomType { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
