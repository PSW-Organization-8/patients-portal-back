using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.SharedModel.Enums;
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

        public bool CancelById(int id)
        {
            Appointment a = appointmentRepository.Get(id);
            
            if (a == null) return false;

            a.State = AppointmentState.cancelled;
            appointmentRepository.Update(a);

            return true;
        }
    }
}
