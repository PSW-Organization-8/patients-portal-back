using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Service
{
    public class DoctorService
    {
        public DoctorService() { }

        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public Doctor Get(int id)
        {
            return doctorRepository.Get(id);
        }

        public Doctor GetDoctorByID(int ID)
        {
            List<Doctor> allDoctors = GetAllDoctors();
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.Id == ID)
                    return doctor;
            }

            return null;
        }

        public List<Doctor> GetLessOccupiedDoctors()
        {
            return doctorRepository.GetLessOccupiedDoctors();
        }

        public ICollection<Doctor> GetSpecificDoctors(Specialization specialization)
        {
            return doctorRepository.GetSpecificDoctors(specialization);
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAll();
        }
    }
}
