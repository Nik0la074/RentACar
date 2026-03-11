using Microsoft.AspNetCore.Identity;
using RentACar.Data.Models;

namespace RentACar.Data.Seeding
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

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