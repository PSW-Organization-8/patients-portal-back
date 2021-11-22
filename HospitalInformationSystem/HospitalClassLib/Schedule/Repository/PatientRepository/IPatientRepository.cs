using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.PatientRepository
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
        Patient Get(int id);
        Patient Update(Patient patient);
        Patient Create(Patient patient);
        bool ExistsById(int id);
        bool Delete(int id);
        Patient GetByToken(string patientToken);
    }
}
