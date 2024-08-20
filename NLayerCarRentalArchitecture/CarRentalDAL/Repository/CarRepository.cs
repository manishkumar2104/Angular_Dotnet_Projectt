using CarRentalDAL.DB;
using CarRentalDAL.Entities;
using CarRentalDAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repository
{
    public class CarRepository: ICarRepository
    {
        private readonly AppDBContext _appDBContext;
        public CarRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<string> AddCar(Car car)
        {
            try
            {
                var newCar = await _appDBContext.AddAsync(car);
                await _appDBContext.SaveChangesAsync();
                return "Car Added Successfully";
            }
            catch (Exception ex)
            {
                return null;
            }
        } 

        public async Task<Car?> GetCarById(Guid id)
        {
            try
            {
                var car = await _appDBContext.Cars.FindAsync(id);
                return car;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            var allCars= await _appDBContext.Cars.ToListAsync();
            return allCars;
        }

        public async Task<List<Car>> GetAvailableCars()
        {
            var availableCars= await _appDBContext.Cars.Where(car=> car.IsAvailableForRent==true).ToListAsync();
            return availableCars;
        }

        public async Task<Car?> UpdateCar(Car car)
        {
            var updatedCar = _appDBContext.Cars.Update(car);
            await _appDBContext.SaveChangesAsync();
            return updatedCar.Entity;
        }
        public async Task<bool> DeleteCar(Car car)
        {
            var deletedCar = _appDBContext.Cars.Remove(car);
            await _appDBContext.SaveChangesAsync();
            return deletedCar.Entity.Id == car.Id;
        }
    }
}
