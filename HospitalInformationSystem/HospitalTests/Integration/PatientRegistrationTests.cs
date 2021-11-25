using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using System;
using Xunit;

namespace HospitalTests.Integration
{
    public class PatientRegistrationTests
    {
        [Fact]
        public void Register_new_patient()
        {
            //Arange
            var patientService = new PatientService(new PatientRepository(new MyDbContext()));

            //var patientDto = new PatientDto("Pera", "Peric", "12345");
            //var expectedResult = new PatientDto("Pera", "Peric", "12345");

            //Act
            //var result = PatientMapper.Proba(patientService.RegisterPatient(PatientMapper.PatientDtoToPatient(patientDto, new Doctor())));

            //Assert
            //Assert.Equal(expectedResult, result);
            
        }
    }
}
