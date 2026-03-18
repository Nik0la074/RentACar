namespace RentACar.Data.Models
{
    /// <summary>
    /// Represents a reservation made by a user for a specific car.
    /// </summary>
    public class Reservation
    {
        /// <summary>Unique identifier of the reservation.</summary>
        public int Id { get; set; }

        /// <summary>Foreign key referencing the reserved car.</summary>
        public int CarId { get; set; }

        /// <summary>Navigation property for the reserved car.</summary>
        public Car Car { get; set; } = null!;

        /// <summary>Foreign key referencing the user who made the reservation.</summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>Navigation property for the user who made the reservation.</summary>
        public ApplicationUser User { get; set; } = null!;

        /// <summary>Start date of the reservation.</summary>
        public DateTime StartDate { get; set; }

        /// <summary>End date of the reservation.</summary>
        public DateTime EndDate { get; set; }

        /// <summary>Indicates whether the reservation has been approved by an admin.</summary>
        public bool IsApproved { get; set; } = false;
    }
}