﻿using BackendBootcamp.DBModels;
using BackendBootcamp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BackendBootcamp.Services
{
    public class AuthorizationService: IAuthService
    {
        private readonly BackendbootcampContext _context;
        private readonly IConfiguration _configuration;

        public AuthorizationService(BackendbootcampContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string generateToken(int userId)
        {
            string key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));

            var credentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentialsToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string createdToken = tokenHandler.WriteToken(tokenConfig);

            return createdToken;
        }

        private int readToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken tokenJWT = tokenHandler.ReadJwtToken(token);
            int userId = int.Parse(tokenJWT.Claims.First(claim => claim.Type == "nameid").Value);

            return userId;
        }

        public async Task<LoginResponse> ReturnToken(LoginRequestModel authorization)
        {
            User? FindUser = _context.Users.SingleOrDefault(user => user.Username == authorization.username);

            if (FindUser == null)
            {
                return await Task.FromResult<LoginResponse>(null);
            }

            if (FindUser.Password != authorization.password)
            {
                return new LoginResponse() { Result = false, Msg = "Username or password incorrect" };
            };

            string tokenCreated = generateToken(FindUser.Userid);

            return new LoginResponse() { Token = tokenCreated, Result = true, Msg = "token created!"};
        }

        public int ReadToken(string token)
        {
            return readToken(token);
        }
    }
}
