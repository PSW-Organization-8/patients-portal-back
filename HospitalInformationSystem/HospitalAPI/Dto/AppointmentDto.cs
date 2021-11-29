using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class AppointmentDto
    {
        public DateTime StartTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }


        public AppointmentDto(DateTime startTime, int doctorId, int patientId)
        {
            StartTime = startTime;
            DoctorId = doctorId;
            PatientId = patientId;
        }
    }
}
