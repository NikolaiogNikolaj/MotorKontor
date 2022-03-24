﻿using Microsoft.IdentityModel.Tokens;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;
using MotorKontor.BL.Models.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MotorKontor.BL.Service
{
    public class LoginService : ILoginService
    {
        private readonly string key;
        private readonly IRepository _repository;
        private static RNGCryptoServiceProvider? _cryptoService = new RNGCryptoServiceProvider();
        public LoginService(IRepository repository, IConfiguration config)
        {
            _repository = repository;
            key = config.GetSection("JWTkey").ToString();
        }

        public async Task<AuthenticateResponse> Authenticate(Customer c, string ipaddress)
        {
            var response = await _repository.Login(c.Username, c.Password);

            if(response == null)
                return null;

            var jwtToken = GenerateJwtToken(response);
            var refreshToken = GenerateRefreshToken(ipaddress);
            response.RefreshToken.Add(refreshToken);
            
            await _repository.UpdateCustomerAsync(response);

            return new AuthenticateResponse(response, jwtToken, refreshToken.Token);
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            return await _repository.GetCustomerAsync(id);
        }

        public Task<AuthenticateResponse> RefreshToken(string token, string ipaddress)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevokeToken(string token, string ipadress)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(Customer customer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = Encoding.ASCII.GetBytes(key);
            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customer.CustomerID.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescripter);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipaddress)
        {
            using(var service = _cryptoService)
            {
                var randomBytes = new byte[64];
                service.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddHours(24),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipaddress,
                };
            }
        }
    }
}
