using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;
using RentACar.Web.ViewModels;

namespace RentACar.Web.Controllers
{
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

        // User sees their own reservations, Admin sees all
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

        // Search for available cars
        [HttpGet]
        public IActionResult Create()
        {
            return View(new SearchCarsViewModel());
        }

        [HttpPost]
        public IActionResult Search(SearchCarsViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Create", model);

            if (model.EndDate <= model.StartDate)
            {
                ModelState.AddModelError(string.Empty, "End date must be after start date");
                return View("Create", model);
            }

            model.AvailableCars = _carService.GetAvailableCars(model.StartDate, model.EndDate);
            return View("Create", model);
        }

        // Create reservation
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

        // Admin only - Approve reservation
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Approve(int id)
        {
            _reservationService.Approve(id);
            return RedirectToAction(nameof(Index));
        }

        // Admin only - Delete reservation
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _reservationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}