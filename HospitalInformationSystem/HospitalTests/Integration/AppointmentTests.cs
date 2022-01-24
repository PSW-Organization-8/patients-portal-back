using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalClassLib;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using HospitalClassLib.Shift.Repository;
using HospitalClassLib.Vacation.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
            var doctorService = new DoctorService(new DoctorRepository(context), new ShiftRepository(context), new VacationRepository(context));
            var patientService = new PatientService(new PatientRepository(context));
            var appointmentController = new AppointmentController(new AppointmentService(new AppointmentRepository(context), new DoctorRepository(context)), 
                doctorService, patientService);
            var appointmentDto = new AppointmentDto(new DateTime(2025, 12, 12, 13, 0, 0), 1, 1);
            var expectedResult = new Appointment(new DateTime(2025, 12, 12, 13, 0, 0), doctorService.Get(1), patientService.Get(1));

            
            var result = appointmentController.CreateNewAppointment(appointmentDto);
            var okResult = result as ObjectResult;

            
            Assert.Equal(200, okResult.StatusCode);
        }

        [Theory]
        [MemberData(nameof(Get_free_appointments_data))]
        public void Get_free_appointments(DateTime startTime, int doctorId, List<DateTime> expectedResult)
        {
            var doctorService = new DoctorService(new DoctorRepository(context), new ShiftRepository(context), new VacationRepository(context));
            var patientService = new PatientService(new PatientRepository(context));
            var appointmentController = new AppointmentController(new AppointmentService(new AppointmentRepository(context), new DoctorRepository(context)),
                doctorService, patientService);


            var result = appointmentController.GetFreeTerms(startTime, doctorId) as ObjectResult;


            Assert.Equal(result.Value, expectedResult);
        }
        public static IEnumerable<object[]> Get_free_appointments_data =>
        new List<object[]>
        {
            new object[] { new DateTime(2021, 12, 15), 6, new List<DateTime>{
                    new DateTime(2021, 12, 15, 8, 0, 0),
                    new DateTime(2021, 12, 15, 8, 15, 0),
                    new DateTime(2021, 12, 15, 8, 30, 0),
                    new DateTime(2021, 12, 15, 8, 45, 0),
                    new DateTime(2021, 12, 15, 9, 0, 0),
                    new DateTime(2021, 12, 15, 9, 15, 0),
                    new DateTime(2021, 12, 15, 9, 30, 0),
                    new DateTime(2021, 12, 15, 9, 45, 0),
                    new DateTime(2021, 12, 15, 10, 0, 0),
                    new DateTime(2021, 12, 15, 10, 30, 0),
                    new DateTime(2021, 12, 15, 10, 45, 0),
                    new DateTime(2021, 12, 15, 11, 0, 0),
                    new DateTime(2021, 12, 15, 11, 15, 0),
                    new DateTime(2021, 12, 15, 11, 30, 0),
                    new DateTime(2021, 12, 15, 11, 45, 0),
                    new DateTime(2021, 12, 15, 12, 0, 0),
                    new DateTime(2021, 12, 15, 12, 15, 0),
                    new DateTime(2021, 12, 15, 12, 30, 0),
                    new DateTime(2021, 12, 15, 12, 45, 0),
                    new DateTime(2021, 12, 15, 13, 0, 0),
                    new DateTime(2021, 12, 15, 13, 30, 0),
                    new DateTime(2021, 12, 15, 13, 45, 0),
                    new DateTime(2021, 12, 15, 14, 0, 0),
                    new DateTime(2021, 12, 15, 14, 15, 0),
                    new DateTime(2021, 12, 15, 14, 30, 0),
                    new DateTime(2021, 12, 15, 14, 45, 0),
                    new DateTime(2021, 12, 15, 15, 0, 0),
                    new DateTime(2021, 12, 15, 15, 15, 0),
                    new DateTime(2021, 12, 15, 15, 30, 0),
                }
            },

            new object[] { new DateTime(2021, 12, 16), 6, new List<DateTime>{
                    new DateTime(2021, 12, 16, 8, 0, 0),
                    new DateTime(2021, 12, 16, 8, 15, 0),
                    new DateTime(2021, 12, 16, 8, 30, 0),
                    new DateTime(2021, 12, 16, 8, 45, 0),
                    new DateTime(2021, 12, 16, 9, 0, 0),
                    new DateTime(2021, 12, 16, 9, 15, 0),
                    new DateTime(2021, 12, 16, 9, 30, 0),
                    new DateTime(2021, 12, 16, 9, 45, 0),
                    new DateTime(2021, 12, 16, 10, 0, 0),
                    new DateTime(2021, 12, 16, 10, 15, 0),
                    new DateTime(2021, 12, 16, 10, 30, 0),
                    new DateTime(2021, 12, 16, 10, 45, 0),
                    new DateTime(2021, 12, 16, 11, 0, 0),
                    new DateTime(2021, 12, 16, 11, 15, 0),
                    new DateTime(2021, 12, 16, 11, 30, 0),
                    new DateTime(2021, 12, 16, 11, 45, 0),
                    new DateTime(2021, 12, 16, 12, 0, 0),
                    new DateTime(2021, 12, 16, 12, 15, 0),
                    new DateTime(2021, 12, 16, 12, 30, 0),
                    new DateTime(2021, 12, 16, 12, 45, 0),
                    new DateTime(2021, 12, 16, 13, 0, 0),
                    new DateTime(2021, 12, 16, 13, 15, 0),
                    new DateTime(2021, 12, 16, 13, 30, 0),
                    new DateTime(2021, 12, 16, 13, 45, 0),
                    new DateTime(2021, 12, 16, 14, 0, 0),
                    new DateTime(2021, 12, 16, 14, 15, 0),
                    new DateTime(2021, 12, 16, 14, 30, 0),
                    new DateTime(2021, 12, 16, 14, 45, 0),
                    new DateTime(2021, 12, 16, 15, 0, 0),
                    new DateTime(2021, 12, 16, 15, 15, 0),
                    new DateTime(2021, 12, 16, 15, 30, 0),
                    new DateTime(2021, 12, 16, 15, 45, 0),
                }
            },

             new object[] { new DateTime(2022, 1, 1), 1, new List<DateTime>{
                    
                }
            },
        };
    }
}
