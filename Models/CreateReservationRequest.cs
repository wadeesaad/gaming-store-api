namespace GamingStoreApi.Models
{
    public class CreateReservationRequest
    {
        public int PlaceId { get; set; }

        public string CustomerName { get; set; } = "";

        public string CustomerPhone { get; set; } = "";

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal TotalPrice { get; set; }
    }
}