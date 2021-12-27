using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IPatientRepository _patientRepository;
        private readonly TokenService _tokenService;
        private string generatedToken = null;

        public LoginController(IConfiguration config, TokenService tokenService, IPatientRepository patientRepository)
        {
            _config = config;
            _tokenService = tokenService;
            _patientRepository = patientRepository;
        }

        [NonAction]
        [ActionName(nameof(Index))]
        public IActionResult Index()
        {
            return View();
        }

        [Route("asa")]
        [HttpGet]
        public string nest() 
        {
            return "asd";
        }


        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return (RedirectToAction("Error"));
            }
            IActionResult response = Unauthorized();
            var validUser = GetUser(username);

            if (validUser != null)
            {
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return RedirectToAction("MainWindow");
                }
                else
                {
                    return (RedirectToAction("Error"));
                }
            }
            else
            {
                return (RedirectToAction("Error"));
            }
        }

        private UserLogin GetUser(string username)
        {   
            return _patientRepository.GetLoggedPatient(username);
        }


        [Authorize]
        [Route("mainwindow")]
        [HttpGet]
        [ActionName(nameof(MainWindow))]
        protected IActionResult MainWindow()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Index"));
            }
            if (!_tokenService.IsTokenValid(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("Index"));
            }
            ViewBag.Message = BuildMessage(token, 50);
            return View();
        }

        [NonAction]
        [ActionName(nameof(Error))]
        public IActionResult Error()
        {
            ViewBag.Message = "An error occured...";
            return View();
        }

        private string BuildMessage(string stringToSplit, int chunkSize)
        {
            var data = Enumerable.Range(0, stringToSplit.Length / chunkSize).Select(i => stringToSplit.Substring(i * chunkSize, chunkSize));
            string result = "The generated token is:";
            foreach (string str in data)
            {
                result += Environment.NewLine + str;
            }
            return result;
        }
    }

}

