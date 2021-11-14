using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    public class DoctorController
    {
        private readonly DoctorService doctorService;
        private readonly DoctorRepository doctorRepository;
        public DoctorController(DoctorService doctorService, DoctorRepository doctorRepository)
        {
            this.doctorService = doctorService;
            this.doctorRepository = doctorRepository;
        }
    }
}
