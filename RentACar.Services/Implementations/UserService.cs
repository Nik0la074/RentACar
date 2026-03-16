using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ApplicationUser> GetAll()
            => _db.Users.ToList();

        public ApplicationUser? GetById(string id)
            => _db.Users.Find(id);

        public void Update(ApplicationUser user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

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