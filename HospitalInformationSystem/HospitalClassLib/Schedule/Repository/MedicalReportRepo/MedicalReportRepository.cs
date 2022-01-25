using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.MedicalReportRepo
{
    public class MedicalReportRepository : AbstractSqlRepository<MedicalReport, int>, IMedicalReportRepository
    {
        private MyDbContext dbContext;

        public MedicalReportRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override int GetId(MedicalReport entity)
        {
            return entity.Id;
        }

        public MedicalReport GetMedicalReportByAppointment(int appointmentId)
        {
            return dbContext.MedicalReports.Where(x => x.AppointmentId == appointmentId).FirstOrDefault();
        }
    }
}
