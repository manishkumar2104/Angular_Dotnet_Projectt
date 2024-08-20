using CarRentalBAL.IServices;
using CarRentalBAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NLayerCarRentalArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        public IAgreementService _agreementService;
        public ICarService _carService;

        public AgreementController(IAgreementService agreementService, ICarService carService)
        {
            _agreementService = agreementService;
            _carService = carService;
        }

        [HttpPost("rentCar")]
        [Authorize]
        public async Task<IActionResult> CreateBookingAgreement([FromBody]AgreementModel agreementData)
        {
            if (agreementData == null)
            {
                return BadRequest();
            }
            var car = await _carService.GetCarById(agreementData.CarId);
            if (car == null)
            {
                return NotFound("Car with this Id not exist and cannot be Rented...!");
            }
            if(car.IsAvailableForRent==false)
            {
                return BadRequest("This Car is not available to rent");
            }
            var result = await _agreementService.CreateCarBookingAgreement(agreementData);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(new
            {
                Message = "Car Rented Out Successfully"
            });
        }

        [HttpGet("getAllAgreement")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllRentalAgreements()
        {
            var allBookings = await _agreementService.GetAllAgreements();
            if (allBookings == null)
            {
                return NotFound("No Agreement found Till Now");
            }
            return Ok(allBookings);
        }

        [HttpGet("GetAllUserAgreement")]
        [Authorize]
        public async Task<IActionResult> GetAllUserAgreements()
        {
            var userAgreements = await  _agreementService.GetAllUserAgreements();
            if(userAgreements == null)
            {
                return NotFound("No Rental Agreement made by the user Yet");
            }
            return Ok(userAgreements);
        }

        [HttpDelete("deleteAgreement/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAgreement([FromRoute] string id)
        {
            //var agreementExists= await _agreementService.AgreementExist(id);
            //var existingAgreement= await _agreementService.GetAgreementById(id);
            //if (agreementExists == false)
            //{
              //  return NotFound("Agreement with this Id doesn't Exist");
            //} this will cause double instance created exception
            var result = await _agreementService.DeleteAgreement(id);
            if (result == false)
            {
                return NotFound("Agreement Not Deleted");
            }
            return Ok(new
            {
                response= "Agreement Deleted Successfully"
            });
        }
        [HttpGet("getAgreementById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetAgreementById([FromRoute] string id)
        {
            var result = await _agreementService.GetAgreementById(id);
            if(result == null)
            {
                return NotFound("Agreement with Id doesnot exist");
            }
            return Ok(result);
        }

        [HttpPost("requestReturn/{id}")]
        [Authorize]
        public async Task<IActionResult> RequestReturn([FromRoute] string id)
        {
            var result = await _agreementService.RequestReturn(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                response = "Request Submitted Successfully"
            });
        }

        [HttpPost("validateReturnRequest")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ValidateRequest([FromBody] ValidateRequestModel requestData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _agreementService.ValidateReturnRequest(requestData);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Response = result
            });
        }

        [HttpPut("updateAgreement")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateAgreement([FromBody]AgreementModel agreement)
        {
            var result = await _agreementService.UpdateAgreement(agreement);
            return Ok(new
            {
                result
            });
        }

        [HttpGet("getAllPendingReturnRequest")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllPendingReturnRequestAgreements()
        {
            var allPendingReturnRequestAgreements = await _agreementService.GetAllReturnRequestAgreements();
            if (allPendingReturnRequestAgreements == null)
            {
                return NotFound();
            }
            return Ok(allPendingReturnRequestAgreements);
        }
    }
}
