using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _db;

        public ReservationService(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Reservation> GetAll()
            => _db.Reservations
                .Include(r => r.Car)
                .Include(r => r.User)
                .ToList();

        public IEnumerable<Reservation> GetByUser(string userId)
            => _db.Reservations
                .Include(r => r.Car)
                .Where(r => r.UserId == userId)
                .ToList();

        public Reservation? GetById(int id)
            => _db.Reservations
                .Include(r => r.Car)
                .Include(r => r.User)
                .FirstOrDefault(r => r.Id == id);

        public void Create(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
        }

        public void Approve(int id)
        {
            var reservation = _db.Reservations.Find(id);
            if (reservation != null)
            {
                reservation.IsApproved = true;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var reservation = _db.Reservations.Find(id);
            if (reservation != null)
            {
                _db.Reservations.Remove(reservation);
                _db.SaveChanges();
            }
        }
    }
}