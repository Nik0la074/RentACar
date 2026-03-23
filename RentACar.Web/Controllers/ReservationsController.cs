using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;
using RentACar.Web.ViewModels;

namespace RentACar.Web.Controllers
{
    /// <summary>
    /// Handles reservation management including searching, creating and approving reservations.
    /// </summary>
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ICarService _carService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(
            IReservationService reservationService,
            ICarService carService,
            UserManager<ApplicationUser> userManager)
        {
            _reservationService = reservationService;
            _carService = carService;
            _userManager = userManager;
        }

        /// <summary>Displays reservations. Admin sees all, User sees only their own.</summary>
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var allReservations = _reservationService.GetAll();
                return View(allReservations);
            }

            var userId = _userManager.GetUserId(User);
            var userReservations = _reservationService.GetByUser(userId!);
            return View(userReservations);
        }

        /// <summary>Displays the search form for available cars.</summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View(new SearchCarsViewModel());
        }

        /// <summary>Searches for available cars based on selected dates.</summary>
        [HttpPost]
        public IActionResult Search(SearchCarsViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Create", model);

            // Prevent reservations with past dates
            if (model.StartDate < DateTime.Today)
            {
                ModelState.AddModelError(string.Empty, "Start date cannot be in the past");
                return View("Create", model);
            }

            if (model.EndDate <= model.StartDate)
            {
                ModelState.AddModelError(string.Empty, "End date must be after start date");
                return View("Create", model);
            }

            model.AvailableCars = _carService.GetAvailableCars(model.StartDate, model.EndDate);
            return View("Create", model);
        }

        /// <summary>Creates a new reservation for the selected car and dates.</summary>
        [HttpPost]
        public IActionResult Reserve(CreateReservationViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Create));

            var userId = _userManager.GetUserId(User);

            var reservation = new Reservation
            {
                CarId = model.CarId,
                UserId = userId!,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsApproved = false
            };

            _reservationService.Create(reservation);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Approves a reservation. Admin only.</summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Approve(int id)
        {
            _reservationService.Approve(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Deletes a reservation. Admin only.</summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _reservationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}