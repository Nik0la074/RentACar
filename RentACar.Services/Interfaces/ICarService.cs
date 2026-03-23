using RentACar.Data.Models;

namespace RentACar.Services.Interfaces
{
    /// <summary>
    /// Defines operations for managing cars in the system.
    /// </summary>
    public interface ICarService
    {
        /// <summary>Returns all cars.</summary>
        IEnumerable<Car> GetAll();

        /// <summary>Returns a car by its ID, or null if not found.</summary>
        Car? GetById(int id);

        /// <summary>Adds a new car to the database.</summary>
        void Add(Car car);

        /// <summary>Updates an existing car in the database.</summary>
        void Update(Car car);

        /// <summary>Deletes a car by its ID.</summary>
        void Delete(int id);

        /// <summary>Returns all cars available for the given date range.</summary>
        IEnumerable<Car> GetAvailableCars(DateTime start, DateTime end);

        /// <summary>Returns all booked periods for a specific car.</summary>
        IEnumerable<Reservation> GetBookedPeriods(int carId);
    }
}