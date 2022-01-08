using HospitalAPI.Dto;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.ManagerRepo;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IPatientRepository patientRepository = new PatientRepository(new MyDbContext());
        private IManagerRepository managerRepository = new ManagerRepository(new MyDbContext());

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            var user = Authenticate(dto.Username, dto.Password);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(new { token = token});
            }
            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("managerLogin")]
        public IActionResult LoginManager(LoginDto dto)
        {
            var user = AuthenticateManager(dto.Username, dto.Password);
            if (user != null)
            {
                var token = GenerateManager(user);
                return Ok(new { token = token });
            }
            return NotFound("User not found");
        }

        private string Generate(LoggedUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, "patient")
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateManager(LoggedUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, "manager")
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private LoggedUser Authenticate(string username, string password)
        {
            var currentUser = patientRepository.GetLoggedUser(username, password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        private LoggedUser AuthenticateManager(string username, string password)
        {
            var currentUser = managerRepository.GetLoggedUser(username, password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }

}

