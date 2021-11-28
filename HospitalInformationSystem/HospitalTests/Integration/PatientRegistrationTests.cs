using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalClassLib;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace HospitalTests.Integration
{
    public class PatientRegistrationTests: IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;

        public PatientRegistrationTests(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        }
        [Fact]
        public void Register_new_patient()
        {
            //Arange
            var patientService = new PatientService(new PatientRepository(context));

            DateTime now = DateTime.Now;

            var patientDto = new PatientDto("Pera", "Pera", "123", "pera", "pera", "pera@gmail.com", "12345", "Serbia", "Obrovac", "Neka 9",
            now, null, 1, false, "#123", "ABn");

            var expectedResult = new Patient("Pera", "Pera", "123", "pera", "pera", "pera@gmail.com", "12345", "Serbia", "Obrovac", "Neka 9",
            now, null, 1, false, "#123", "ABn");

            //Act
            var result = patientService.RegisterPatient(PatientMapper.TestDtoToPatient(patientDto));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void Send_mail()
        {
            var patientController = new PatientController(new PatientService(new PatientRepository(context)),
                new DoctorService(new DoctorRepository(context)),
                new AllergenService(new AllergenRepository(context)));

            PatientDto patient = new PatientDto("Marko", "Markovic", "123", "pera", "pera", "pera@gmail.com", "12345", "Serbia", "Obrovac", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "ABC123DEF4AAAAC12345", "ABn");
            patientController.RegisterPatient(patient);

            patientController.ActivatePatientAccount("ABC123DEF4AAAAC12345");

            Patient p = context.Patients.Where(p => p.Token == "ABC123DEF4AAAAC12345").ToList()[0];

            Assert.True(p.IsActivated);
        }
    }
}
