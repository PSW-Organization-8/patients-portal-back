using HospitalClassLib.MedicalRecords.Model;
using SIMS.Repositories;

namespace HospitalClassLib.MedicalRecords.Repository.MedicationRepo
{
    public interface IMedicationRepository : IGenericRepository<Medication, long>
    {
        Medication GetMedicationByName(string name);
    }
}
