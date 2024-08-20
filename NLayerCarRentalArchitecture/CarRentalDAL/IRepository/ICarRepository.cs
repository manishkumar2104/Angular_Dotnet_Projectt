using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.IRepository
{
    public interface ICarRepository
    {
        public Task<string> AddCar(Car car);
        public Task<Car?> GetCarById(Guid id);
        public Task<List<Car>> GetAllCars();
        public Task<List<Car>> GetAvailableCars();
        public Task<Car?> UpdateCar(Car car);
        public Task<bool> DeleteCar(Car car);
    }
}
