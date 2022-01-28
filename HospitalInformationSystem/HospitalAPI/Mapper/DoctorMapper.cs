using HospitalAPI.Dto;
using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mapper
{
    public class DoctorMapper
    {
        public static FreeDoctorDto DoctorToFreeDoctorDtoDto(Doctor doctor)
        {
            return new FreeDoctorDto(doctor.Id, doctor.Name, doctor.LastName);
        }
    }
}
