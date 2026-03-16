using RentACar.Data.Models;

namespace RentACar.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser? GetById(string id);
        void Update(ApplicationUser user);
        void Delete(string id);
    }
}