using HospitalClassLib.Schedule.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HospitalClassLib.SharedModel.Enums;

namespace HospitalClassLib.Schedule.Repository.AppointmentRepo
{
    public class AppointmentRepository : AbstractSqlRepository<Appointment, int>, IAppointmentRepository
    {
        private MyDbContext dbContext;

        public AppointmentRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override int GetId(Appointment entity)
        {
            return entity.Id;
        }

        public List<Appointment> GetByPatient(int id)
        {
            return dbContext.Appointments.Where(x => x.PatientId == id).OrderByDescending(x => x.StartTime).ToList();
        }

        public int GetNumberOfCancelledAppointments(int id)
        {
            DateTime startDate = DateTime.Now;
            DateTime nextMonth = startDate.AddDays(30);
            DateTime lastMonth = startDate.AddDays(-30);
            return dbContext.Appointments.Count(x => x.PatientId == id && x.State == AppointmentState.cancelled && x.StartTime > lastMonth && x.StartTime < nextMonth);
        }

        public List<Appointment> GetByDoctor(int id)
        {
            return dbContext.Appointments.Where(x => x.DoctorId.Equals(id)).ToList();
        }

        public List<DateTime> GetDoctorTermsInSpecificDay(DateTime date, int doctorId)
        {
            return dbContext.Appointments.Where(app => app.DoctorId.Equals(doctorId) && app.StartTime.Day.Equals(date.Day)
            && app.StartTime.Month.Equals(date.Month) && app.StartTime.Year.Equals(date.Year)).Select(d => d.StartTime).ToList();

        }

        public bool FinishAppointments()
        {
            List<Appointment> doneAppointments = dbContext.Appointments.Where(x => x.StartTime.CompareTo(DateTime.Now) < 0 && x.State == AppointmentState.pending).ToList();

            foreach(Appointment ap in doneAppointments)
            {
                ap.State = AppointmentState.finished;
                Update(ap);
            }

            return true;
        }
    }
}
