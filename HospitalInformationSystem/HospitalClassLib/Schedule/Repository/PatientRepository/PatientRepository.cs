﻿using HospitalClassLib.Schedule.Model;
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

        public LoggedUser GetLoggedUser(string username, string password) 
        {
            LoggedUser user = (LoggedUser)dbContext.Patients.Where(p => p.Username == username && p.Password == password && 
                p.PatientAccountStatus.IsActivated && !p.PatientAccountStatus.IsBanned).FirstOrDefault();
            return user;
        }

        public Patient GetByUsername(string username)
        {
            return dbContext.Patients.SingleOrDefault(patient => patient.Username.Equals(username));
        }

        public List<string> GetAllUsernames()
        {
            return dbContext.Patients.Select(patient => patient.Username).ToList();
        }

        public List<string> GetAllEmails()
        {
            return dbContext.Patients.Select(patient => patient.Contact.Email).ToList();
        }
    }
}
