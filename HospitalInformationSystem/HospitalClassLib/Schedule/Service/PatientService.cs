using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Service
{
    public class PatientService
    {
        public PatientService() { }

        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public Patient Get(int id)
        {
            return patientRepository.Get(id);
        }

        public Patient Create(Patient patient)
        {
            return patientRepository.Create(patient);
        }
    }
}
