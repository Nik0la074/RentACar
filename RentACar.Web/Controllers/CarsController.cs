using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Web.Controllers
{
    /// <summary>
    /// Handles car management including listing, creating, editing and deleting cars.
    /// </summary>
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>Displays a list of all cars. Accessible by all authenticated users.</summary>
        [Authorize]
        public IActionResult Index()
        {
            var cars = _carService.GetAll();
            return View(cars);
        }

        /// <summary>Displays the form for adding a new car. Admin only.</summary>
        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        /// <summary>Processes the form and adds a new car. Admin only.</summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
                return View(car);

            _carService.Add(car);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Displays the form for editing a car. Admin only.</summary>
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var car = _carService.GetById(id);
            if (car == null) return NotFound();
            return View(car);
        }

        /// <summary>Processes the form and updates the car. Admin only.</summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
                return View(car);

            _carService.Update(car);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Displays the confirmation page for deleting a car. Admin only.</summary>
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var car = _carService.GetById(id);
            if (car == null) return NotFound();
            return View(car);
        }

        /// <summary>Deletes the car after confirmation. Admin only.</summary>
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Displays the booked periods for a specific car.</summary>
        [Authorize]
        public IActionResult Schedule(int id)
        {
            var car = _carService.GetById(id);
            if (car == null) return NotFound();

            var bookedPeriods = _carService.GetBookedPeriods(id);

            ViewBag.Car = car;
            return View(bookedPeriods);
        }
    }
}