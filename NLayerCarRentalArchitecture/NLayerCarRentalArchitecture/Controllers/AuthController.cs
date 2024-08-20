using CarRentalBAL.Helper;
using CarRentalBAL.IServices;
using CarRentalBAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace NLayerCarRentalArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AuthHelper _helper;
        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _helper = new AuthHelper(httpContextAccessor);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _authService.Login(loginUser);
                if (response == null)
                {
                    return Unauthorized();
                }
                var userRole = _helper.GetLoggedinUserRole();
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(response),
                    role = userRole,
                    expiration = response.ValidTo
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = $"Internal Server Error Occured {ex}"
                });
            }
        }
        [HttpGet("getUserRole")]
        [Authorize]
        public async Task<IActionResult> GetRole()
        {
            var role = _helper.GetLoggedinUserRole();
            if (role == null)
            {
                return BadRequest("Unauthorised User");
            }
            return Ok(new{
                userRole=role
            });
        }

        [HttpGet("getUserData")]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {
            var userInfo= _helper.GetUserData();
            if(userInfo == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                userData=userInfo
            });
        }
    }
}
