using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.PatientRepository
{
    public class PatientRepository : AbstractSqlRepository<Patient, int>, IPatientRepository
    {
        private MyDbContext dbContext;

        public PatientRepository(MyDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override int GetId(Patient entity)
        {
            return entity.Id;
        }
        public Patient GetByToken(int patientToken)
        {
            return dbContext.Patients.SingleOrDefault(patient => patient.Token == patientToken);
        }
    }
}
