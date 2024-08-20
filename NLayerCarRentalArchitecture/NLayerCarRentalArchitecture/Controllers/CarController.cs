using CarRentalBAL.IServices;
using CarRentalBAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace NLayerCarRentalArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarService _carService;
        public CarController(ICarService carService)
        {
                this._carService = carService;  
        }

        [HttpPost("addCar")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddCar([FromBody] CarModel car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            var message = await _carService.AddCar(car);
            if (message == null)
            {
                return BadRequest("Server Error");
            }
            else
            {
                return Ok(new
                {
                    message
                });
            }
        }

        [HttpGet("getCarById/{id}")]
        public async Task<IActionResult> GetCarById([FromRoute] Guid id)
        {
            var car = await _carService.GetCarById(id);
            if(car == null)
            {
                return NotFound("This Car Does not Exist");
            }
            return Ok(car);
        }

        [HttpGet("getAllCars")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars= await _carService.GetAllCars();
            if (cars == null)
            {
                return NotFound("There aren't any cars added till now! Please Add Some...!");
            }
            return Ok(cars);
        }

        [HttpGet("GetAvailableCars")]
        public async Task<IActionResult> GetAvailableCars()
        {
            var availableCars = await _carService.GetAvailableCars();
            if(availableCars == null)
            {
                return NotFound("No car is available right now");
            }
            return Ok(availableCars);
        }

        [HttpGet("getFilteredCars")]
        public async Task<IActionResult> GetFilteredCars([FromQuery] CarFilterModel filterModel)
        {
            if(filterModel == null)
            {
                return BadRequest();
            }
            var filteredCars = await _carService.GetFilteredCars(filterModel);
            if (filteredCars.Count() == 0)
            {
                return NotFound();
            }
            return Ok(filteredCars);
        }

        [HttpPut("updateCar/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid id, [FromBody] CarModel car)
        {
            var updatedCar= _carService.UpdateCarById(id, car);
            if (updatedCar == null)
            {
                return NotFound("Car with this Id Doesn't Exist anymore");
            }
            return Ok(new{
                Message= "Car Updated Successfully",
                updatedCar
            });
        }

        [HttpDelete("deleteCar/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
        {
            var result = await _carService.DeleteCarById(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(new
            {
                message= "Deleted Successfully"
            });
        }
    }
}
