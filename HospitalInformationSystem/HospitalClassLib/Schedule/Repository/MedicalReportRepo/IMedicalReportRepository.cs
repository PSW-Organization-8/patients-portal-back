using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Repository.MedicalReportRepo
{
    public interface IMedicalReportRepository
    {
        List<MedicalReport> GetAll();
        MedicalReport Get(int id);
        MedicalReport Update(MedicalReport medicalReport);
        MedicalReport Create(MedicalReport medicalReport);
        bool ExistsById(int id);
        bool Delete(int id);
        MedicalReport GetMedicalReportByAppointment(int appointmentId);
    }
}
