using CarRentalBAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.IServices
{
    public interface ICarService
    {
        public Task<string> AddCar(CarModel car);
        public Task<CarModel> GetCarById(Guid carId);
        public Task<List<CarModel>> GetAllCars();
        public Task<List<CarModel>> GetAvailableCars();
        public Task<CarModel?> UpdateCarById(Guid id, CarModel car);
        public Task<bool> DeleteCarById(Guid id);
        public Task<List<CarModel>> GetFilteredCars(CarFilterModel filterModel);
    }
}
