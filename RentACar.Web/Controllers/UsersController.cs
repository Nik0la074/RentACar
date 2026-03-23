using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;
using RentACar.Web.ViewModels;

namespace RentACar.Web.Controllers
{
    /// <summary>
    /// Handles user management. Accessible by Admin only.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(
            IUserService userService,
            UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        /// <summary>Displays a list of all users. Admin only.</summary>
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        /// <summary>Displays the form for creating a new user. Admin only.</summary>
        [HttpGet]
        public IActionResult Create() => View();

        /// <summary>Processes the form and creates a new user. Admin only.</summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EGN = model.EGN,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        /// <summary>Displays the form for editing a user. Admin only.</summary>
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        /// <summary>Processes the form and updates the user. Admin only.</summary>
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            var user = _userService.GetById(model.Id);
            if (user == null) return NotFound();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;

            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Deletes a user by ID. Admin only.</summary>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}