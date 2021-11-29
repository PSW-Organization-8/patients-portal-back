using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService doctorService;
        private readonly DoctorRepository doctorRepository;
        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetLessOccupiedDoctors()
        {
            return Ok(doctorRepository.GetLessOccupiedDoctors());
        }

        [HttpGet("{id?}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(doctorService.Get(id));
        }
    }
}
