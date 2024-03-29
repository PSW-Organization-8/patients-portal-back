﻿using HospitalClassLib.MedicalRecords.Model;
using HospitalClassLib.MedicalRecords.Repository.MedicationRepo;
using HospitalClassLib.MedicalRecords.Service.Interface;
using System.Collections.Generic;

namespace HospitalClassLib.MedicalRecords.Service
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository medicationRepository;
        public MedicationService(IMedicationRepository medicationRepository)
        {
            this.medicationRepository = medicationRepository;
        }

        public Medication AddMedicationFromPharmacy(Medication medication)
        {
            Medication existMedication = GetMedicationByName(medication.Name);
            if (existMedication == null)
            {
                return Create(medication);
            }

            existMedication.Quantity += medication.Quantity;
            if (Update(existMedication))
            {
                return existMedication;
            }
            return null;
        }

        public Medication Create(Medication newMedication)
        {
            return medicationRepository.Create(newMedication);
        }

        public bool Delete(long id)
        {
            bool success = false;
            if (Get(id) != null)
            {
                success = true;
                medicationRepository.Delete(id);
            }
            return success;
        }

        public Medication Get(long id)
        {
            return medicationRepository.Get(id); ;
        }

        public List<Medication> GetAll()
        {
            return medicationRepository.GetAll();
        }

        public Medication GetMedicationByName(string name)
        {
            return medicationRepository.GetMedicationByName(name);
        }

        public bool Update(Medication medication)
        {
            bool success = false;
            if (Get(medication.MedicineID) != null)
            {
                success = true;
                medicationRepository.Update(medication);
            }
            return success;
        }
    }
}
