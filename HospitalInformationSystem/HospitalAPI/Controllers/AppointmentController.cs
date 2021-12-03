using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
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
        private readonly PatientService patientService;

        public AppointmentController(AppointmentService appointmentService, PatientService patientService)
        {
            this.appointmentService = appointmentService;
            this.patientService = patientService;
        }

        [HttpGet("{id?}")]
        public IActionResult GetByPatient(int id)
        {
            if(appointmentService.GetByPatient(id).Count != 0)
                return Ok(appointmentService.GetByPatient(id));
            return BadRequest();
        }

        [HttpPut("{id?}")]
        public IActionResult CancelById(int id)
        {
            if (appointmentService.CancelById(id))
                return Ok(true);
            return BadRequest(false);
        }

        [HttpGet]
        [Route("cancel/{id?}")]
        public IActionResult GetNumberOfCancelledAppointments(int id)
        {
            return Ok(appointmentService.GetNumberOfCancelledAppointments(id));
        
        }

        [HttpGet]
        public List<PatientAppointDto> GetDto()
        {
            List<PatientAppointDto> listDto = new List<PatientAppointDto>();
            List<Patient> patients = patientService.GetAll();
            foreach (Patient patient in patients)
            {
                int number = appointmentService.GetNumberOfCancelledAppointments(patient.Id);
                PatientAppointDto dto = new PatientAppointDto(patient, number);
                listDto.Add(dto);
            }

            return listDto;

        }
    }
}
