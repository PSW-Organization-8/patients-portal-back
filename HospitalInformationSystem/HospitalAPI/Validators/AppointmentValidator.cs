using FluentValidation;
using HospitalAPI.Dto;
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
        public AppointmentValidator(DoctorService doctorService, PatientService patientService)
        {
            this.doctorService = doctorService;
            this.patientService = patientService;
        }
        private bool CheckStartTime(object startTime)
        {
            return startTime != null && (DateTime)startTime > DateTime.Now;
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
            return dto != null && CheckDoctorId(dto.DoctorId) && CheckPatientId(dto.PatientId) && CheckStartTime(dto.StartTime);
        }
        public bool Valid(DateTime startTime, int doctorId)
        {
            return CheckStartTime(startTime) && CheckDoctorId(doctorId);
        }

    }
}
