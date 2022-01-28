using HospitalClassLib.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class PatientAppointDto
    {
        public Patient Patient { get; set; }
        public int NumOfAppointment { get; set; }

        public PatientAppointDto() { }

        public PatientAppointDto(Patient patient, int numOfAppointment)
        {
            this.Patient = patient;
            this.NumOfAppointment = numOfAppointment;
        }
    }
}
