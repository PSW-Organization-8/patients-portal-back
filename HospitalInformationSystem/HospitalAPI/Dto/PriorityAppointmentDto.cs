using HospitalClassLib.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class PriorityAppointmentDto
    {
        public List<DateTime> FreeTerms { get; set; }
        public Doctor Doctor { get; set; }

        public PriorityAppointmentDto(List<DateTime> freeTerms, Doctor doctor)
        {
            FreeTerms = freeTerms;
            Doctor = doctor;
        }
    }
}
