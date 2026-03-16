using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // All users can see the list
        [Authorize]
        public IActionResult Index()
        {
            var cars = _carService.GetAll();
            return View(cars);
        }

        // Only Admin can create
        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
                return View(car);

            _carService.Add(car);
            return RedirectToAction(nameof(Index));
        }

        // Only Admin can edit
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var car = _carService.GetById(id);
            if (car == null) return NotFound();
            return View(car);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
                return View(car);

            _carService.Update(car);
            return RedirectToAction(nameof(Index));
        }

        // Only Admin can delete
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var car = _carService.GetById(id);
            if (car == null) return NotFound();
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}