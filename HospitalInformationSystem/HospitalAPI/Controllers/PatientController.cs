﻿using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalAPI.Validators;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService patientService;
        private readonly DoctorService doctorService;
        private readonly AllergenService allergenService;
        private readonly PatientValidator validator;
        public PatientController(PatientService patientService, DoctorService doctorService, AllergenService allergenService)
        {
            this.patientService = patientService;
            this.doctorService = doctorService;
            this.allergenService = allergenService;
            this.validator = new PatientValidator();
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            return Ok(patientService.GetAll());
        }

        [HttpPost]
        public IActionResult RegisterPatient(PatientDto patientDto)
        {
            if (validator.Validate(PatientMapper.PatientDtoToPatient(
                patientDto, doctorService.Get(patientDto.DoctorId), allergenService.GetSelectedAllergens(patientDto.Allergens))).IsValid)
            {
                patientService.RegisterPatient(PatientMapper.PatientDtoToPatientRegistration(patientDto, doctorService.Get(patientDto.DoctorId), allergenService.GetSelectedAllergens(patientDto.Allergens)));
                return Ok(true);
            }
            return BadRequest(patientDto);
        }

        [HttpGet]
        [Route("activate")]
        public void ActivatePatientAccount(string patientToken)
        {
            if (validator.Validate(patientService.GetByToken(patientToken)).IsValid)
            {
                patientService.ActivatePatientAccount(patientToken);
                Response.Redirect("http://localhost:4200/patientLogin");
            }
        }

        [HttpGet("{id?}")]
        public IActionResult GetPatientById(int id)
        {
            return Ok(patientService.Get(id));
        }

        [HttpGet("getByUsername/{id?}")]
        public IActionResult GetByUsername(string id)
        {
            return Ok(patientService.GetByUsername(id));
        }

        [HttpPut]
        [Route("ban/{id?}")]
        [Authorize]
        public IActionResult BanPatientById(int id)
        {
            return Ok(patientService.BanPatientById(id));
        }

        [HttpPut]
        [Route("unban/{id?}")]
        [Authorize]
        public IActionResult UnbanPatientById(int id)
        {
            return Ok(patientService.UnbanPatientById(id));
        }

        [HttpGet("login")]
        [Authorize]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }

        [HttpGet("getAllUsernames")]
        public IActionResult GetAllUsernames()
        {
            return Ok(patientService.GetAllUsernames());
        }

        [HttpGet("getAllEmails")]
        public IActionResult GetAllEmails()
        {
            return Ok(patientService.GetAllEmails());
        }

        private LoggedUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new LoggedUser
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }
            return null;
        }
    }
}