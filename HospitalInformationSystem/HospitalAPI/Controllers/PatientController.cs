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
        private readonly PatientValidator validator;
        public PatientController(PatientService patientService, DoctorService doctorService)
        {
            this.patientService = patientService;
            this.doctorService = doctorService;
            this.validator = new PatientValidator();
        }

        [HttpPost]
        public IActionResult RegisterPatient(PatientDto patientDto)
        {
            patientService.RegisterPatient(PatientMapper.PatientDtoToPatient(patientDto, doctorService.Get(patientDto.DoctorId)));
            return Ok();
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
