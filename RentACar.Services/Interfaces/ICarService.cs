using RentACar.Data.Models;

namespace RentACar.Services.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car? GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(int id);
        IEnumerable<Car> GetAvailableCars(DateTime start, DateTime end);
    }
}