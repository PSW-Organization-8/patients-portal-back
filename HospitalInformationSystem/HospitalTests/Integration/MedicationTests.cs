using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.MedicalRecords.Service;
using IntegrationClassLib.Pharmacy.Repository.MedicationRepo;
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
    public class MedicationTests : IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;
        public MedicationTests(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        }

        [Fact]
        public void Get_medication_promotions()
        {
            var medcationController = new MedcationController(new MedicationService(new MedicationRepository(context)));

            var result = medcationController.GetMedicationPromotions();
            var okResult = result as ObjectResult;

            Assert.Equal(200, okResult.StatusCode);
        }


    }
}
