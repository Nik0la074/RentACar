using System.ComponentModel.DataAnnotations;

namespace RentACar.Web.ViewModels
{
    /// <summary>
    /// ViewModel for searching available cars by date range.
    /// </summary>
    public class SearchCarsViewModel
    {
        /// <summary>Start date of the rental period.</summary>
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        /// <summary>End date of the rental period.</summary>
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(1);

        /// <summary>List of cars available for the selected date range.</summary>
        public IEnumerable<RentACar.Data.Models.Car> AvailableCars { get; set; }
            = new List<RentACar.Data.Models.Car>();
    }
}