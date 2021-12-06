using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class AppointmentDto
    {
        public DateTime StartDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public AppointmentDto(DateTime startDate, int doctorId, int patientId)
        {
            StartDate = startDate;
            DoctorId = doctorId;
            PatientId = patientId;
        }
    }
}
