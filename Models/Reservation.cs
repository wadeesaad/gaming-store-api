namespace GamingStoreApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int PlaceId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CustomerId { get; set; }
    }
}