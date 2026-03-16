using RentACar.Data.Models;

namespace RentACar.Services.Interfaces
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll();
        IEnumerable<Reservation> GetByUser(string userId);
        Reservation? GetById(int id);
        void Create(Reservation reservation);
        void Approve(int id);
        void Delete(int id);
    }
}