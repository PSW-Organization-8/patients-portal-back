using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalAPI.Validators;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                patientService.RegisterPatient(PatientMapper.PatientDtoToPatient(patientDto, doctorService.Get(patientDto.DoctorId), allergenService.GetSelectedAllergens(patientDto.Allergens)));
                return Ok();
            }
            return BadRequest(patientDto);
        }

        [HttpPut("activate/")]
        public void ActivatePatientAccount(string patientToken)
        {
            if (validator.Validate(patientService.GetByToken(patientToken)).IsValid)
            {
                patientService.ActivatePatientAccount(patientToken);
                Response.Redirect("http://localhost:4200/patientLogin");
                //return Ok();
            }
            //return BadRequest();
        }

        [HttpGet("{id?}")]
        public IActionResult GetPatientById(int id)
        {
            return Ok(patientService.Get(id));
        }


        [HttpPut]
        [Route("ban/{id?}")]
        public IActionResult BanPatientById(int id)
        {
            return Ok(patientService.BanPatientById(id));
        }

        [HttpPut]
        [Route("unban/{id?}")]
        public IActionResult UnbanPatientById(int id)
        {
            return Ok(patientService.UnbanPatientById(id));
        }

    }
}