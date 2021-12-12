using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Service
{
    public class AppointmentService
    {
        #region Fields
        private readonly int DOCTOR_SHIFT_START_HOUR = 8;
        private readonly int DOCTOR_SHIFT_END_HOUR = 16;
        private readonly int MAX_TERMS_NUM_IN_ONE_HOUR = 4;
        private readonly int TERM_DURATION = 15;
        private readonly IAppointmentRepository appointmentRepository;
        #endregion Fields

        #region Constructors
        public AppointmentService() { }
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        #endregion Constructors

        #region Methods
        public Appointment Get(int id)
        {
            return appointmentRepository.Get(id);
        }
        public List<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }
        public Appointment Create(Appointment appointment)
        {
            return appointmentRepository.Create(appointment);
        }
        public bool Delete(int id)
        {
            return appointmentRepository.Delete(id);
        }
        public List<Appointment> GetByPatient(int id)
        {
            return appointmentRepository.GetByPatient(id);
        }
        public List<Appointment> GetByDoctor(int id)
        {
            return appointmentRepository.GetByDoctor(id);
        }
        public List<DateTime> GetFreeTerms(DateTime appoinmentDate, int doctorId)
        {
            return GenerateFreeTerms(appointmentRepository.GetDoctorTermsInSpecificDay(appoinmentDate, doctorId), GetPotentialFreeTerms(appoinmentDate));
        }
        private List<DateTime> GetPotentialFreeTerms(DateTime appoinmentDate)
        {
            List<DateTime> potentialFreeTerms = new List<DateTime>();
            for (int hourCounter = DOCTOR_SHIFT_START_HOUR; hourCounter < DOCTOR_SHIFT_END_HOUR; hourCounter++)
                for (int minuteCounter = 0; minuteCounter < MAX_TERMS_NUM_IN_ONE_HOUR; minuteCounter++)
                    potentialFreeTerms.Add(new DateTime(appoinmentDate.Year, appoinmentDate.Month, appoinmentDate.Day, hourCounter, minuteCounter * TERM_DURATION, 0));
            return potentialFreeTerms;
        }
        private List<DateTime> GenerateFreeTerms(List<DateTime> doctorTerms, List<DateTime> potentialFreeTerms)
        {
            foreach (DateTime doctorTerm in doctorTerms)
                if (potentialFreeTerms.Contains(doctorTerm)) potentialFreeTerms.Remove(doctorTerm);
            return potentialFreeTerms;
        }
        #endregion Methods
    }
}

