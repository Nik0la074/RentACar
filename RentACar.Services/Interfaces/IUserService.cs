using RentACar.Data.Models;

namespace RentACar.Services.Interfaces
{
    /// <summary>
    /// Defines operations for managing users in the system.
    /// </summary>
    public interface IUserService
    {
        /// <summary>Returns all users.</summary>
        IEnumerable<ApplicationUser> GetAll();

        /// <summary>Returns a user by their ID, or null if not found.</summary>
        ApplicationUser? GetById(string id);

        /// <summary>Updates an existing user.</summary>
        void Update(ApplicationUser user);

        /// <summary>Deletes a user by their ID.</summary>
        void Delete(string id);
    }
}