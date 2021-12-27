using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
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
        public Patient GetByToken(string patientToken)
        {
            return dbContext.Patients.SingleOrDefault(patient => patient.Token.Equals(patientToken));
        }

        public UserLogin GetLoggedPatient(string username) 
        {
            Patient p =  dbContext.Patients.Where(p => p.Username == username).FirstOrDefault();
            UserLogin user = new UserLogin();
            user.Username = p.Username;
            user.Password = p.Password;
            user.Role = "Patient";
            return user;
        }
    }
}
