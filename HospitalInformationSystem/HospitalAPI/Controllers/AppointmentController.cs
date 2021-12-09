using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
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

        [HttpPut("{id?}")]
        public IActionResult CancelById(int id)
        {
            if (appointmentService.CancelById(id))
                return Ok(true);
            return BadRequest(false);
        }

        [HttpPut]
        [Route("survey/{id?}")]
        public IActionResult SurveyAppointment(int id)
        {
            if (appointmentService.SurveyAppointment(id))
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
        [Route("listDto")]
        public List<PatientAppointDto> GetDto()
        {
            List<PatientAppointDto> listDto = new List<PatientAppointDto>();
            foreach (Patient patient in patientService.GetAll())
            {
                PatientAppointDto dto = new PatientAppointDto(patient, appointmentService.GetNumberOfCancelledAppointments(patient.Id));
                listDto.Add(dto);
            }
            return listDto;
        }
            
        [HttpGet]
        public List<DateTime> GetAppointmentByPriority(DateTime firstDate, DateTime lastDate, int doctorId, bool doctorPriority)
        {
            return appointmentService.GetAppointmentByPriority(firstDate, lastDate, doctorId, doctorPriority);
        }
        [HttpPost]
        public IActionResult CreateNewAppointment(AppointmentDto appointmentDto)
        {
            appointmentService.Create(AppointmentMapper.AppointmentDtoToAppointment
                (appointmentDto, doctorService.Get(appointmentDto.DoctorId), patientService.Get(appointmentDto.PatientId)));
            return Ok();
        }

        [HttpGet]
        [Route("freeTerms")]
        public IActionResult GetFreeTerms(DateTime startTime, int doctorId)
        {
            return Ok(appointmentService.GetFreeTerms(startTime, doctorId));

        }
    }
}
