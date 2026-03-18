using Microsoft.AspNetCore.Identity;
using RentACar.Data.Models;

namespace RentACar.Data.Seeding
{
    /// <summary>
    /// Handles the initial seeding of roles and admin user in the database.
    /// </summary>
    public static class DbSeeder
    {
        /// <summary>
        /// Seeds the database with default roles and an admin user if they do not already exist.
        /// </summary>
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Create Admin role if it does not exist
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            // Create User role if it does not exist
            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            // Create default admin user if it does not exist
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@rentacar.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    EGN = "0000000000",
                    PhoneNumber = "0000000000",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Admin@123");

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}