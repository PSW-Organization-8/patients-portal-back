using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalAPI.Validators;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
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
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService appointmentService;
        private readonly DoctorService doctorService;
        private readonly PatientService patientService;
        private readonly AppointmentValidator appointmentValidator;
        public AppointmentController(AppointmentService appointmentService, DoctorService doctorService, PatientService patientService)
        {
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.appointmentValidator = new AppointmentValidator(doctorService, patientService);
        }

        [HttpGet("{id?}")]
        public IActionResult GetByPatient(int id)
        {
            if(appointmentService.GetByPatient(id).Count != 0)
                return Ok(appointmentService.GetByPatient(id));
            return BadRequest();
        }

        [HttpPost]
        [Route("createNew")]
        public IActionResult CreateNewAppointment(AppointmentDto appointmentDto)
        {
            if (appointmentValidator.Valid(appointmentDto))
            {
                appointmentService.Create(AppointmentMapper.AppointmentDtoToAppointment
                (appointmentDto, doctorService.Get(appointmentDto.DoctorId), patientService.Get(appointmentDto.PatientId)));
                return Ok("Successfully created appointment.");
            }
            return BadRequest("Invalid data!");
        }

        [HttpGet]
        [Route("freeTerms")]
        public IActionResult GetFreeTerms(DateTime startTime, int doctorId)
        {
            if(appointmentValidator.Valid(startTime, doctorId))
                return Ok(appointmentService.GetFreeTerms(startTime, doctorId));
            return BadRequest("Invalid data!");
        }
    }
}
