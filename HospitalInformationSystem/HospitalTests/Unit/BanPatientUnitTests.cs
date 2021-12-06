using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
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
    public class BanPatientUnitTests
    {
        [Fact]
        public void Number_of_canceled_appointments()
        {
            var appointmentService = new AppointmentService(CreateStudAppointmentRepository(1));
            var result = appointmentService.GetNumberOfCancelledAppointments(1);
            Assert.Equal(3, result);
        }


        private static IAppointmentRepository CreateStudAppointmentRepository(int id)
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = new List<Appointment>();
            Patient patient = new Patient();
            patient.Id = 1;
            Appointment appointment1 = new Appointment(1, DateTime.Now, AppointmentType.examination, new Doctor(), patient);
            appointment1.State = AppointmentState.cancelled;
            Appointment appointment2 = new Appointment(2, DateTime.Now, AppointmentType.examination, new Doctor(), patient);
            appointment2.State = AppointmentState.cancelled;
            Appointment appointment3 = new Appointment(3, DateTime.Now, AppointmentType.examination, new Doctor(), patient);
            appointment3.State = AppointmentState.cancelled;
            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);

            stubRepository.Setup(a => a.GetAll()).Returns(appointments);
            stubRepository.Setup(a => a.Create(appointment1)).Returns(appointment1);
            stubRepository.Setup(a => a.GetNumberOfCancelledAppointments(1)).Returns(appointments.Where(x => x.PatientId == id && x.State == AppointmentState.cancelled).ToList().Count);
            return stubRepository.Object;
        }
    }
}
