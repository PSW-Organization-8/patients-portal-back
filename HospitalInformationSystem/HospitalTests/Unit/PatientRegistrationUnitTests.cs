using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HospitalTests.Unit
{
    public class PatientRegistrationUnitTests
    {

        [Theory]
        [MemberData(nameof(Data))]
        public void Patient_validators_test(PatientDto patientDto, int code)
        {
            var patientController = new PatientController(new PatientService(CreatePatinetStudRepository(patientDto)), 
                new DoctorService(CreateDoctorStudRepository()), 
                new AllergenService(CreateAllergenStudRepository()));

            var result = patientController.RegisterPatient(patientDto);
            var okResult = result as ObjectResult;

            Assert.Equal(code, okResult.StatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new PatientDto("Pera", "Pera", "1231231231231", "pera", "pera123123", "pera@gmail.com", "12345", "Serbia", "Obrovac", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "#123", "ABn"), 200 },
            new object[] { new PatientDto("Pera", "Pera", "123", "pera", "pera", "pera@gmail.com", "12345", "Serbia", "Obrovac", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "#123", "ABn"), 400 },
            new object[] { new PatientDto("Pera1", "Pera", "1233453451239", "pera", "pera", "pera@gmail.com", "12345", "Serbia", "Obrovac", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "#123", "ABn"), 400 },
            new object[] { new PatientDto("Pera", "Pera2", "1233453451239", "pera", "pera", "pera@gmail.com", "12345", "Serbia", "Obrovac", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "#123", "ABn"), 400 },
            new object[] { new PatientDto("Pera", "Pera", "1233453451239", "pera", "pera", "pera", "12345", "Serbia", "Obrovac", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "#123", "ABn"), 400 },
            new object[] { new PatientDto("Pera", "Pera", "1233453451239", "pera", "pera", "pera", "12345", "Serbia1", "Obrovac", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "#123", "ABn"), 400 },
            new object[] { new PatientDto("Pera", "Pera", "1233453451239", "pera", "pera", "pera", "12345", "Serbia1", "Obrovac3", "Neka 9",
            DateTime.Now, new List<Allergen>(), 1, false, "#123", "ABn"), 400 }
        };

        private static IPatientRepository CreatePatinetStudRepository(PatientDto patientDto)
        {
            var stubRepository = new Mock<IPatientRepository>();
            var patients = new List<Patient>();

            stubRepository.Setup(q => q.GetAll()).Returns(patients);
            stubRepository.Setup(q => q.Create(PatientMapper.PatientDtoToPatient(patientDto, new Doctor(), new List<Allergen>())))
                .Returns(PatientMapper.PatientDtoToPatient(patientDto, new Doctor(), new List<Allergen>()));

            return stubRepository.Object;
        }

        private static IDoctorRepository CreateDoctorStudRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();
            var doctor = new Doctor { Id = 1};
            doctors.Add(doctor);

            stubRepository.Setup(q => q.GetAll()).Returns(doctors);
            stubRepository.Setup(q => q.Get(1)).Returns(doctors.First());
            return stubRepository.Object;
        }

        private static IAllergenRepository CreateAllergenStudRepository()
        {
            var stubRepository = new Mock<IAllergenRepository>();
            var allergens = new List<Allergen>();

            stubRepository.Setup(q => q.GetAll()).Returns(allergens);

            return stubRepository.Object;
        }
    }
}
