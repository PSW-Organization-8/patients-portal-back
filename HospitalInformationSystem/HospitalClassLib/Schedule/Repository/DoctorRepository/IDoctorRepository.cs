using HospitalClassLib.SharedModel;
using System.Collections.Generic;

namespace HospitalClassLib.Schedule.Repository.DoctorRepository
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
        Doctor Get(int id);
        Doctor Update(Doctor doctor);
        Doctor Create(Doctor doctor);
        bool ExistsById(int id);
        bool Delete(int id);
    }
}
