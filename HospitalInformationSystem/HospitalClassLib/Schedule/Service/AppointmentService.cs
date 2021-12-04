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
        private readonly int HOURS_IN_ONE_DOCTOR_SHIFT = 8;
        private readonly int MINUTES_IN_ONE_HOUR = 4;
        public AppointmentService() { }

        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
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

        public List<Appointment> GetByPatient(int id)
        {
            return appointmentRepository.GetByPatient(id);
        }

        public ICollection<DateTime> GetFreeTerms(DateTime appoinmentDate, int doctorId)
        {
            List<DateTime> doctorAppointments = appointmentRepository.GetFreeInSpecificDay(appoinmentDate.Day, doctorId);
            ICollection<DateTime> freeTerms = new List<DateTime>();
            for (int hourCounter = 8; hourCounter < 16; hourCounter++)
            {
                for (int minuteCounter = 0; minuteCounter < 4; minuteCounter++)
                {
                    foreach(DateTime date in doctorAppointments)
                    {
                        if(!(date.Minute.Equals(minuteCounter * 15) && date.Hour.Equals(hourCounter)))
                            freeTerms.Add(new DateTime(appoinmentDate.Year, appoinmentDate.Month,
                                appoinmentDate.Day, hourCounter, minuteCounter * 15, 0));
                    }
                }
            }

            return freeTerms;
        }
    }
}

