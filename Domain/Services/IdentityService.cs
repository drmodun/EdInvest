using Domain.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Contracts.Requests;
using Shared.Contracts.Requests.Users.User;
using Shared.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Shared.Hash;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class IdentityService
    {
        private const string TokenSecret = "EdInvestTheBestOfAllTheWebSites=<3";
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);
        private readonly UserRepo<User, GetUserRequest, GetAllUsersRequest> _userRepo;

        public IdentityService(UserRepo<User, GetUserRequest, GetAllUsersRequest> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string?> LoginUser(LoginUserRequset request)
        {
            var user = await _userRepo.GetUserByEmail(request.Email);
            if (user == null)
            {
                return null;
            }
            var check = HashHelper.ValidatePassword(request.Password, user.Password);
            if (!check)
                return null;
           
            var jwtRequest = new TokenGenerationRequest
            {
                Claims = user.Claims,
                Email = user.Email,
                Name = user.Email,
                UserId = user.Id,
            };
            return GenerateToken(jwtRequest);
        }
        public string GenerateToken(TokenGenerationRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, request.Email),
            new(JwtRegisteredClaimNames.Email, request.Email),
            new(JwtRegisteredClaimNames.Name, request.Name),
            new("userid", request.UserId.ToString()),
        };

            foreach (var claimPair in request.Claims)
            {
                var boolElement = claimPair.Value;
                var valueType = boolElement switch
                {
                    "true" => ClaimValueTypes.Boolean,
                    "false" => ClaimValueTypes.Boolean,
                    _ => ClaimValueTypes.String
                };

                var claim = new Claim(claimPair.Key, claimPair.Value.ToString()!, valueType);
                claims.Add(claim);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = "https://randomwebsite.com",
                Audience = "https://randomwebsite-web-api.com",
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
