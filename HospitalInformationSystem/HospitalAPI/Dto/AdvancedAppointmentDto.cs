using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dto
{
    public class AdvancedAppointmentDto
    {
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public int  DoctorId { get; set; }
        public bool DoctorPriority { get; set; }

        public AdvancedAppointmentDto(DateTime firstDate, DateTime lastDate, int doctorId, bool doctorPriority)
        {
            FirstDate = firstDate;
            LastDate = lastDate;
            DoctorId = doctorId;
            DoctorPriority = doctorPriority;
        }

    }
}
