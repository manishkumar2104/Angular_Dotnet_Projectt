using CarRentalBAL.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.Helper
{
    public class AuthHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public AuthenticatedUserDTO GetUserData()
        {
            AuthenticatedUserDTO authenticatedUserDTO = new();

            var claimsIdentity = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault(item => item.Claims.Any());
            var claims = claimsIdentity?.Claims;

            authenticatedUserDTO.Email = claims?.FirstOrDefault(Item => Item.Type == ClaimTypes.Email)?.Value;
            authenticatedUserDTO.UserId = claims?.FirstOrDefault(item => item.Type == ClaimTypes.GivenName)?.Value;
            authenticatedUserDTO.UserName = claims?.FirstOrDefault(item => item.Type == ClaimTypes.Name)?.Value;

            return authenticatedUserDTO;
        }

        public string GetLoggedinUserRole()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault(item => item.Claims.Any());
            var claims = claimsIdentity?.Claims;

            var userRole = claims?.FirstOrDefault(Item => Item.Type == ClaimTypes.Role)?.Value;

            return userRole;
        }
    }
}
