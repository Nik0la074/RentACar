namespace RentACar.Data.Models
{
    /// <summary>
    /// Represents a car available for rent in the system.
    /// </summary>
    public class Car
    {
        /// <summary>Unique identifier of the car.</summary>
        public int Id { get; set; }

        /// <summary>Brand/manufacturer of the car.</summary>
        public string Brand { get; set; } = string.Empty;

        /// <summary>Model name of the car.</summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>Manufacturing year of the car.</summary>
        public int Year { get; set; }

        /// <summary>Number of passenger seats.</summary>
        public int Seats { get; set; }

        /// <summary>Optional technical description of the car.</summary>
        public string? Description { get; set; }

        /// <summary>Rental price per day in BGN.</summary>
        public decimal PricePerDay { get; set; }

        /// <summary>Collection of reservations associated with this car.</summary>
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}