using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mapper
{
    public class AppointmentMapper
    {
        public static Appointment AppointmentDtoToAppointment(AppointmentDto dto, Doctor doctor, Patient patient)
        {
            return new Appointment(dto.StartDate, doctor, patient);
        }

        public static AppointmentDto AppointmentToAppointmentDto(Appointment appointment)
        {
            return new AppointmentDto(appointment.StartTime, appointment.DoctorId, appointment.PatientId);
        }
    }
}
