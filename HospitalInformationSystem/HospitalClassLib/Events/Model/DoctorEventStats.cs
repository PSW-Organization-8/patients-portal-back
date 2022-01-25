using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Model
{
    public class DoctorEventStats
    {
        public string DoctorFullName { get; set; }
        public string DoctorSpecialization { get; set; }
        public int Selected { get; set; }
        public int Scheduled { get; set; }
        public int UniquePatients { get; set; }

        public DoctorEventStats(string doctorFullName, string doctorSpecialization, int selected, int scheduled, int uniquePatients)
        {
            DoctorFullName = doctorFullName;
            DoctorSpecialization = doctorSpecialization;
            Selected = selected;
            Scheduled = scheduled;
            UniquePatients = uniquePatients;
        }
    }
}
