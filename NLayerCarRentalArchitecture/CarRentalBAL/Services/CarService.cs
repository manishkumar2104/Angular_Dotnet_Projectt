using AutoMapper;
using CarRentalBAL.IServices;
using CarRentalBAL.Models;
using CarRentalDAL.Entities;
using CarRentalDAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.Services
{
    public class CarService: ICarService
    {
        private readonly ICarRepository _carRepository;
        private Mapper _carMapper;
        public CarService(ICarRepository carRepository) {
            _carRepository = carRepository;
            var _configCar = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarModel>().ReverseMap();
            });
            this._carMapper = new Mapper(_configCar);
        }

        public Task<string> AddCar(CarModel car)
        {
            try
            {
                var carEntity = new Car()
                {
                    Id = Guid.NewGuid(),
                    Maker = car.Maker,
                    Model = car.Model,
                    RentalPrice = car.RentalPrice,
                    ImageUrl = car.ImageUrl,
                    IsAvailableForRent = true
                };
                return  _carRepository.AddCar(carEntity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<CarModel?> GetCarById(Guid id)
        {
            var carData = await _carRepository.GetCarById(id);
            if(carData == null)
            {
                return null;
            }
            CarModel carModel = _carMapper.Map<Car, CarModel>(carData);
            return carModel;
        }

        public async Task<List<CarModel>> GetAllCars()
        {
            var cars=await _carRepository.GetAllCars();
            List<CarModel> allCars = _carMapper.Map<List<Car>, List<CarModel>>(cars);
            return allCars;
        }

        public async Task<List<CarModel>> GetAvailableCars()
        {
            var cars = await _carRepository.GetAvailableCars();
            List<CarModel> availableCars= _carMapper.Map<List<Car>, List<CarModel>>(cars);
            return availableCars;
        }

        public async Task<List<CarModel>>GetFilteredCars(CarFilterModel filterModel)
        {
            var availableCars= await _carRepository.GetAvailableCars();
            if(availableCars == null)
            {
                return new List<CarModel>();
            }
            if (filterModel.Maker != null)
            {
                availableCars = availableCars.Where(car => car.Maker == filterModel.Maker).ToList();
            }
            if(filterModel.Model != null)
            {
                availableCars = availableCars.Where(car=>car.Model == filterModel.Model).ToList();
            }
            if(filterModel.RentalPrice != null)
            {
                availableCars = availableCars.Where(car=> car.RentalPrice <= filterModel.RentalPrice).ToList();
            }
            var filteredCars = _carMapper.Map<List<Car>, List<CarModel>>(availableCars);
            return filteredCars;
        }

        public async Task<CarModel?> UpdateCarById(Guid id, CarModel car)
        {
            var existingCar= await _carRepository.GetCarById(id);
            if(existingCar == null)
            {
                return null;
            }
            existingCar.Maker = car.Maker;
            existingCar.Model = car.Model;
            existingCar.RentalPrice = car.RentalPrice;
            existingCar.ImageUrl = car.ImageUrl;
            var updatedCar = await _carRepository.UpdateCar(existingCar);
            return _carMapper.Map<Car, CarModel>(updatedCar);
        }

        public async Task<bool> DeleteCarById(Guid id)
        {
            var existingCar= await _carRepository.GetCarById(id);
            if (existingCar == null)
            {
                return false;
            }
            var result = await _carRepository.DeleteCar(existingCar);
            return result;
        }
    }
}
