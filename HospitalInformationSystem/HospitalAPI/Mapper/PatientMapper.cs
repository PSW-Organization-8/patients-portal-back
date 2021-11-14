using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mapper
{
    public class PatientMapper
    {
        public static Patient PatientDtoToPatient(PatientDto dto)
        {
            return new Patient(dto.Name, dto.LastName, dto.Jmbg, dto.Username, dto.Password, dto.Email, dto.Phone, false, "", false, dto.DateOfBirth, dto.Allergens, dto.Doctor);
        }

        public static PatientDto PatientToPatientkDto(Patient patient)
        {
            return new PatientDto(patient.Name, patient.LastName, patient.Jmbg, patient.Username, patient.Password, patient.Email, patient.Phone, patient.DateOfBirth,
                patient.Allergens, patient.Doctor);
        }
    }
}
