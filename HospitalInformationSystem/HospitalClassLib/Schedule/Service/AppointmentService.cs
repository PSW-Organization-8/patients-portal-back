using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.SharedModel.Enums;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.SharedModel;
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
        private readonly IDoctorRepository doctorRepository;
        #endregion Fields

        #region Constructors
        public AppointmentService() { }
        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.doctorRepository = doctorRepository;
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

        public List<DateTime> GetAppointmentByPriority(DateTime firstDate, DateTime lastDate, int doctorId, bool doctorPriority)
        {
            if (doctorPriority)
                return GetAppointmentsWithDoctorPriority(firstDate, lastDate, doctorId);
            else
                return GetAppointmentsWithDatePriority(firstDate, lastDate, doctorId);
        }

        private List<DateTime> GetAppointmentsWithDoctorPriority(DateTime firstDate, DateTime lastDate, int doctorId)
        {
            List<DateTime> appointmentDates = GetDoctorAppointmentsBetweenDates(firstDate, lastDate, doctorId);
            if (appointmentDates.Count < 1)
                appointmentDates = GetDoctorAppointmentsBetweenDates(firstDate.AddDays(-2), lastDate.AddDays(2), doctorId);
            return appointmentDates;
        }

        private List<DateTime> GetAppointmentsWithDatePriority(DateTime firstDate, DateTime lastDate, int doctorId)
        {
            List<DateTime> appointmentDates = GetDoctorAppointmentsBetweenDates(firstDate, lastDate, doctorId);
            if (appointmentDates.Count < 1)
            {
                foreach (Doctor doctor in doctorRepository.GetAll().Where(x => x.DoctorSpecialization.Equals(doctorRepository.Get(doctorId).DoctorSpecialization)))
                {
                    appointmentDates = GetDoctorAppointmentsBetweenDates(firstDate, lastDate, doctor.Id);
                    if (appointmentDates.Count > 0)
                        break;
                }

            }
            return appointmentDates;
        }

        private List<DateTime> GetDoctorAppointmentsBetweenDates(DateTime firstDate, DateTime lastDate, int doctorId)
        {
            List<Appointment> doctorAppointments = appointmentRepository.GetByDoctor(doctorId);
            List<DateTime> appointmentDates = new List<DateTime>();
            for (DateTime dateTime = firstDate; dateTime <= lastDate; dateTime = dateTime.AddMinutes(15))
                if (!doctorAppointments.Select(x => x.StartTime).ToList().Contains(dateTime) && dateTime.Hour >= 8 && dateTime.Hour < 16)
                    appointmentDates.Add(dateTime);
            return appointmentDates;
        }

        public List<Appointment> GetByPatient(int id)
        {
            return appointmentRepository.GetByPatient(id);
        }

        public bool CancelById(int id)
        {
            Appointment appointment = appointmentRepository.Get(id);
            if (appointment == null) return false;
            appointment.State = AppointmentState.cancelled;
            appointmentRepository.Update(appointment);
            return true;
        }

        public bool SurveyAppointment(int id)
        {
            Appointment appointment = appointmentRepository.Get(id);
            if (appointment == null || appointment.State != AppointmentState.finished) return false;
            appointment.IsSurveyed = true;
            appointmentRepository.Update(appointment);
            return true;
        }

        public int GetNumberOfCancelledAppointments(int id) 
        {
            return appointmentRepository.GetNumberOfCancelledAppointments(id);
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

