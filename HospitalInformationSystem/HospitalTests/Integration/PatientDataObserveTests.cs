using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
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
    public class PatientDataObserveTests: IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;

        public PatientDataObserveTests(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        }

        [Fact]
        public void Patients_appointments_exists()
        {
            AppointmentController controller = new AppointmentController(new AppointmentService(new AppointmentRepository(context)));

            var result = controller.GetByPatient(1) as ObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        public void Patients_appointments_do_not_exist()
        {
            AppointmentController controller = new AppointmentController(new AppointmentService(new AppointmentRepository(context)));

            var result = controller.GetByPatient(2) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
        }
    }
}
