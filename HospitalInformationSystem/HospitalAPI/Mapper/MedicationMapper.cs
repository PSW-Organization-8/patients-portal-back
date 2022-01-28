using HospitalAPI.Dto;
using HospitalClassLib.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mapper
{
    public class MedicationMapper
    {
        public static Medication MedicationDtoToMedication(MedicationDto medicationDto)
        {
            return new Medication(medicationDto.Name, medicationDto.Quantity);
        }
        public static MedicationDto MedicationToMedicationDto(Medication medication)
        {
            return new MedicationDto(medication.Name, medication.Quantity);
        }
    }
}
