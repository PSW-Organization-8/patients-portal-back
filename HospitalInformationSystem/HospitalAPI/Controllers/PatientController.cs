using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalAPI.Validators;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult RegisterPatient(PatientDto patientDto)
        {
            if (validator.Validate(PatientMapper.PatientDtoToPatient(
                patientDto, doctorService.Get(patientDto.DoctorId), allergenService.GetSelectedAllergens(patientDto.Allergens))).IsValid)
            {
                return Ok(patientService.RegisterPatient(PatientMapper.PatientDtoToPatient(patientDto, doctorService.Get(patientDto.DoctorId), allergenService.GetSelectedAllergens(patientDto.Allergens))));
            }
            return BadRequest(patientDto);
        }

        [HttpGet("activate/")]
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
    }
}