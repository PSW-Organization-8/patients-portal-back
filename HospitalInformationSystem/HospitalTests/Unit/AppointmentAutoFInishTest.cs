using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    public class AppointmentAutoFInishTest
    {
        [Fact]
        public void Appointment_correctlly_finishes()
        {
            var appointmentService = new AppointmentService(CreateStudAppointmentRepository(1), CreateStudDoctorRepository());
            
            appointmentService.FinishAppointments();
            List<Appointment> result = appointmentService.GetAll();
            
            Assert.Equal(AppointmentState.pending, result[0].State);
            Assert.Equal(AppointmentState.pending, result[1].State);
            Assert.Equal(AppointmentState.cancelled, result[2].State);
            Assert.Equal(AppointmentState.finished, result[3].State);
        }

        private static IAppointmentRepository CreateStudAppointmentRepository(int id)
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = new List<Appointment>();
            Patient patient = new Patient();
            patient.Id = 1;
            Appointment appointment1 = new Appointment(1, new DateTime(2021, 10, 11), AppointmentType.examination, new Doctor(), patient);
            appointment1.State = AppointmentState.pending;
            Appointment appointment2 = new Appointment(2, new DateTime(2025, 10, 11), AppointmentType.examination, new Doctor(), patient);
            appointment2.State = AppointmentState.pending;
            Appointment appointment3 = new Appointment(3, new DateTime(2025, 10, 11), AppointmentType.examination, new Doctor(), patient);
            appointment3.State = AppointmentState.cancelled;
            Appointment appointment4 = new Appointment(4, new DateTime(2021, 10, 11), AppointmentType.examination, new Doctor(), patient);
            appointment4.State = AppointmentState.finished;

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);
            appointments.Add(appointment4);

            stubRepository.Setup(a => a.FinishAppointments());
            stubRepository.Setup(a => a.GetAll()).Returns(appointments);
            stubRepository.Setup(a => a.Create(appointment1)).Returns(appointment1);
           
            return stubRepository.Object;
        }

        private static IDoctorRepository CreateStudDoctorRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();
            Doctor doctor = new Doctor { Id = 1 };
            stubRepository.Setup(a => a.GetAll()).Returns(doctors);
            return stubRepository.Object;
        }
    }
}

