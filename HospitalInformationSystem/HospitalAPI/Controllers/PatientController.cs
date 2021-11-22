using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalAPI.Validators;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService patientService;
        private readonly PatientRepository patientRepository;
        private readonly PatientValidator validator;
        public PatientController(PatientService patientService, PatientRepository patientRepository)
        {
            this.patientService = patientService;
            this.patientRepository = patientRepository;
            this.validator = new PatientValidator();
        }

        [HttpPost]
        public IActionResult RegisterPatient(PatientDto patientDto)
        {
            return Ok(patientService.RegisterPatient(PatientMapper.PatientDtoToPatient(patientDto)));
        }

        [HttpGet("activate/")]
        public void ActivatePatientAccount(string patientToken)
        {
            if (patientService.GetByToken(patientToken) != null)
            {
                patientService.ActivatePatientAccount(patientToken);
                Response.Redirect("http://localhost:4200/patientLogin");
            }
        }
    }
}
