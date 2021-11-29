using HospitalAPI.Dto;
using HospitalAPI.Mapper;
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
        public AppointmentController(AppointmentService appointmentService, DoctorService doctorService, PatientService patientService)
        {
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }

        [HttpGet("{id?}")]
        public IActionResult GetByPatient(int id)
        {
            if(appointmentService.GetByPatient(id).Count != 0)
                return Ok(appointmentService.GetByPatient(id));
            return BadRequest();
        }
        [HttpPost]
        public IActionResult CreateNewAppointment(AppointmentDto appointmentDto)
        {
            return Ok(appointmentService.Create(AppointmentMapper.AppointmentDtoToAppointment
                (appointmentDto, doctorService.Get(appointmentDto.DoctorId), patientService.Get(appointmentDto.PatientId))));
        }
    }
}
