using HospitalAPI.Dto;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Mapper
{
    public class PatientMapper
    {
        public static Patient PatientDtoToPatient(PatientDto dto, Doctor doctor, List<Allergen> allergens)
        {
            return new Patient(dto.Name, dto.LastName, dto.Jmbg, dto.Username, dto.Password, dto.Email, dto.Phone, dto.Country, dto.City, dto.Address, false,
                dto.DateOfBirth, allergens, doctor, dto.IsActivated, dto.Token, (BloodType)Enum.Parse(typeof(BloodType), dto.BloodType));
        }
        public static PatientDto PatientToPatientkDto(Patient patient)
        {
            return new PatientDto(patient.Name, patient.LastName, patient.Jmbg, patient.Username, patient.Password, patient.Contact.Email, patient.Contact.Phone, 
                patient.Address.Country, patient.Address.City,patient.Address.Street, patient.DateOfBirth, patient.Allergens, patient.DoctorId,
                patient.IsActivated, patient.Token, patient.BloodType.ToString());
        }

        public static Patient TestDtoToPatient(PatientDto dto)
        {
            return new Patient(dto.Name, dto.LastName, dto.Jmbg, dto.Username, dto.Password, dto.Email, dto.Phone, dto.Country, dto.City, dto.Address,
            dto.DateOfBirth, dto.Allergens, dto.DoctorId, dto.IsActivated, dto.Token, dto.BloodType);
        }
    }
}