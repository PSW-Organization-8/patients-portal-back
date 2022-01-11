using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using HospitalClassLib.Shift.Repository.IRepository;
using HospitalClassLib.Vacation.Repository.IRepository;
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
        private readonly IShiftRepository shiftRepository;
        private readonly IVacationRepository vacationRepository;



        public DoctorService(IDoctorRepository doctorRepository, IShiftRepository shiftRepository, IVacationRepository vacationRepository)
        {
            this.doctorRepository = doctorRepository;
            this.shiftRepository = shiftRepository;
            this.vacationRepository = vacationRepository;
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


        public SharedModel.Doctor EditDoctorShift(long shiftID,  int doctorId)
        {
            Doctor doctor = doctorRepository.Get(doctorId);
            SharedModel.Shift shift = shiftRepository.Get(shiftID);

            doctor.DoctorShift = shift;


            return doctorRepository.Update(doctor);
        }

        public SharedModel.Doctor EditDoctorVacation(long vacationID, int doctorId)
        {
            Doctor doctor = doctorRepository.Get(doctorId);
            SharedModel.VacationPeriod vacationPeriod = vacationRepository.Get(vacationID);
            doctor.Vacation = vacationPeriod;


            return doctorRepository.Update(doctor);
        }

    }
}
