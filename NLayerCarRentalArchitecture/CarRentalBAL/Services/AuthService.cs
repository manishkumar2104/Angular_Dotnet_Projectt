            using CarRentalBAL.IServices;
using CarRentalBAL.Models;
using CarRentalDAL.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.Services
{
    public class AuthService: IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        public async Task<JwtSecurityToken> Login(LoginUser loginUser)
        {
            var existingUser = await _authRepository.GetUserByEmail(loginUser.email);
            if(existingUser == null)
            {
                return null;
            }
            var result= await _authRepository.IsValidPassword(existingUser, loginUser.password);
            if(result == false)
            {
                return null;
            }
            var jwtToken = await _authRepository.CreateLoginToken(existingUser);
            return jwtToken;
        }
    }
}
