using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.ViewModels
{
    /// <summary>
    /// ViewModel for creating a new reservation.
    /// </summary>
    public class CreateReservationViewModel
    {
        /// <summary>ID of the selected car.</summary>
        [Required]
        public int CarId { get; set; }

        /// <summary>Start date of the reservation.</summary>
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        /// <summary>End date of the reservation.</summary>
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
    }
}