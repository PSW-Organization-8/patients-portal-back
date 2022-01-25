using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Events.Model
{
    public class EventData
    {
        public List<int> Minors { get; set; }
        public List<int> YoungAdults { get; set; }
        public List<int> Adults { get; set; }
        public List<int> Seniors { get; set; }
        public List<int> Veterans { get; set; }
        public List<int> Next { get; set; }
        public List<int> Back { get; set; }
        public EventData() { }
        public EventData(List<int> minors, List<int> youngAdults, List<int> adults, List<int> seniors, List<int> veterans)
        {
            this.Minors = minors;
            this.YoungAdults = youngAdults;
            this.Adults = adults;
            this.Seniors = seniors;
            this.Veterans = veterans;
        }

        public EventData(List<int> next, List<int> back)
        {
            this.Next = next;
            this.Back = back;
        }

    }
}
