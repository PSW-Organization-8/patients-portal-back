using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.SharedModel
{
    public class TimeAndDuration
    {
        public DateTime RelocationTime { get; private set; }
        public int Duration { get; private set; }

        private TimeAndDuration() { }

        public TimeAndDuration(DateTime relocationTime, int duration)
        {
            RelocationTime = relocationTime;
            Duration = duration;
        }

        private void Validate()
        {
            if (Duration < 0) throw new ArgumentException("Duration must be positive");
        }

        public bool Includes(DateTime dateTime)
        {
            return RelocationTime < dateTime && RelocationTime.AddDays(Duration) > dateTime;
        }
    }
}
