using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
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
        public AppointmentService() { }

        private readonly IAppointmentRepository appointmentRepository;
        private readonly IDoctorRepository doctorRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.doctorRepository = doctorRepository;
        }

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
    }
}
