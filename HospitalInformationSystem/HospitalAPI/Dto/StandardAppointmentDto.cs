using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class StandardAppointmentDto
    {
        public DateTime StartTime { get; set; }
        public int DoctorId { get; set; }
        public StandardAppointmentDto(DateTime startTime, int doctorId)
        {
            StartTime = startTime;
            DoctorId = doctorId;
        }
    }
}
