using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
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

<<<<<<< HEAD
        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("/api/editDoctorShift/{shiftID}/{doctorID}")]
        public Doctor EditDoctorShift(long shiftID, int doctorID)
        {
            return doctorService.EditDoctorShift(shiftID,doctorID);
        }



=======
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/api/doctorById")]
        public Doctor GetDoctorByID(int ID)
        {
            return doctorService.GetDoctorByID(ID);
        }


>>>>>>> 3ecf80d49b54a47bdcdfedb0cbd7566bd4f2c90a
        [HttpGet("spec/{specialization?}")]
        public IActionResult GetSpecificDoctors(Specialization specialization)
        {
            return Ok(doctorService.GetSpecificDoctors(specialization));
            //return Ok("Poruka");
        }

        [HttpGet("allDoctors")]
        public IActionResult GetAllDoctors()
        {
            return Ok(doctorService.GetAllDoctors());
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("/api/editDoctorVacation/{vacationID}/{doctorID}")]
        public Doctor EditDoctorVacation(long vacationID, int doctorID)
        {
            return doctorService.EditDoctorVacation(vacationID, doctorID);
        }

    }




}
