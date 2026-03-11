namespace RentACar.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}