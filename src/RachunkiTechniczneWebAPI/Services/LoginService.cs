using Microsoft.IdentityModel.Tokens;
using RachunkiTechniczneWebApi.DTOs;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RachunkiTechniczneWebApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public LoginService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<LoggedUserDto> Login(LoginDto userLogin) {
            var user = await Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);

                var userData = new LoggedUserDto
                {
                    token = token,
                    userId = user.Id_user,
                    username = user.Login,
                    isAdmin = user.Is_admin
                };

                return userData;
            }

            return null;
        }

        // To generate token
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Login),
                new Claim(ClaimTypes.Role, user.Is_admin ? "admin" : "użyszkodnik")
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private async Task<User> Authenticate(LoginDto userLogin)
        {
            var currentUser = await _userRepository.GetByLoginAsync(userLogin.Login);

            if (currentUser != null && currentUser.Password == userLogin.Password) {
                return currentUser;
            }
            return null;
        }
    }
}
