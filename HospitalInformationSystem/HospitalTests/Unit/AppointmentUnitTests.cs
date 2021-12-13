using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalAPI.Validators;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
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
    public class AppointmentUnitTests
    {
        [Theory]
        [MemberData(nameof(AppointmentData))]
        public void Create_appointment_validator_tests(AppointmentDto appointmentDto, int expectedResult)
        {
            var doctorService = new DoctorService(CreateDoctorStubRepository());
            var patientService = new PatientService(CreatePatientStudRepository());
            var appointmentController = new AppointmentController(new AppointmentService(CreateAppointmentStubRepository()),
                doctorService, patientService);

            var result = appointmentController.CreateNewAppointment(appointmentDto) as ObjectResult;

            Assert.Equal(result.StatusCode, expectedResult);
        }
        [Theory]
        [MemberData(nameof(FreeTermsData))]
        public void Get_free_terms_validator_tests(DateTime startDate, int doctorId, bool expectedResult)
        {
            var doctorService = new DoctorService(CreateDoctorStubRepository());
            var patientService = new PatientService(CreatePatientStudRepository());
            var appointmentService = new AppointmentService();
            var validator = new AppointmentValidator(doctorService, patientService, appointmentService);

            var result = validator.Valid(startDate, doctorId);

            Assert.Equal(result, expectedResult);

        }
        public static IEnumerable<object[]> AppointmentData =>
        new List<object[]>
        {
            new object[] { new AppointmentDto(new DateTime(2022, 1, 2, 8, 0, 0), 1, 1), 200 },
            new object[] { new AppointmentDto(new DateTime(2020, 1, 2, 8, 0, 0), 1, 1), 400 },
            new object[] { new AppointmentDto(new DateTime(2022, 1, 2, 8, 0, 0), 0, 1), 400 },
            new object[] { new AppointmentDto(new DateTime(2022, 1, 2, 8, 0, 0), 0, 0), 400 },
            new object[] { new AppointmentDto(new DateTime(2022, 1, 2, 8, 0, 0), 1, 0), 400 },
            new object[] { new AppointmentDto(new DateTime(2022, 1, 2, 8, 0, 0), 5, 1), 400 },
            new object[] { new AppointmentDto(new DateTime(2022, 1, 2, 8, 0, 0), 1, 5), 400 },
            new object[] { null, 400 },
 
        };
        public static IEnumerable<object[]> FreeTermsData =>
        new List<object[]>
        {
            new object[] { new DateTime(2022, 1, 2, 8, 0, 0), 1, true },
            new object[] { new DateTime(2020, 1, 2, 8, 0, 0), 1, false },
            new object[] { new DateTime(2022, 1, 2, 8, 0, 0), 15, false },
            new object[] { null, null, false },
            new object[] { new DateTime(2022, 1, 2, 8, 0, 0), null, false },
            new object[] { null, 1, false },

        };
        private static IDoctorRepository CreateDoctorStubRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();
            var doctor = new Doctor { Id = 1 };

            doctors.Add(doctor);

            stubRepository.Setup(d => d.Get(1)).Returns(doctors.First());

            return stubRepository.Object;
        }

        private static IPatientRepository CreatePatientStudRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            var patients = new List<Patient>();
            var patient = new Patient { Id = 1 };

            patients.Add(patient);

            stubRepository.Setup(p => p.Get(1)).Returns(patients.First());

            return stubRepository.Object;
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var doctorTerms = new List<DateTime>();
            var startTime = new DateTime(2022, 4, 4, 10, 0, 0);

            doctorTerms.Add(startTime);

            stubRepository.Setup(ap => ap.GetDoctorTermsInSpecificDay(startTime, 1)).Returns(doctorTerms);

            return stubRepository.Object;
        }
    }
}
