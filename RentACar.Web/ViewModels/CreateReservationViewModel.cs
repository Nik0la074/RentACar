using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.ViewModels
{
    public class CreateReservationViewModel
    {
        [Required]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
    }
}