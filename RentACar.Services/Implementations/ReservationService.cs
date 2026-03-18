using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Services.Implementations
{
    /// <summary>
    /// Service for managing reservation-related operations.
    /// </summary>
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _db;

        public ReservationService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>Returns all reservations including car and user details.</summary>
        public IEnumerable<Reservation> GetAll()
            => _db.Reservations
                .Include(r => r.Car)
                .Include(r => r.User)
                .ToList();

        /// <summary>Returns all reservations made by a specific user.</summary>
        public IEnumerable<Reservation> GetByUser(string userId)
            => _db.Reservations
                .Include(r => r.Car)
                .Where(r => r.UserId == userId)
                .ToList();

        /// <summary>Returns a reservation by its ID, or null if not found.</summary>
        public Reservation? GetById(int id)
            => _db.Reservations
                .Include(r => r.Car)
                .Include(r => r.User)
                .FirstOrDefault(r => r.Id == id);

        /// <summary>Creates a new reservation in the database.</summary>
        public void Create(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
        }

        /// <summary>Approves a reservation by its ID.</summary>
        public void Approve(int id)
        {
            var reservation = _db.Reservations.Find(id);
            if (reservation != null)
            {
                reservation.IsApproved = true;
                _db.SaveChanges();
            }
        }

        /// <summary>Deletes a reservation by its ID.</summary>
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