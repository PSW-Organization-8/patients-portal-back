using FluentValidation;
using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Validators
{
    public class AdvancedAppointmentValidator: AbstractValidator<AdvancedAppointmentDto>
    {
        public AdvancedAppointmentValidator()
        {
            RuleFor(advancedAppointmentDto => advancedAppointmentDto.FirstDate).NotEmpty();
            RuleFor(advancedAppointmentDto => advancedAppointmentDto.LastDate).NotEmpty();
            RuleFor(advancedAppointmentDto => advancedAppointmentDto.DoctorId).NotEmpty();
            RuleFor(advancedAppointmentDto => advancedAppointmentDto.FirstDate).GreaterThan(DateTime.Now);
            RuleFor(advancedAppointmentDto => advancedAppointmentDto.LastDate).GreaterThan(advancedAppointmentDto => advancedAppointmentDto.FirstDate);
            RuleFor(advancedAppointmentDto => advancedAppointmentDto.DoctorId).Must(
                doctorId => new DoctorService(new DoctorRepository(new MyDbContext())).GetAllDoctors().Select(x => x.Id).Contains(doctorId));
        }
    }
}
