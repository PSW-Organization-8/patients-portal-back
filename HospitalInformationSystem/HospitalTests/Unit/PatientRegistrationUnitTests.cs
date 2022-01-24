using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using HospitalClassLib.Shift.Repository.IRepository;
using HospitalClassLib.Vacation.Repository.IRepository;
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
            var patientController = new PatientController(new PatientService(CreatePatientStudRepository(patientDto)), 
                new DoctorService(CreateDoctorStudRepository(), CreateShiftStubRepository(), CreateVacationtubRepository()), 
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

        [Fact]
        public void Free_doctor_test()
        {
            var doctorController = new DoctorController(new DoctorService(CreateDoctorStudRepository(), CreateShiftStubRepository(), CreateVacationtubRepository()));
            var result = doctorController.GetLessOccupiedDoctors();
            var okResult = result as ObjectResult;
            
            Assert.Equal(200, okResult.StatusCode);

        }

        private static IShiftRepository CreateShiftStubRepository()
        {
            var stubRepository = new Mock<IShiftRepository>();

            return stubRepository.Object;
        }

        private static IVacationRepository CreateVacationtubRepository()
        {
            var stubRepository = new Mock<IVacationRepository>();

            return stubRepository.Object;
        }

        private static IPatientRepository CreatePatientStudRepository(PatientDto patientDto)
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
            var freeDoctors = new List<Doctor>();
            var doctor = new Doctor { Id = 1};
            var doctor1 = new Doctor { Id = 2 };
            var doctor2 = new Doctor { Id = 3 };
            var doctor3 = new Doctor { Id = 4 };
            
            doctor.Patients = new List<Patient>();
            doctor1.Patients = new List<Patient>();
            doctor2.Patients = new List<Patient>();
            doctor3.Patients = new List<Patient>();
            
            doctor.Patients.Add(new Patient { Id = 1 });
            doctor.Patients.Add(new Patient { Id = 2 });
            doctor.Patients.Add(new Patient { Id = 3 });
            doctor2.Patients.Add(new Patient { Id = 4 });
            doctor2.Patients.Add(new Patient { Id = 5 });
            doctor2.Patients.Add(new Patient { Id = 6 });
            doctor2.Patients.Add(new Patient { Id = 7 });
            doctor2.Patients.Add(new Patient { Id = 8 });
            
            doctors.Add(doctor);
            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);

            freeDoctors.Add(doctor1);
            freeDoctors.Add(doctor3);

            stubRepository.Setup(q => q.GetAll()).Returns(doctors);
            stubRepository.Setup(q => q.Get(1)).Returns(doctors.First());
            stubRepository.Setup(q => q.GetLessOccupiedDoctors()).Returns(freeDoctors);
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
