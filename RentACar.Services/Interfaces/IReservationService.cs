using RentACar.Data.Models;

namespace RentACar.Services.Interfaces
{
    /// <summary>
    /// Defines operations for managing reservations in the system.
    /// </summary>
    public interface IReservationService
    {
        /// <summary>Returns all reservations.</summary>
        IEnumerable<Reservation> GetAll();

        /// <summary>Returns all reservations made by a specific user.</summary>
        IEnumerable<Reservation> GetByUser(string userId);

        /// <summary>Returns a reservation by its ID, or null if not found.</summary>
        Reservation? GetById(int id);

        /// <summary>Creates a new reservation.</summary>
        void Create(Reservation reservation);

        /// <summary>Approves a reservation by its ID.</summary>
        void Approve(int id);

        /// <summary>Deletes a reservation by its ID.</summary>
        void Delete(int id);
    }
}