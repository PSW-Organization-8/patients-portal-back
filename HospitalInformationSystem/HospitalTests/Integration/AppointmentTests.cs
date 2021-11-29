using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalClassLib;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
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
    public class AppointmentTests: IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;
        public AppointmentTests(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        }

        [Fact]
        public void Create_new_appointment()
        {
            //Arange
            var doctorService = new DoctorService(new DoctorRepository(context));
            var patientService = new PatientService(new PatientRepository(context));
            var appointmentController = new AppointmentController(new AppointmentService(new AppointmentRepository(context)), 
                doctorService, patientService);
            var appointmentDto = new AppointmentDto(new DateTime(2021, 12, 12, 13, 0, 0), 1, 1);
            var expectedResult = new Appointment(new DateTime(2021, 12, 12, 13, 0, 0), doctorService.Get(1), patientService.Get(1));

            //Act
            var result = appointmentController.CreateNewAppointment(appointmentDto) as ObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }
    }
}
