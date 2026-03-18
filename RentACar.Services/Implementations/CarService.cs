using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Services.Implementations
{
    /// <summary>
    /// Service for managing car-related operations.
    /// </summary>
    public class CarService : ICarService
    {
        private readonly AppDbContext _db;

        public CarService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>Returns all cars including their reservations.</summary>
        public IEnumerable<Car> GetAll()
            => _db.Cars.Include(c => c.Reservations).ToList();

        /// <summary>Returns a car by its ID, or null if not found.</summary>
        public Car? GetById(int id)
            => _db.Cars.Include(c => c.Reservations).FirstOrDefault(c => c.Id == id);

        /// <summary>Adds a new car to the database.</summary>
        public void Add(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
        }

        /// <summary>Updates an existing car in the database.</summary>
        public void Update(Car car)
        {
            _db.Cars.Update(car);
            _db.SaveChanges();
        }

        /// <summary>Deletes a car by its ID.</summary>
        public void Delete(int id)
        {
            var car = _db.Cars.Find(id);
            if (car != null)
            {
                _db.Cars.Remove(car);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// Returns all cars that are available for the given date range.
        /// A car is unavailable if it has an approved reservation that overlaps with the requested period.
        /// </summary>
        public IEnumerable<Car> GetAvailableCars(DateTime start, DateTime end)
            => _db.Cars
                .Include(c => c.Reservations)
                .Where(c => !c.Reservations.Any(r =>
                    r.IsApproved &&
                    r.StartDate < end &&
                    r.EndDate > start))
                .ToList();
    }
}