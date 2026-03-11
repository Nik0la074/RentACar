namespace RentACar.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Seats { get; set; }
        public string? Description { get; set; }
        public decimal PricePerDay { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}