using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalAPI.Validators;
using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Validators;
using Microsoft.AspNetCore.Authorization;

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
        private readonly AdvancedAppointmentValidator advancedAppointmentValidator;
        private readonly IdValidator idValidator;
        public AppointmentController(AppointmentService appointmentService, DoctorService doctorService, PatientService patientService)
        {
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.appointmentValidator = new AppointmentValidator(doctorService, patientService, appointmentService);
            this.appointmentService.FinishAppointments();
            this.advancedAppointmentValidator = new AdvancedAppointmentValidator();
            this.idValidator = new IdValidator();
        }

        [HttpGet("{id?}")]
        [Authorize]
        public IActionResult GetByPatient(int id)
        {
            if(idValidator.CheckId(id) && appointmentService.GetByPatient(id).Count != 0)
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
                return Ok(true);
            }
            return BadRequest("Invalid data!");
        }
        [HttpPut("{id?}")]
        public IActionResult CancelById(int id)
        {
            if (idValidator.CheckId(id) && appointmentService.CancelById(id))
                return Ok(true);
            return BadRequest(false);
        }

        [HttpPut]
        [Route("survey/{id?}")]
        public IActionResult SurveyAppointment(int id)
        {
            if (idValidator.CheckId(id) && appointmentService.SurveyAppointment(id))
                return Ok(true);
            return BadRequest(false);
        }

        [HttpGet]
        [Route("cancel/{id?}")]
        public IActionResult GetNumberOfCancelledAppointments(int id)
        {
            if (!idValidator.CheckId(id))
                return BadRequest(false);
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
        public IActionResult GetAppointmentByPriority(DateTime firstDate, DateTime lastDate, int doctorId, bool doctorPriority)
        {
            AdvancedAppointmentDto dto = new(firstDate, lastDate, doctorId, doctorPriority);
            if(advancedAppointmentValidator.Validate(dto).IsValid)
                return Ok(appointmentService.GetAppointmentByPriority(dto.FirstDate, dto.LastDate, dto.DoctorId, dto.DoctorPriority));
            return BadRequest(false);
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
