using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService doctorService;
        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetLessOccupiedDoctors()
        {
            return Ok(doctorService.GetLessOccupiedDoctors());
        }

        [HttpGet("{id?}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(doctorService.Get(id));
        }

        [HttpGet("spec/{specialization?}")]
        public IActionResult GetSpecificDoctors(Specialization specialization)
        {
            return Ok(doctorService.GetSpecificDoctors(specialization));
            //return Ok("Poruka");
        }

        [HttpGet("allDoctors")]
        public IActionResult GetAllDoctors(Specialization specialization)
        {
            return Ok(doctorService.GetAllDoctors());
        }
    }
}
