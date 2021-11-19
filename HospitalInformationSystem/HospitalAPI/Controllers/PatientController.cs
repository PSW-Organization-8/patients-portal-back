using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService patientService;
        private readonly PatientRepository patientRepository;
        public PatientController(PatientService patientService, PatientRepository patientRepository)
        {
            this.patientService = patientService;
            this.patientRepository = patientRepository;
        }

        [HttpPost]
        public IActionResult RegisterPatient(PatientDto patientDto)
        {
            return Ok(patientService.RegisterPatient(PatientMapper.PatientDtoToPatient(patientDto)));
        }

        /*[HttpGet]
        public IActionResult SendEmail()
        {
            // 555 : BROJ ZA TESTIRANJE SLANJA MEJLA
            return Ok(patientService.SendEmail("AAABBBCCCD"));
        }*/

        [HttpGet("patientActivation/{patientId?}")]
        public void ActivatePatientAccount(string patientId)
        {
            patientService.ActivatePatientAccount(patientId);
            Response.Redirect("http://www.google.com");
        }
    }
}
