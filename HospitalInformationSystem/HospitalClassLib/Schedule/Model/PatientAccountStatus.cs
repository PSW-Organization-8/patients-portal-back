using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Model
{
    public class PatientAccountStatus
    {
        public bool IsBanned { get; set; }
        public bool IsActivated { get; set; }

        public PatientAccountStatus() { }
        public PatientAccountStatus(bool isBanned, bool isActivated)
        {
            IsBanned = isBanned;
            IsActivated = isActivated;
        }
    }
}
