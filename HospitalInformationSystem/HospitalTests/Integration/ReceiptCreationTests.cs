using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.MedicalRecords.Repository.ReceiptRepo;
using HospitalClassLib.MedicalRecords.Service;
using HospitalClassLib.MedicalRecords.Service.Interface;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class ReceiptCreationTests
    {

        [Fact]
        public void Conection_with_integration_formed()
        {
            MyDbContext dbContext = new MyDbContext();
            IReceiptRepository receiptRepository = new ReceiptRepository(dbContext);
            ReceiptController receiptController = MakeController(dbContext);

            Receipt receipt = new Receipt { MedicineName = "Ventolin", Amount = 1, Diagnosis = "Korona", DoctorId = 1, PatientId = 1, Date = DateTime.Today };
            IActionResult response = receiptController.SaveReceipt(receipt, 1);

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public void Receipt_created()
        {
            MyDbContext dbContext = new MyDbContext();
            IReceiptRepository receiptRepository = new ReceiptRepository(dbContext);
            ReceiptController receiptController = MakeController(dbContext);

            List<Receipt> listBefore = receiptRepository.GetAll();
            Receipt receipt = new Receipt { MedicineName = "Ventolin", Amount = 1, Diagnosis="Korona", DoctorId= 1, PatientId= 2, Date = DateTime.Today};
            receiptController.SaveReceipt(receipt, 1);
            List<Receipt> listAfter = receiptRepository.GetAll();

            listAfter.Count.ShouldBe(listBefore.Count + 1);
        }

        [Fact]
        public void Receipt_null_blocked()
        {
            MyDbContext dbContext = new MyDbContext();
            IReceiptRepository receiptRepository = new ReceiptRepository(dbContext);
            ReceiptController receiptController = MakeController(dbContext);

            List<Receipt> listBefore = receiptRepository.GetAll();
            Receipt receipt = null;
            receiptController.SaveReceipt(receipt, 1);
            List<Receipt> listAfter = receiptRepository.GetAll();

            listAfter.Count.ShouldBe(listBefore.Count);
        }

        private ReceiptController MakeController(MyDbContext dbContext) 
        {
            IReceiptRepository receiptRepository = new ReceiptRepository(dbContext);
            IReceiptService receiptService = new ReceiptService(receiptRepository);
            IDoctorRepository doctorRepository = new DoctorRepository(dbContext);
            DoctorService doctorService = new DoctorService(doctorRepository);
            IPatientRepository patientRepository = new PatientRepository(dbContext);
            PatientService patientService = new PatientService(patientRepository);
            ReceiptController receiptController = new ReceiptController(receiptService, patientService, doctorService);
            return receiptController;
        }

    }
}
