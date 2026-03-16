using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.ViewModels
{
    public class SearchCarsViewModel
    {
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1);

        public IEnumerable<RentACar.Data.Models.Car> AvailableCars { get; set; }
            = new List<RentACar.Data.Models.Car>();
    }
}