using HospitalClassLib.Schedule.Model;
using SIMS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
