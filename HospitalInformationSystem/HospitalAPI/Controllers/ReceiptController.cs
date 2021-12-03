using HospitalAPI.Mapper;
using HospitalClassLib.MedicalRecords.Service.Interface;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService receiptService;
        private readonly PatientService patientService;
        private readonly DoctorService doctorService;

        public ReceiptController(IReceiptService receiptService, PatientService patientService, DoctorService doctorService) {
            this.receiptService = receiptService;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }

        [HttpPost]
        [Route("save_receipt")]
        public IActionResult SaveReceipt(Receipt receipt, long pharmacyId)
        {
            if (receipt == null) { return BadRequest(); }

            Receipt receipt1 = receiptService.Create(receipt);
            if (receipt1 != null) {
                RestClient restClientHospital = new RestClient("http://localhost:7313/api/Receipt/save_receipt");
                RestRequest requestHospital = new RestRequest();

                requestHospital.AddJsonBody(ReceiptMapper.ReceiptToReceiptDto(receipt, doctorService.Get(receipt.DoctorId), patientService.Get(receipt.PatientId), pharmacyId));

                var dataHospital = restClientHospital.Post<IActionResult>(requestHospital);

                if (dataHospital.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok();
                }

                return BadRequest();
            }
            return BadRequest();
        }
    }
}
