using CarRentalBAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.IServices
{
    public interface IAuthService
    {
        public Task<JwtSecurityToken> Login(LoginUser loginUser);
    }
}
