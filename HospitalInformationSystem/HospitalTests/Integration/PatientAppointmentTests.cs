﻿using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class PatientAppointmentTests : IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;

        public PatientAppointmentTests(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            if(context.Doctors.Where(doctor => doctor.Id == 100).ToList().Count == 0)
                FillFakeDatabase();
        }

        [Fact]
        public void Return_appointments_with_doctor_priority()
        {
            var appointmentController = new AppointmentController(new AppointmentService(new AppointmentRepository(context), new DoctorRepository(context)), 
                new DoctorService(new DoctorRepository(context)), new PatientService(new PatientRepository(context)));
            var availableAppointments = appointmentController.GetAppointmentByPriority(new DateTime(2022, 12, 15, 8, 0, 0), new DateTime(2022, 12, 16, 16, 0, 0), 100, true);
            List<Tuple<DateTime, int, string>> dateTimes = new List<Tuple<DateTime, int, string>>();
            FillDateTimeFrame(new DateTime(2022, 12, 13, 8, 0, 0), new DateTime(2022, 12, 13, 15, 45, 0), 100, "Radisa Milovcevic", dateTimes);
            FillDateTimeFrame(new DateTime(2022, 12, 14, 8, 0, 0), new DateTime(2022, 12, 14, 15, 45, 0), 100, "Radisa Milovcevic", dateTimes);
            FillDateTimeFrame(new DateTime(2022, 12, 17, 8, 0, 0), new DateTime(2022, 12, 17, 15, 45, 0), 100, "Radisa Milovcevic", dateTimes);
            FillDateTimeFrame(new DateTime(2022, 12, 18, 8, 0, 0), new DateTime(2022, 12, 18, 15, 45, 0), 100, "Radisa Milovcevic", dateTimes);

            var availableAppointmentsCheck = availableAppointments as ObjectResult;

            Assert.Equal(dateTimes, availableAppointmentsCheck.Value);
        }

        [Fact]
        public void Return_appointments_with_date_priority()
        {
            var appointmentController = new AppointmentController(new AppointmentService(new AppointmentRepository(context), new DoctorRepository(context)), 
                new DoctorService(new DoctorRepository(context)), new PatientService(new PatientRepository(context)));
            var availableAppointments = appointmentController.GetAppointmentByPriority(new DateTime(2022, 12, 15, 8, 0, 0), new DateTime(2022, 12, 16, 16, 0, 0), 100, false);
            List<Tuple<DateTime, int, string>> dateTimes = new List<Tuple<DateTime, int, string>>();
            FillDateTimeFrame(new DateTime(2022, 12, 15, 8, 0, 0), new DateTime(2022, 12, 15, 15, 45, 0), 1, "Jovan Jovanovic", dateTimes);
            FillDateTimeFrame(new DateTime(2022, 12, 16, 8, 0, 0), new DateTime(2022, 12, 16, 15, 45, 0), 1, "Jovan Jovanovic", dateTimes);
            FillDateTimeFrame(new DateTime(2022, 12, 15, 8, 0, 0), new DateTime(2022, 12, 15, 15, 45, 0), 2, "Milan Ilic", dateTimes);
            FillDateTimeFrame(new DateTime(2022, 12, 16, 8, 0, 0), new DateTime(2022, 12, 16, 15, 45, 0), 2, "Milan Ilic", dateTimes);

            var availableAppointmentsCheck = availableAppointments as ObjectResult;

            Assert.Equal(dateTimes, availableAppointmentsCheck.Value);
        }

        private void FillDateTimeFrame(DateTime firstDate, DateTime lastDate, int doctorId, string doctorFullName, List<Tuple<DateTime, int, string>> dateTimes)
        {
            for (DateTime dateTime = firstDate; dateTime <= lastDate; dateTime = dateTime.AddMinutes(15))
                    dateTimes.Add(new Tuple<DateTime, int, string>(dateTime, doctorId, doctorFullName));
        }

        private void FillFakeDatabase()
        {
            context.Doctors.Add(new Doctor { Id = 100, DoctorSpecialization = Specialization.FamilyPhysician, Name = "Radisa", LastName = "Milovcevic" });
            context.Patients.Add(new Patient { Id = 50 });
            for (DateTime dateTime = new(2022, 12, 15, 8, 0, 0); dateTime <= new DateTime(2022, 12, 15, 15, 45, 0); dateTime = dateTime.AddMinutes(15))
                context.Appointments.Add(new Appointment { StartTime = dateTime, DoctorId = 100, PatientId = 50});
            for (DateTime dateTime = new(2022, 12, 16, 8, 0, 0); dateTime <= new DateTime(2022, 12, 16, 15, 45, 0); dateTime = dateTime.AddMinutes(15))
                context.Appointments.Add(new Appointment { StartTime = dateTime, DoctorId = 100, PatientId = 50});
            context.SaveChanges();
        }
    }
}
