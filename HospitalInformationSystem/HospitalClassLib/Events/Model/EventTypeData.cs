using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Model
{
    public class EventTypeData
    {
        public int Next { get; set; }
        public int Back { get; set; }
        public int SpecializaitonSelection { get; set; }
        public int DateSelection { get; set; }
        public int DoctorSelection { get; set; }
        public int Schedule { get; set; }

        public EventTypeData(int next, int back, int specializaitonSelection, int dateSelection, int doctorSelection, int schedule)
        {
            Next = next;
            Back = back;
            SpecializaitonSelection = specializaitonSelection;
            DateSelection = dateSelection;
            DoctorSelection = doctorSelection;
            Schedule = schedule;
        }
    }
}
