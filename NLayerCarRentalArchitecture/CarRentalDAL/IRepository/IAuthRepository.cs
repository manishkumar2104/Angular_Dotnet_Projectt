using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.IRepository
{
    public interface IAuthRepository
    {
        public Task<IdentityUser?> GetUserByEmail(string email);
        public Task<bool> IsValidPassword(IdentityUser user, string password);
        public Task<JwtSecurityToken> CreateLoginToken(IdentityUser user);

    }
}
