using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Data.Models;
using RentACar.Services.Interfaces;

namespace RentACar.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _db;

        public CarService(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Car> GetAll()
            => _db.Cars.Include(c => c.Reservations).ToList();

        public Car? GetById(int id)
            => _db.Cars.Include(c => c.Reservations).FirstOrDefault(c => c.Id == id);

        public void Add(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
        }

        public void Update(Car car)
        {
            _db.Cars.Update(car);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _db.Cars.Find(id);
            if (car != null)
            {
                _db.Cars.Remove(car);
                _db.SaveChanges();
            }
        }


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