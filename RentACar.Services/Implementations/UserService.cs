using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Services.Implementations
{
    /// <summary>
    /// Service for managing user-related operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>Returns all users in the system.</summary>
        public IEnumerable<ApplicationUser> GetAll()
            => _db.Users.ToList();

        /// <summary>Returns a user by their ID, or null if not found.</summary>
        public ApplicationUser? GetById(string id)
            => _db.Users.Find(id);

        /// <summary>Updates an existing user in the database.</summary>
        public void Update(ApplicationUser user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        /// <summary>Deletes a user by their ID.</summary>
        public void Delete(string id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }
    }
}