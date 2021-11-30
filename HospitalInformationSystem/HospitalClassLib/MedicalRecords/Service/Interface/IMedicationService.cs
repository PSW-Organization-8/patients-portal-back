using HospitalClassLib.MedicalRecords.Model;
using System.Collections.Generic;

namespace HospitalClassLib.MedicalRecords.Service.Interface
{
    public interface IMedicationService
    {
        List<Medication> GetAll();
        Medication GetMedicationByName(string name);

        Medication Get(long id);

        Medication Create(Medication newMedication);

        bool Delete(long id);

        bool Update(Medication medication);

        Medication AddMedicationFromPharmacy(Medication medication);
    }
}
