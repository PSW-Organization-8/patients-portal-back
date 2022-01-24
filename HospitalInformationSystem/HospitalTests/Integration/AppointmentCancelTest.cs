using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.Shift.Repository;
using HospitalClassLib.Vacation.Repository;
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
    public class AppointmentCancelTest: IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;

        public AppointmentCancelTest(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        }

        [Fact]
        public void Appointment_cancelled_good()
        {
            AppointmentController controller = new AppointmentController(new AppointmentService(new AppointmentRepository(context), new DoctorRepository(context)), new DoctorService(new DoctorRepository(context), new ShiftRepository(context), new VacationRepository(context)), new PatientService(new PatientRepository(context)));

            var result = controller.CancelById(1);
            var okResult = result as ObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Appointment_cancelled_bad()
        {
            AppointmentController controller = new AppointmentController(new AppointmentService(new AppointmentRepository(context), new DoctorRepository(context)), new DoctorService(new DoctorRepository(context), new ShiftRepository(context), new VacationRepository(context)), new PatientService(new PatientRepository(context)));

            var result = controller.CancelById(-1);
            var okResult = result as ObjectResult;

            Assert.Equal(400, okResult.StatusCode);
        }

    }


}
