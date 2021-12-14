using FluentValidation;
using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class AppointmentValidator
    {
        private DoctorService doctorService;
        private PatientService patientService;
        private AppointmentService appointmentService;
        public AppointmentValidator(DoctorService doctorService, PatientService patientService, AppointmentService appointmentService)
        {
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.appointmentService = appointmentService;
        }
        private bool CheckStartTime(object startTime, int doctorId)
        {
            return startTime != null && (DateTime)startTime > DateTime.Now && CheckIfTermIsAlreadyScheduled((DateTime)startTime, doctorId) == false;
        }
        private bool CheckIfTermIsAlreadyScheduled(DateTime startTime, int doctorId)
        {
            List<Appointment> list = appointmentService.GetByDoctor(doctorId);
            if (list == null) return false;
            foreach (Appointment doctorAppointment in list)
            {
                if (startTime >= doctorAppointment.StartTime && startTime < doctorAppointment.StartTime.AddMinutes(15))
                    return true;
            }
            return false;
        }
        private bool CheckDoctorId(object doctorId)
        {
            return doctorId != null && this.doctorService.Get((int)doctorId) != null;
        }
        private bool CheckPatientId(object patientId)
        {
            return patientId != null && this.patientService.Get((int)patientId) != null;
        }
        public bool Valid(AppointmentDto dto)
        {
            return dto != null && CheckDoctorId(dto.DoctorId) && CheckPatientId(dto.PatientId) && CheckStartTime(dto.StartTime, dto.DoctorId);
        }
        public bool Valid(DateTime startTime, int doctorId)
        {
            return CheckStartTime(startTime, doctorId) && CheckDoctorId(doctorId);
        }

    }
}
