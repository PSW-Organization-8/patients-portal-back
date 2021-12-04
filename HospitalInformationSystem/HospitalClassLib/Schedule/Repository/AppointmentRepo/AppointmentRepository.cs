using HospitalClassLib.Schedule.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            return dbContext.Appointments.Where(x => x.PatientId == id).ToList();
        }

        public List<DateTime> GetFreeInSpecificDay(int day, int doctorId)
        {
            return dbContext.Appointments.Where(app => app.DoctorId.Equals(doctorId) && app.StartTime.Day.Equals(day)).Select(d => d.StartTime).ToList();
        }
    }
}
