using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
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
    public class BanPatientTest : IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;


        public BanPatientTest(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        }


        [Fact]
        public void Appointment_num_cancelled_good()
        {
            AppointmentController controller = new AppointmentController(new AppointmentService(new AppointmentRepository(context)), new PatientService(new PatientRepository(context)));

            var result = controller.GetNumberOfCancelledAppointments(1);
            var okResult = result as ObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
