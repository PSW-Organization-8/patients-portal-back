using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using HospitalClassLib.MedicalRecords.Model;
using HospitalClassLib.MedicalRecords.Service.Interface;
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
    public class MedcationController : ControllerBase
    {
        private readonly IMedicationService medicationService;

        public MedcationController(IMedicationService medicationService)
        {
            this.medicationService = medicationService;
        }

        [HttpPost]
        [Route("save_medication")]
        public IActionResult SaveMedication(MedicationDto medicationDto)
        {
            if (medicationService.AddMedicationFromPharmacy(MedicationMapper.MedicationDtoToMedication(medicationDto)) == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        [Route("promotions")]
        public IActionResult GetMedicationPromotions()
        {
            var client = new RestClient("http://localhost:18013");

            var request = new RestRequest("api/pharmacy/promotions", Method.GET);

            IRestResponse response = client.Execute(request);

            return Ok(response.Content);

        }
    }
}
